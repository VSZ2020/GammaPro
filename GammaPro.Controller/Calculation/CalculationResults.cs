using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GammaPro.Controller.Calculation
{
    public class CalculationResults
    {
        public IList<CalculationResultForPoint> ResultsForPoint { get; private set; }
        public int ResultsCount => ResultsForPoint.Count;
        public CalculationResultForPoint this[int index]
        {
            get 
            {
                if (index < 0 || index >= ResultsForPoint.Count)
                    throw new ArgumentOutOfRangeException(
                        $"Index of ResultsForPoint array is out of range! Index is {index}, but array size is {ResultsForPoint.Count}");
                return ResultsForPoint[index];
            }
        }
        public CalculationResults(IList<CalculationResultForPoint> resultsForPoint)
        {
            if (resultsForPoint == null)
                throw new ArgumentNullException("ResultsForPoint list is NULL");
            this.ResultsForPoint = resultsForPoint;
        }
    }
}
