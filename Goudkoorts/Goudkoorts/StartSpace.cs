using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class StartSpace : Space
    {
        public StartSpace(String start)
        {
            this.symbol = start + ":_";
        }
    }
}
