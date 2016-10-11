using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Models
{
    class StartSpace : Space
    {
        public StartSpace(String start)
        {
            this.Symbol = start + ":_";
        }
    }
}
