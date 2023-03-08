using GammaPro.Geometry.Point;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GammaPro.Controller.Calculation
{
    public class CalculationResultForPoint
    {
        public Point3D CalculationPoint { get; private set; }
        public IList<CalculationResultItem> ResultsForEnergy { get; private set; }
        public string PointToString()
            => $"({CalculationPoint.X}, {CalculationPoint.Y}, {CalculationPoint.Z})";
        public double[][] ResultsToNDArray()
        {
            throw new NotImplementedException();
        }
        public CalculationResultForPoint(Point3D calculationPoint, IList<CalculationResultItem> resultsForEnergy)
        {
            if (resultsForEnergy == null)
                throw new ArgumentNullException("Calculation results List<> for each energy can't be NULL");

            this.CalculationPoint = calculationPoint;
            this.ResultsForEnergy = resultsForEnergy;
        }
    }
}
