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
        public Boat Boat;
        public String Symbol;

        public string GetSymbol()
        {
            String currentSymbol = Symbol;
            if (Train != null)
            {
                if (Symbol.Contains('_'))
                {
                    currentSymbol = Symbol.Replace('_', Train.Symbol);
                }
            }
            else if (Boat != null)
            {
                if (Symbol.Equals(" ~ "))
                {
                    currentSymbol = Boat.Symbol;
                }
                else if (Symbol.Equals(":K ~ :"))
                {
                    currentSymbol = "K:" + Boat.Symbol + ":";
                }
            }
            return currentSymbol;
        }
    }
}
