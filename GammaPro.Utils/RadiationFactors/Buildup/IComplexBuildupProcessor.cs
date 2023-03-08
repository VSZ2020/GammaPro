using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GammaPro.Controller.Buildup
{
    public interface IComplexBuildupProcessor
    {
        /// <summary>
        /// Рассчитывает гетерогенный фактор накопления
        /// </summary>
        /// <param name="ud">Массив произведений коэффициента ослабления и толщины слоя</param>
        /// <param name="isIncludeBarrierFactor">Флаг учета барьерности геометрии</param>
        /// <returns></returns>
        double GetBuildupFactor(double[] ud, bool isIncludeBarrierFactor = false);
       
    }
}
