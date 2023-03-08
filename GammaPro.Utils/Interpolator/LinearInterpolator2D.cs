using System.Diagnostics;
using System.Drawing;

namespace GammaPro.Utils.Interpolator
{
    public class LinearInterpolator2D : IInterpolator2D
    {
        private readonly PointF[] XY0;
        private float[] slopes;
        private float[] intercepts;

        public LinearInterpolator2D(PointF[] XYPoint)
        {
            if (XYPoint == null)
                throw new ArgumentNullException("The X and Y points array is NULL!");
            if (XYPoint.Length < 2)
                throw new ArgumentException("The array size must be greater 1");
            this.XY0 = OrderPoints(XYPoint);
            this.GetSlopesAndIntercepts();
        }

        public float[] InterpolateXY(PointF[] XYPoints, float[] new_x_values)
        {
            if (XYPoints == null)
                throw new ArgumentNullException("Input XYPair array is NULL");
            if (new_x_values == null)
                throw new ArgumentNullException("New X values array is NULL");
            if (XYPoints.Length < 2)
                throw new ArgumentException("XYPoints array size is too small! It has to be at least 2 values.");
            int source_length = XYPoints.Length;
            int new_data_length = new_x_values.Length;
            //Новые значения Y
            float[] newY = new float[new_data_length];
            //Массив коэффициентов наклона промежуточных участков (интервалов) массива исходных точек
            float[] slopes = new float[source_length - 1];
            //Массив коэффициентов смещения для промежуточных участков (интервалов) массива исходных точек
            float[] intercepts = new float[source_length - 1];
            for (int i = 0; i < source_length - 1; i++)
            {
                //Рассчитываем предварительно параметры slope и intercept уравнения прямой
                slopes[i] = (XYPoints[i + 1].Y - XYPoints[i].Y) / (XYPoints[i + 1].X - XYPoints[i].X);
                intercepts[i] = XYPoints[i].Y - slopes[i] * XYPoints[i].X;
                Debug.WriteLine($"slope: {slopes[i]}, intercept: {intercepts[i]}");
            }

            //Количество итераций равно количеству интервалов
            for (int i = 0; i < source_length - 1; i++)
                //Массив по каждой новой координате
                for (int j = 0; j < new_data_length; j++)
                {
                    //Если новое значение в пределах текущего интервала массива исходной функции, то рассчитываем новое значение Y по новому значению X
                    if (XYPoints[i].X < new_x_values[j] && new_x_values[j] <= XYPoints[i + 1].X)
                        newY[j] = slopes[i] * new_x_values[j] + intercepts[i];

                    //Если новое значение точки левее нижней границы значений X исходной функции, то экстраполируем по последнему интервалу
                    else if (new_x_values[j] < XYPoints[0].X)
                        newY[j] = slopes[0] * new_x_values[j] + intercepts[0];
                    //Если новое значение точки правее верхней границы значений X исходной функции, то экстраполируем по параметрам крайнего интервала
                    else if (new_x_values[j] > XYPoints[^1].X)
                        //TODO: Код может быть медленным, из-за использования Индексов!!!
                        newY[j] = slopes[^1] * new_x_values[j] + intercepts[^1];

                }
            return newY;
        }
        public PointF[] OrderPoints(PointF[] array)
        {
            return array.OrderBy(a => a.X).ToArray();
        }

        public float GetValue(float x)
        {
            int x_value_index = GetXValueIndex(x);
            return slopes[x_value_index] * x + intercepts[x_value_index];
        }

        public int GetXValueIndex(float x)
        {
            int index = 0;
            if (x < XY0[0].X)
                return 0;
            if (x > XY0[^1].X)
                return slopes.Length - 1;
            for (int i = 0; i < slopes.Length; i++)
                if (XY0[i].X < x && x <= XY0[i + 1].X)
                    return i;
            return index;
        }
        private void GetSlopesAndIntercepts()
        {
            int intervals_count = XY0.Length - 1;
            slopes = new float[intervals_count];
            intercepts = new float[intervals_count];
            for (int i = 0; i < intervals_count; i++)
            {
                slopes[i] = (XY0[i + 1].Y - XY0[i].Y) / (XY0[i + 1].X - XY0[i].X);
                intercepts[i] = XY0[i].Y - slopes[i] * XY0[i].X;
            }
        }

        public double GetDeterminationFactor(float[] y)
        {
            throw new NotImplementedException();
        }
    }
}
