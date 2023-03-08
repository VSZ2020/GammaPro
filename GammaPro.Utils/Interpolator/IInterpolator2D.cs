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
        float[] InterpolateXY(PointF[] XYPoints, float[] new_x_values);
        float GetValue(float x);
        PointF[] OrderPoints(PointF[] array);
    }
}
