using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class Boat
    {
        public String Symbol;
        public int Load;
        public int Capacity;
        public bool isFull;

        public Boat()
        {
            Load = 0;
            Capacity = 8;
            isFull = false;
            this.Symbol = "OOO";
        }

        public void AddLoad(int trainLoad)
        {
            Load = Load + trainLoad;
            if (Load > 0)
            {
                this.Symbol = "0OO";
            }
            else if(Load >=4)
            {
                this.Symbol = "00O";
            }
            else if (Load == Capacity)
            {
                this.Symbol = "000";
                isFull = true;
            }
        }
    }
}
