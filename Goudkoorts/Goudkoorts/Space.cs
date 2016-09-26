using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class Space
    {
        public Space Next;
        public Space Previous;
        public Train Train;
        public String Symbol;

        public string GetSymbol()
        {
            String currentSymbol;
            if (Train == null)
            {
                currentSymbol = Symbol;
            }
            else
            {
                if (Symbol.Contains('_'))
                {
                    currentSymbol = Symbol.Replace('_', Train.symbol);
                }
                else
                {
                    currentSymbol = Symbol;
                }
            }
            return currentSymbol;
        }
    }
}
