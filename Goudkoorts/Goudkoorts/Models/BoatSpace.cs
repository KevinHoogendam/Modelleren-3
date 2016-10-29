using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Models
{
    class BoatSpace : Space
    {
        public BoatSpace()
        {
            this.Symbol = " ~ ";
        }

        public override String GetSymbol()
        {
            String symbol = this.Symbol;
            if (Boat != null)
            {
                symbol = Boat.Symbol;
            }
            return symbol;
        }

        public override Boolean Move()
        {
            if (this.Boat != null)
            {
                if(this.Next != null)
                {
                    if (this.Next.Boat == null && this.Next.Previous == this)
                    {
                        this.Next.Boat = this.Boat;
                        this.Boat = null;
                    }
                }
                else
                {
                    this.Boat = null;
                }
            }
            return true;
        }
    }
}
