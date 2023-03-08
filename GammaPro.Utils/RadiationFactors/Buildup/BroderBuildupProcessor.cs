using GammaPro.Controller.Buildup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GammaPro.Utils.RadiationFactors.Buildup
{
    public class BroderBuildupProcessor : IComplexBuildupProcessor
    {
        private readonly IBuildupProcessor processor;
        private readonly int layersCount;

        public double GetBuildupFactor(double[] ud, bool isIncludeBarrierFactor = false)
        {
            //Первое слагаемое формулы Бродера
            double firstBuildup = processor.GetBuildupFactor(ud.Sum(), layersCount - 1, isIncludeBarrierFactor);
            //Остальные слагаемые формулы Бродера
            double buildupSum = 0;
            for (int i = 0; i < layersCount - 1; i++)
            {
                double sumUD = 0;
                for (int j = 0; j <= i; j++)
                    sumUD += ud[j];
                buildupSum += processor.GetBuildupFactor(sumUD, i, isIncludeBarrierFactor) - processor.GetBuildupFactor(sumUD, i + 1, isIncludeBarrierFactor);
            }
            return firstBuildup + buildupSum;
        }

        public BroderBuildupProcessor(IBuildupProcessor processor, int layersCount)
        {
            if (processor == null)
                throw new ArgumentNullException("Buildup processor is NULL!");
            //if (coefficients == null)
            //    throw new ArgumentNullException("The coefficients array is NULL!");
            //if (coefficients.Length < 1)
            //    throw new ArgumentException("The coefficients array length less than 1. It should be greather than 0");
            this.processor = processor;
            //this.coefficients = coefficients;
            this.layersCount = layersCount;
        }

        
    }
}
