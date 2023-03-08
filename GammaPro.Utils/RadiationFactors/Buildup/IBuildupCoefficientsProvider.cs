using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GammaPro.Utils.RadiationFactors.Buildup
{
    public interface IBuildupCoefficientsProvider
    {
        float[] GetCoefficients(int layerIndex);
        int GetLayersCount();
        void UpdateCoefficients(float[][] newCoefficients);
        
    }
}
