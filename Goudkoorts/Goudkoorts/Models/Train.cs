using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Models
{
    class Train
    {
        public Char Symbol;
        public int Load;

        public Train()
        {
            Load = 1;
            this.Symbol = '#';
        }
    }
}
