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
        private String switchNumber;
        private String flexSymbol;
        public bool switchIsUp;
        public bool isChecked;

        public BackSwitchSpace(String point)
        {
            this.switchNumber = point;
        }

        public void Switch()
        {
            if (Train == null)
            {
                switchIsUp = !switchIsUp;
                SwitchCase();
            }
        }

        private void SwitchCase()
        {
            switch (switchIsUp)
            {
                case true:
                    setPrevious(switchUp);
                    Symbol = @"\_:" + switchNumber + ":";
                    break;
                case false:
                    setPrevious(switchDown);
                    Symbol = "/_:" + switchNumber + ":";
                    break;
            }
        }

        private void setPrevious(Space previous)
        {
            this.Previous = previous;
        }
    }
}
