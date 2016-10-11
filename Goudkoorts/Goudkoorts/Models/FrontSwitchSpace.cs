using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Models
{
    class FrontSwitchSpace : Space
    {
        public Space switchUp;
        public Space switchDown;
        private String switchNumber;
        public bool switchIsUp;

        public FrontSwitchSpace(String point)
        {
            this.switchNumber = point;
        }

        public void Switch()
        {
            switchIsUp = !switchIsUp;
            SwitchCase();
        }

        private void SwitchCase()
        {
            switch (switchIsUp)
            {
                case true:
                    setNext(switchUp);
                    Symbol = ":" + switchNumber + ":_/";
                    break;
                case false:
                    setNext(switchDown);
                    Symbol = ":" + switchNumber + @":_\";
                    break;
            }
        }

        private void setNext(Space next)
        {
            this.Next = next;
        }
    }
}
