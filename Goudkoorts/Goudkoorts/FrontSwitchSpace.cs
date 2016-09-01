using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class FrontSwitchSpace : Space
    {
        private Space switchUp;
        private Space switchDown;
        private bool switchIsUp;

        public FrontSwitchSpace(Space switchUp, Space switchDown, bool switchIsUp, Space previous)
        {
            this.switchUp = switchUp;
            this.switchDown = switchDown;
            this.switchIsUp = switchIsUp;
            this.previous = previous;
            SwitchCase();
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
                    break;
                case false:
                    setNext(switchDown);
                    break;
            }
        }

        private void setNext(Space next)
        {
            this.next = next;
        }
    }
}
