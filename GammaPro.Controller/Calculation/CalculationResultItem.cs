using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GammaPro.Controller.Calculation
{
    /// <summary>
    /// Результат единичного расчета
    /// </summary>
    public class CalculationResultItem
    {
        private readonly double kermaToDoseFactor;
        private readonly double fluxToKermaFactor;
        public double Energy { get; private set; }
        public double FluxRate { get; private set; }
        public double AirKerma { get => FluxRate * fluxToKermaFactor; }
        public double EffectiveDose { get => AirKerma * kermaToDoseFactor; }
        public CalculationResultItem(double energy, double flux_rate, double fluxToKermaFactor, double kermaToDoseFactor)
        {
            this.Energy = energy;
            this.FluxRate = flux_rate;
            this.fluxToKermaFactor = fluxToKermaFactor;
            this.kermaToDoseFactor = kermaToDoseFactor;
        }
    }
}
