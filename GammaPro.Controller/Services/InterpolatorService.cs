using GammaPro.Utils.Interpolator;

namespace GammaPro.Controller.Services
{
    public class InterpolatorService
    {
        /// <summary>
        /// первый уровень - слой, второй - тип коэффициента
        /// </summary>
        private readonly IList<IList<IInterpolator2D>> buildupInterpolators;
        private readonly IList<IInterpolator2D> attenuationInterpolators;
        private readonly IList<IInterpolator2D> absorptionInterpolators;
        private readonly IInterpolator2D fluxToDoseInterpolator;
        private readonly IInterpolator2D effectiveDoseInterpolator;
        /// <summary>
        /// Базовый конструктор класса
        /// </summary>
        /// <param name="attenuationInterpolators">Набор интерполяторов для каждого материала слоя ослабления</param>
        /// <param name="absorptionInterpolators">Набор интерполяторов для каждого материала слоя поглощения</param>
        /// <param name="fluxToDoseInterpolator">Интерполятор для коэффициента перехода от плотности потока к керме для выбранной геометрии</param>
        /// <param name="effectiveDoseInterpolator">Интерполятор для коэффициента перехода от эквивалентной дозы к эффективной для выбранного органа</param>
        /// <param name="buildupInterpolators">Набор интерполяторов для каждого слоя материала (внешний уровень) и типа коэффициента (внутренний уровень)</param>
        public InterpolatorService(
            IList<IInterpolator2D> attenuationInterpolators,
            IList<IInterpolator2D> absorptionInterpolators,
            IInterpolator2D fluxToDoseInterpolator,
            IInterpolator2D effectiveDoseInterpolator,
            IList<IList<IInterpolator2D>> buildupInterpolators
            )
        {
            this.attenuationInterpolators = attenuationInterpolators;
            this.absorptionInterpolators = absorptionInterpolators;
            this.buildupInterpolators = buildupInterpolators;
            this.fluxToDoseInterpolator = fluxToDoseInterpolator;
            this.effectiveDoseInterpolator = effectiveDoseInterpolator;
        }
        /// <summary>
        /// Возвращает набор интерполированных коэффициентов для фактора накопления по слоям защиты
        /// </summary>
        /// <param name="energy"></param>
        /// <returns></returns>
        public float[][] GetBuildupFactorsByLayer(float energy)
        {
            int coefficients_count = 0;
            int layers_count = buildupInterpolators.Count;
            float[][] output_array = new float[layers_count][];
            for (int i = 0; i < layers_count;  i++)
            {
                output_array[layers_count] = new float[coefficients_count];
                for (int j = 0; j < coefficients_count; j++)
                    output_array[i][j] = buildupInterpolators[i][j].GetValue(energy);
            }
            return output_array;
        }
        /// <summary>
        /// Возвращает набор интерполированных значений коэффициентов ослабления по слоям защиты
        /// </summary>
        /// <param name="energy">Энергия, для которой выполняется интерполяция</param>
        /// <returns></returns>
        public float[] GetAttenuationFactorsByLayer(float energy) => attenuationInterpolators.Select(interp => interp.GetValue(energy)).ToArray();

        /// <summary>
        /// Возвращает набор интерполированных коэффициентов поглощения по слоям защиты
        /// </summary>
        /// <param name="energy">Энергия, для которой выполняется интерполяция</param>
        /// <returns></returns>
        public float[] GetAbsorptionFactorsByLayer(float energy) => absorptionInterpolators.Select(interp => interp.GetValue(energy)).ToArray();


        /// <summary>
        /// Возвращает интерполированный для заданной энергии коэффициент перехода от плотности потока к воздушной керме
        /// </summary>
        /// <param name="energy">Энергия, для которой выполняется интерполяция</param>
        /// <returns></returns>
        public double GetFluxToKermaConversionFactor(float energy) => fluxToDoseInterpolator.GetValue(energy);

        /// <summary>
        /// Возвращает интерполированный для заданной энергии коэффициент перехода от воздушной кермы к эффективной дозе
        /// </summary>
        /// <param name="energy">Энергия, для которой выполняется интерполяция</param>
        /// <returns></returns>
        public double GetKermaToDoseConversionFactor(float energy) => effectiveDoseInterpolator.GetValue(energy);
    }
}
