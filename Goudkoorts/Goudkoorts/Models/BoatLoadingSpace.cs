using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Models
{
    class BoatLoadingSpace : Space
    {
        public BoatLoadingSpace()
        {
            this.Symbol = ":K ~ :";
        }
        public override String GetSymbol()
        {
            String symbol = this.Symbol;
            if (Boat != null)
            {
                symbol = "K:" + Boat.Symbol + ":";
            }
            return symbol;
        }

        public override Boolean Move()
        {
            if (this.Boat != null && this.Boat.isFull && this.Next.Boat == null && this.Next.Previous == this)
            {
                this.Next.Boat = this.Boat;
                this.Boat = null;
            }
            return true;
        }
    }
}
