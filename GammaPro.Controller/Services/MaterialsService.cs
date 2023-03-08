using GammaPro.Controller.Database;
using GammaPro.Controller.Database.Entries;
using GammaPro.Controller.Geometry;
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
        private readonly InterpolatorService interpolatorService;

        public MaterialsService(
            IMaterialRepository mat_rep,
            InterpolatorService service)
        {
            if (mat_rep == null)
                throw new ArgumentNullException($"{nameof(mat_rep)} is NULL!");
            this.materialRep = mat_rep;
            this.interpolatorService = service;
        }

        
    }
}
