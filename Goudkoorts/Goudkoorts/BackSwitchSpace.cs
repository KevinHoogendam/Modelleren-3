using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class BackSwitchSpace : Space
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
