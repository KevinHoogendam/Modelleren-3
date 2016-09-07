using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
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
                    symbol = ":" + switchNumber + "/";
                    break;
                case false:
                    setNext(switchDown);
                    symbol = ":" + switchNumber + @"\";
                    break;
            }
        }

        private void setNext(Space next)
        {
            this.next = next;
        }
    }
}
