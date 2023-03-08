using GammaPro.Controller.Database;
using GammaPro.Controller.Database.Entries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GammaPro.Controller.Services
{
    public class MaterialsService
    {
        private readonly IMaterialRepository materialRep;


        public MaterialsService(IMaterialRepository mat_rep)
        {
            if (mat_rep == null)
                throw new ArgumentNullException($"{nameof(mat_rep)} is NULL!");
            materialRep = mat_rep;
        }

        
    }
}
