using GammaPro.Controller.Database.Entries;
using GammaPro.Utils.RadiationFactors.Buildup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GammaPro.Controller.Database
{
    public interface IMaterialRepository
    {
        /// <summary>
        /// Возвращает список доступных материалов из базы данных
        /// </summary>
        /// <returns></returns>
        IEnumerable<MaterialEntry> GetMaterialsList();

        /// <summary>
        /// Возвращает материал по его ID
        /// </summary>
        /// <param name="id">Идентификатор материала</param>
        /// <returns></returns>
        MaterialEntry GetMaterialById(int id);

        /// <summary>
        /// Возвращает список материалов по списку их ID
        /// </summary>
        /// <param name="ids">Список идентификаторов материала</param>
        /// <returns></returns>
        IEnumerable<MaterialEntry> GetMaterialsByIds(IList<int> ids);

        /// <summary>
        /// Возвращает список коэффициентов для расчета фактора накопления
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        IEnumerable<IBuildupEntry> GetBuildupFactors(int materialId, BuildupType type);

        /// <summary>
        /// Возвращает список коэффициентов для расчета фактора накопления по каждому заданному материалу
        /// </summary>
        /// <param name="materialsIds">Список Id материалов</param>
        /// <param name="type">Тип фактора накопления, к которому относятся коэффициенты</param>
        /// <returns></returns>
        IEnumerable<IEnumerable<IBuildupEntry>> GetBuildupFactors(IList<int> materialsIds, BuildupType type);

        IEnumerable<AttenuationFactorEntry> GetAttenuationFactors(int materialId);

        IEnumerable<IEnumerable<AttenuationFactorEntry>> GetAttenuationFactors(IList<int> materialIds);
    }
}
