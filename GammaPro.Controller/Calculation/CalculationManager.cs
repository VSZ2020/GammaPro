using GammaPro.Controller.Buildup;
using GammaPro.Controller.Geometry;
using GammaPro.Controller.Services;
using GammaPro.Geometry;
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
        private readonly CancellationToken token;
        private IBuildupCoefficientsProvider coefficients_provider;

        public CalculationManager(
            ICalculationGeometry geometry, 
            InterpolatorService service, 
            IBuildupCoefficientsProvider coefficients_provider,
            CancellationToken token)
        {
            if (geometry == null)
                throw new ArgumentNullException("Calculation geometry is NULL!");
            if (service is null)
                throw new ArgumentNullException("Interpolator 2D handler has NULL reference");
            if (coefficients_provider == null)
                throw new ArgumentNullException("Coefficients provider is NULL");
            this.calcGeometry = geometry;
            this.interpolatorService = service;
            this.coefficients_provider = coefficients_provider;
            this.token = token;
        }

        public CalculationResults ProcessCalculation()
        {
            int energiesCount = sourceEnergies.Count;

            for (int i = 0; i < energiesCount; i++)
            {
                //Подготавливаем интерполированные коэффициенты
                float current_energy = sourceEnergies[i].Energy;
                //Интерполируем коэффициенты для энергии
                float[][] updated_values; // = bla bla bla

                //Обновляем коэффициенты на новые
                coefficients_provider.UpdateCoefficients(updated_values);

                //Выполняем расчет
                double flux_rate = calcGeometry.CalculateFluxRate();
                
            }
            throw new NotImplementedException();
        }

        public async Task<CalculationResults> ProcessCalculationAsync()
        {
            throw new NotImplementedException();
        }

        private void LoadShieldMaterials()
        {
            
        }
    }
}
