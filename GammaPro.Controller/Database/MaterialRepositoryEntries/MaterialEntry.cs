using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GammaPro.Controller.Database.Entries
{
    public class MaterialEntry
    {
        public int ID { get; set; }
        public float Z { get; set; }
        public string Name { get; set; }
        public float Weight { get; set; }
        public float Density { get; set; }
        public IList<MaterialEntry>? Compound { get; private set; }

        public MaterialEntry(int id, float z, float weight, float density, string name)
        {
            ID = id;
            Z = z;
            Weight = weight;
            Density = density;
            Name = name;
        }
        public MaterialEntry()
        {

        }
        /// <summary>
        /// Устанавливает составные вещества материала
        /// </summary>
        /// <param name="materials"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Исключение возникает при null-значении materials</exception>
        public MaterialEntry SetCompound(IList<MaterialEntry> materials)
        {
            if (materials == null)
                throw new ArgumentNullException($"Material ({Name}) compound can't be null!");
            Compound = materials;
            return this;
        }
    }
}
