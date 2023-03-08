using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GammaPro.Controller.Database
{
    public interface IBuildupEntry
    {
        IEnumerable<float> GetFactors();
    }
}
