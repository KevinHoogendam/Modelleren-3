using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class Space
    {
        public Space next;
        public Space previous;

        public Train train;

        public String symbol;

        public string GetSymbol()
        {
            String currentSymbol;
            if(train == null)
            {
                currentSymbol = symbol;
            }
            else
            {
                currentSymbol = train.symbol;
            }
            return currentSymbol;
        }
    }
}
