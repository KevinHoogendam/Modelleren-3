using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Models
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
            if(!isFull)
            {
                Load = Load + trainLoad;
                if (Load == 1)
                {
                    this.Symbol = "0OO";
                }
                else if (Load >= (Capacity / 2) && Load < Capacity)
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
}
