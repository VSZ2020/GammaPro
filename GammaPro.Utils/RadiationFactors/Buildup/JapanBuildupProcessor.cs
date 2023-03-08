using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GammaPro.Utils.RadiationFactors.Buildup
{
    public class JapanBuildupProcessor : BaseBuildupProcessor
    {
        /// <summary>
        /// Провайдер коэффициентов
        /// </summary>
        private readonly IBuildupCoefficientsProvider coeffs_provider;

        private const double tanh2_1 = 1.96402758007581688395;
        private const double tanh2 = -0.96402758007581688395;
        /// <summary>
        /// Рассчитывает фактор накопления по формуле Японцев
        /// </summary>
        /// <param name="ud">Произведение коэффициента ослабления и толщины</param>
        /// <returns></returns>
        public new double GetBuildupFactor(double ud, int layerIndex, bool isIncludeBarrierFactor = false)
        {
            float[] coefficients = coeffs_provider.GetCoefficients(layerIndex);
            double K = coefficients[2] * Math.Pow(ud, coefficients[0]) + coefficients[3] * (Math.Tanh(ud / coefficients[4] - 2.0) - tanh2) / tanh2_1;
            double buildup = (K == 1) ? 1.0 + (coefficients[1] - 1.0) * ud : 1.0 + (coefficients[1] - 1.0) * (Math.Pow(K, ud) - 1.0) / (K - 1.0);
            return buildup * ((isIncludeBarrierFactor) ? coefficients[5] : 1.0);
        }

        public JapanBuildupProcessor(IBuildupCoefficientsProvider coeffs_provider): base(coeffs_provider)
        {
            if (!CheckCoefficientsCount(coeffs_provider, 6))
                throw new ArgumentException("Japan coefficients count is incorrect. Check array!");
            this.coeffs_provider = coeffs_provider;
        }

    }
}
