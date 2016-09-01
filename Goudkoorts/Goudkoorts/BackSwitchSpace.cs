using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class BackSwitchSpace : Space
    {
        private Space switchUp;
        private Space switchDown;
        private bool switchIsUp;

        public BackSwitchSpace(Space switchUp, Space switchDown, bool switchIsUp, Space next)
        {
            this.switchUp = switchUp;
            this.switchDown = switchDown;
            this.switchIsUp = switchIsUp;
            this.next = next;
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
                    setPrevious(switchUp);
                    break;
                case false:
                    setPrevious(switchDown);
                    break;
            }
        }

        private void setPrevious(Space previous)
        {
            this.previous = previous;
        }
    }
}
