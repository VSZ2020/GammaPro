using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GammaPro.Controller.Database.Entries
{
    /// <summary>
    /// Описывает структуру таблицы с коэффициентами для формулы Тейлора в двухэкспоненциальном приближении
    /// </summary>
    public class Taylor2ExpFactorEntry: IBuildupEntry
    {
        public int Id { get; set; }

        /// <summary>
        /// Материал к которому относится набор коэффициентов
        /// </summary>
        public MaterialEntry? Material { get; set; }
        public int MaterialId { get; set; }

        /// <summary>
        /// Табличная энергия излучения
        /// </summary>
        public float Energy { get; set; }

        /// <summary>
        /// Первый коэффициент
        /// </summary>
        public float A1 { get; set; }
        public float Alpha1 { get; set; }
        public float Alpha2 { get; set; }

        /// <summary>
        /// Поправка на барьерность
        /// </summary>
        public float BarrierFactor { get; set; }

        public IEnumerable<float> GetFactors() => new List<float>() { A1, Alpha1, Alpha2, BarrierFactor };
    }
}
