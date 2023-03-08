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
        private readonly float[][] coefficients;

        /// <summary>
        /// Возвращает фактор накопления, рассчитанный по формуле Тейлора в двухэкспоненциальном приближении
        /// </summary>
        /// <param name="ud"></param>
        /// <param name="layerIndex"></param>
        /// <param name="isIncludeBarrierFactor"></param>
        /// <returns></returns>
        public new double GetBuildupFactor(double ud, int layerIndex, bool isIncludeBarrierFactor = false)
        {
            double buildup = coefficients[layerIndex][0] * Math.Exp(-coefficients[layerIndex][1] * ud) + (1 - coefficients[layerIndex][0]) * Math.Exp(-coefficients[layerIndex][2] * ud);
            return buildup * (isIncludeBarrierFactor ? coefficients[layerIndex][3] : 1.0);
        }
        
        /// <summary>
        /// Базовый конструктор класса
        /// </summary>
        /// <param name="coefficients">Двумерный массив коэффициентов</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Taylor2ExpBuildupProcessor(float[][] coefficients):base(coefficients)
        {
            if (CheckCoefficientsCount(coefficients, 4))
                throw new ArgumentException("Taylor coefficients count is incorrect. Check array!");
            this.coefficients = coefficients;
        }

        
    }
}
