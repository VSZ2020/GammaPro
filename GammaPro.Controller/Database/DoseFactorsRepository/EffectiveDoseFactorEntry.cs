using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GammaPro.Controller.Database.DoseFactorsRepository
{
    public class EffectiveDoseFactorEntry
    {
        public int Id { get; set; }
        public int OrganTissueId { get; set; }
        public OrganTissueEntry OrganTissue {get;set;}
        public float ConversionFactor { get; set; }
    }
}
