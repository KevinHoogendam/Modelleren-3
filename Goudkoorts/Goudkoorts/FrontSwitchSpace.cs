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
        private bool switchIsUp;

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
