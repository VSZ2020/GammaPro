using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GammaPro.Utils.RadiationFactors.Buildup
{
    public class Taylor2ExpBuildupProcessor : BaseBuildupProcessor
    {
        /// <summary>
        /// Провайдер коэффициентов
        /// </summary>
        private readonly IBuildupCoefficientsProvider coeffs_provider;

        /// <summary>
        /// Возвращает фактор накопления, рассчитанный по формуле Тейлора в двухэкспоненциальном приближении
        /// </summary>
        /// <param name="ud"></param>
        /// <param name="layerIndex"></param>
        /// <param name="isIncludeBarrierFactor"></param>
        /// <returns></returns>
        public new double GetBuildupFactor(double ud, int layerIndex, bool isIncludeBarrierFactor = false)
        {
            float[] coefficients = coeffs_provider.GetCoefficients(layerIndex);
            double buildup = coefficients[0] * Math.Exp(-coefficients[1] * ud) + (1 - coefficients[0]) * Math.Exp(-coefficients[2] * ud);
            return buildup * (isIncludeBarrierFactor ? coefficients[3] : 1.0);
        }
        
        /// <summary>
        /// Базовый конструктор класса
        /// </summary>
        /// <param name="coefficients">Двумерный массив коэффициентов</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Taylor2ExpBuildupProcessor(IBuildupCoefficientsProvider provider):base(provider)
        {
            if (!CheckCoefficientsCount(provider, 4))
                throw new ArgumentException("Taylor coefficients count is incorrect. Check array!");
            this.coeffs_provider = provider;
        }

        
    }
}
