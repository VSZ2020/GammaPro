using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GammaPro.Controller.Database.DoseFactorsRepository
{
    public class GeometryDoseFactorEntry
    {
        public int Id { get; set; }
        public int GeometryId { get; set; }
        public ExposureGeometryEntry Geometry { get; set; }
        public float ConversionFactor { get; set; }
    }
}
