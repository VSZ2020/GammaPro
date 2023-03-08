using GammaPro.Geometry.Point;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GammaPro.Controller.Geometry
{
    public class ShieldLayer
    {
        /// <summary>
        /// Идентификатор материала слоя защиты
        /// </summary>
        public int MaterialId { get; set; }
        public float Density { get; set; }
        public Point3D Position { get; set; }
        /// <summary>
        /// Возвращает эффективную толщину ослабления данного материала на пути от источника до точки измерения
        /// </summary>
        /// <param name="directionVector">Вектор направления от точки источника до точки измерения</param>
        /// <returns>Возвращает эффективную толщину</returns>
        public float GetEffectiveThickness(Vector3D directionVector)
        {
            throw new NotImplementedException();
        }
    }
}
