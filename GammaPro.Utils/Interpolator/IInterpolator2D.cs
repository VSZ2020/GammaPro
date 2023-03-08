using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GammaPro.Utils.Interpolator
{
    public interface IInterpolator2D
    {
        float[] InterpolateXY(PointF[] XYPoints, float[] new_x);
        float GetValue(float x);
        PointF[] OrderPoints(PointF[] unsorted_xy);
        /// <summary>
        /// Рассичтывает коэффициент детерминации R^2
        /// </summary>
        /// <param name="y">массив значений, с которым происходит сравнение и вычисление</param>
        /// <returns>Числовое значение коэффициента детерминации</returns>
        double GetDeterminationFactor(float[] y);
    }
}
