using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GammaPro.Utils.RadiationFactors.Buildup
{
    public class BaseBuildupProcessor : IBuildupProcessor
    {
        public double GetBuildupFactor(double ud, int layerIndex, bool isIncludeBarrierFactor = false)
        {
            return 1;
        }
        public BaseBuildupProcessor(IBuildupCoefficientsProvider coeffs_provides)
        {
            if (coeffs_provides == null)
                throw new ArgumentNullException("The coefficients provider is NULL!");
            if (coeffs_provides.GetLayersCount()< 1)
                throw new ArgumentException("The layers amount have to be greather than 0!");
        }

        /// <summary>
        /// Проверяет входящие аргументы
        /// </summary>
        /// <param name="coeffs">Массив коэффициентов</param>
        /// <param name="normal_coeff_count">Необходимое для работы количество коэффициентов</param>
        /// <returns></returns>
        public bool CheckCoefficientsCount(IBuildupCoefficientsProvider provider, int normal_coeff_count)
        {
            bool IsCoeffsCountCorrect = true;
            int layers_count = provider.GetLayersCount();
            for (int i = 0; i < layers_count; i++)
            {
                if (provider.GetCoefficients(i).Length < normal_coeff_count)
                {
                    IsCoeffsCountCorrect = false;
                    break;
                }
            }
            return IsCoeffsCountCorrect;
        }
    }
}
