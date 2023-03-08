using GammaPro.Geometry.Point;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GammaPro.Controller.Geometry
{
    public class Vector3D
    {
        public Point3D StartPoint { get; }
        public Point3D EndPoint { get; }
        public double GetLength()
        {
            float sumOfSquares =
                (EndPoint.X - StartPoint.X) * (EndPoint.X - StartPoint.X) +
                (EndPoint.Y - StartPoint.Y) * (EndPoint.Y - StartPoint.Y) +
                (EndPoint.Z - StartPoint.Z) * (EndPoint.Z - StartPoint.Z);
            return Math.Sqrt(sumOfSquares);
        }

        public Vector3D(Point3D start_point, Point3D end_point)
        {
            StartPoint = start_point;
            EndPoint = end_point;
        }
    }
}
