using GammaPro.Controller.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GammaPro.Geometry.Parallelepiped
{
    public class ParallelepipedDimensions: IGeometryDimensions
    {
        public float Length { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        public ParallelepipedDimensions(float length, float width, float height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }
    }
}
