using GammaPro.Controller.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GammaPro.Geometry.Cylinder
{
    public class CylinderDimensions : IGeometryDimensions
    {
        public float Height { get; set; }
        public float Radius { get; set; }

        public CylinderDimensions(float radius, float height)
        {
            Height = height;
            Radius = radius;
        }
    }
}
