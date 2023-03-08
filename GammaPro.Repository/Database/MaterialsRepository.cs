using GammaPro.Controller.Database;
using GammaPro.Controller.Database.Entries;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GammaPro.Repository.Database
{
    public class MaterialsRepository : IMaterialRepository
    {
        private readonly MaterialsContext materialsContext;

        public MaterialsRepository(MaterialsContext materials_context)
        {
            if (materials_context == null)
                throw new ArgumentNullException($"{nameof(materials_context)} has NULL reference!");
            materialsContext = materials_context;
        }

        public MaterialEntry GetMaterialById(int id)
        {
            MaterialEntry exported_material;
            using (var mat_ctx = materialsContext.GetInstance())
                exported_material = mat_ctx.Materials.Where(mat => mat.ID == id).FirstOrDefault();
            return exported_material;
        }

        public IEnumerable<MaterialEntry> GetMaterialsByIds(IList<int> ids)
        {
            //TODO: Realize method
            throw new NotImplementedException();
        }

        public IEnumerable<MaterialEntry> GetMaterialsList()
        {
            IEnumerable<MaterialEntry> exported_materials;
            using (var mat_ctx = materialsContext.GetInstance())
                exported_materials = mat_ctx.Materials.ToImmutableList();
            return exported_materials;
        }
    }
}
