using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GammaPro.Controller.Database.Entries
{
    public class JapanFactorEntry: IBuildupEntry
    {
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор материала, к котору относится набор коэффициентов
        /// </summary>
        public MaterialEntry? Material { get; set; }
        public int MaterialId { get; set; }

        /// <summary>
        /// Энергия излучения
        /// </summary>
        public float Energy { get; set; }
        public float a { get; set; }
        public float b { get; set; }
        public float c { get; set; }
        public float d { get; set; }
        public float xi { get; set; }
        public float BarrierFactor { get; set; }

        public IEnumerable<float> GetFactors() => new List<float>() { a, b, c, d, xi, BarrierFactor };
    }
}
