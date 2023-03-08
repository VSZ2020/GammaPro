using GammaPro.Controller.Database;
using GammaPro.RadiationSource;
using GammaPro.Utils.Interpolator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GammaPro.Controller.Services
{
    public class InterpolatorService
    {
        private readonly IInterpolator2D interpolator;
        private readonly IMaterialRepository repository;
        private readonly IList<int> materialsIds;
        public InterpolatorService(
            IInterpolator2D interpolator,
            IMaterialRepository repository, 
            IList<int> materialsIds)
        {
            this.interpolator = interpolator;
            this.repository = repository;
            this.materialsIds = materialsIds;
        }

        public float[][] GetBuildupFactories(float energy)
        {
            int factors_count = 0;
            int layers_count = materialsIds.Count;
            float[][] coeffs = new float[layers_count][];
            for (int i = 0; i < layers_count; i++)
            {
                
                coeffs[i] = new float[factors_count];
            }
            //TODO
            return coeffs;
        }

        public double GetAttenuationFactor(int materialId, float energy)
        {

        }
    }
}
