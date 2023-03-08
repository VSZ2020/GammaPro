using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GammaPro.Utils.RadiationFactors.Buildup
{
    public interface IBuildupProcessor
    {
        /// <summary>
        /// Рассчитывает фактор накопления по определенному методу
        /// </summary>
        /// <param name="ud">Произведение коэффициента ослабления на толщину слоя</param>
        /// <param name="layerIndex">Номер слоя для которого выполняется расчет</param>
        /// <returns></returns>
        double GetBuildupFactor(double ud, int layerIndex, bool isIncludeBarrierFactor = false);
        
    }
}
