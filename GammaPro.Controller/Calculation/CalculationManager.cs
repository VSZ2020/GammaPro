using GammaPro.Controller.Buildup;
using GammaPro.Controller.Geometry;
using GammaPro.Controller.Services;
using GammaPro.Geometry;
using GammaPro.Geometry.Point;
using GammaPro.RadiationSource;
using GammaPro.Utils.Interpolator;
using GammaPro.Utils.RadiationFactors.Buildup;

namespace GammaPro.Controller.Calculation
{
    public class CalculationManager
    {
        private readonly ICalculationGeometry calcGeometry;
        private readonly InterpolatorService interpolatorService;
        private readonly IList<EnergyIntensity> sourceEnergies;
        private readonly IList<Point3D> registrationPoints;
        private readonly CancellationToken token;
        private IBuildupCoefficientsProvider coefficients_provider;

        /// <summary>
        /// Базовый конструктор класса
        /// </summary>
        /// <param name="registrationPoints">Массив точек, для которых необходимо выполнить расчеты</param>
        /// <param name="geometry">Геометрия, для которой выполняется расчет</param>
        /// <param name="interpServices">Сервис интерполяции коэффициентов</param>
        /// <param name="coefficients_provider">Провайдер коэффициентов для фактора накопления</param>
        /// <param name="token">Токен отмены вычислений</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CalculationManager(
            IList<Point3D> registrationPoints,
            ICalculationGeometry geometry, 
            InterpolatorService interpServices, 
            IBuildupCoefficientsProvider coefficients_provider,
            CancellationToken token)
        {
            if (geometry == null)
                throw new ArgumentNullException("Calculation geometry is NULL!");
            if (interpServices is null)
                throw new ArgumentNullException("Interpolation handler has NULL reference");
            if (coefficients_provider == null)
                throw new ArgumentNullException("Coefficients provider is NULL");

            this.registrationPoints = registrationPoints;
            this.calcGeometry = geometry;
            this.interpolatorService = interpServices;
            this.coefficients_provider = coefficients_provider;
            this.token = token;
        }

        public CalculationResults ProcessCalculation()
        {
            return new CalculationResults(GetResultsForPoints(registrationPoints));
        }

        public CalculationResults ProcessCalculationAsync()
        {
            if (registrationPoints.Count > 1)
                return new CalculationResults(GetResultsForPointsAsync(registrationPoints));
            else
                return ProcessCalculation();
        }
        private IList<CalculationResultForPoint> GetResultsForPointsAsync(IList<Point3D> points)
        {
            var pointResults = new List<CalculationResultForPoint>(points.Count);
            Parallel.For(0,points.Count, (i) =>
            {
                pointResults[i] = GetResultsForPoint(points[i]);
            });
            return pointResults;
        }

        private IList<CalculationResultForPoint> GetResultsForPoints(IList<Point3D> points)
        {
            var pointResults = new List<CalculationResultForPoint>();
            foreach (var point in points)
                pointResults.Add(GetResultsForPoint(point));
            return pointResults;
        }

        private CalculationResultForPoint GetResultsForPoint(Point3D point)
        {
            List<CalculationResultItem> items = new();
            for (int i = 0; i < sourceEnergies.Count; i++)
                items.Add(
                    GetResultForEnergy(sourceEnergies[i].Energy, point));
            return new CalculationResultForPoint(point, items);
        }

        /// <summary>
        /// Возвращает результат расчета для заданной энергии
        /// </summary>
        /// <param name="energy"></param>
        /// <returns></returns>
        private CalculationResultItem GetResultForEnergy(float energy, Point3D point)
        {
            //Интерполируем коэффициенты для текущей энергии
            double fluxToKermaFactor = interpolatorService.GetFluxToKermaConversionFactor(energy);
            double kermaToDoseFactor = interpolatorService.GetKermaToDoseConversionFactor(energy);
            //Обновляем коэффициенты для расчета фактора накопления на новые коэффициенты
            coefficients_provider.UpdateCoefficients(interpolatorService.GetBuildupFactorsByLayer(energy));
            //Выполняем расчет
            double flux_rate = calcGeometry.CalculateFluxRate(point);
            return new CalculationResultItem(
                energy,
                flux_rate,
                fluxToKermaFactor,
                kermaToDoseFactor);
        }
    }
}
