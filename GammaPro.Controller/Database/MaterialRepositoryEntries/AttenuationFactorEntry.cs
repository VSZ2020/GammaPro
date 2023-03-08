using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GammaPro.Controller.Database.Entries
{
    /// <summary>
    /// Описание сущность коэффициента ослабления в базе данных
    /// </summary>
    public class AttenuationFactorEntry
    {
        public int Id { get; set; }
        /// <summary>
        /// Материал, к которому относится набор коэффициентов
        /// </summary>
        public MaterialEntry? Material { get; set; }
        public int MaterialId { get; set; }

        /// <summary>
        /// Энергия излучения (МэВ)
        /// </summary>
        public float Energy { get; set; }

        /// <summary>
        /// Значение коэффициента в массовых единицах (см^2/г)
        /// </summary>
        public float MassValue { get; set; }

    }
}
