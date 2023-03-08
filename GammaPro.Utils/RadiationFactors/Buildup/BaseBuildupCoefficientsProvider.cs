using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GammaPro.Utils.RadiationFactors.Buildup
{
    public class BaseBuildupCoefficientsProvider : IBuildupCoefficientsProvider
    {
        public float[] GetCoefficients(int layerIndex)
        {
            throw new NotImplementedException();
        }

        public int GetLayersCount()
        {
            throw new NotImplementedException();
        }

        public void UpdateCoefficients(float[][] newCoefficients)
        {
            throw new NotImplementedException();
        }
    }
}
