using GammaPro.Controller.Buildup;
using GammaPro.Controller.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GammaPro.Controller.Calculation
{
    /// <summary>
    /// Класс с набором обязательных входных данных для расчета
    /// </summary>
    public class CalculationGeometryInput
    {
        public CancellationToken Token;
        public IGeometryDimensions Dimensions { get; private set; }
        public IComplexBuildupProcessor? BuildupComplexProcessor { get; private set; }
        public IList<IShieldLayer> ShieldLayers { get; private set; }

        public CalculationGeometryInput(
            IGeometryDimensions dimensions, 
            IComplexBuildupProcessor? buildupProcessor,
            IList<IShieldLayer> shield_layers,
            CancellationToken token)
        {
            if (dimensions == null)
                throw new ArgumentNullException("The dimensions argument is NULL");
            if (shield_layers == null)
                throw new ArgumentNullException("The shield layers array is NULL");

            this.Dimensions = dimensions;
            this.BuildupComplexProcessor = buildupProcessor;
            this.ShieldLayers = shield_layers;
            this.Token = token;
        }
    }
}
