using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GammaPro.Utils.RadiationFactors.Buildup
{
    public class BaseBuildupCoefficientsProvider : IBuildupCoefficientsProvider
    {
        private float[][] coeffs;
        public float[] GetCoefficients(int layerIndex)
        {
            return coeffs[layerIndex];
        }

        public int GetLayersCount() => coeffs.Length;

        public void UpdateCoefficients(float[][] newCoefficients)
        {
            if (newCoefficients == null)
                throw new ArgumentNullException("New coefficients array is NULL. It's impossible replace old factors to new one");
            coeffs = newCoefficients;
        }

        public BaseBuildupCoefficientsProvider(float[][] coefficients)
        {
            if (coefficients == null)
                throw new ArgumentNullException("Coefficients array is NULL");
            this.coeffs = coefficients;
        }

    }
}
