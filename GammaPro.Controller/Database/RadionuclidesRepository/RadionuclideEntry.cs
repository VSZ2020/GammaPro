using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GammaPro.Controller.Database.RadionuclidesRepository
{
    public class RadionuclideEntry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double HalfLive { get; set; }
        
    }
}
