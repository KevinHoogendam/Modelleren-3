using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Models
{
    class EndSpace : Space
    {
        public EndSpace()
        {
            this.Symbol = "End:_";
        }

        public override String GetSymbol()
        {
            String symbol = this.Symbol;
            if (Train != null)
            {
                if (this.Symbol.Contains('_'))
                {
                    symbol = Symbol.Replace('_', Train.Symbol);
                }
            }
            return symbol;
        }

        public override Boolean Move()
        {
            if (this.Next == null)
            {
                this.Train = null;
            }
            return true;
        }
    }
}
