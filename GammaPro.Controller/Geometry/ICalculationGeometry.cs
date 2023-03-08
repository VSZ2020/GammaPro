using GammaPro.Controller.Buildup;
using GammaPro.Geometry.Point;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GammaPro.Controller.Geometry
{
    public interface ICalculationGeometry
    {
        /// <summary>
        /// Возвращает плотность потока
        /// </summary>
        /// <returns></returns>
        double CalculateFluxRate();

        double CalculateFluxRate(Point3D destinationPoint);
        ICalculationGeometry UpdateAttenuationFactors(float[] new_factors);
    }
}
