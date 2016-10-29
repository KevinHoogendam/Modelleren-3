using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Models
{
    class QuaySpace : Space
    {
        public QuaySpace()
        {
            this.Symbol = ":K_:";
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
            if (this.Train != null && this.Next.Previous == this)
            {
                if (this.Next.Train == null)
                {
                    this.Next.Train = this.Train;
                    this.Train = null;
                }
                else
                {
                    this.Train = null;
                    this.Next.Train.Symbol = 'X';
                    return false;
                }
            }
            return true;
        }
    }
}
