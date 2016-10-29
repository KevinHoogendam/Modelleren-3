using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Models
{
    abstract class Space
    {
        public Space Next
        {
            get;
            set;
        }
        public Space Previous
        {
            get;
            set;
        }
        public String Symbol
        {
            get;
            set;
        }

        public Train Train
        {
            get;
            set;
        }

        public Boat Boat
        {
            get;
            set;
        }

        public abstract String GetSymbol();

        public abstract Boolean Move();
        
    }
}
