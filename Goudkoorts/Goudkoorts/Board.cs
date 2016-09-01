using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class Board
    {
        private List<Space> rails = new List<Space>();
        private List<StartSpace> starts = new List<StartSpace>();
        private List<FrontSwitchSpace> frontSwitch = new List<FrontSwitchSpace>();
        private List<BackSwitchSpace> backSwitch = new List<BackSwitchSpace>();
        private List<QuaySpace> quays = new List<QuaySpace>();

        public void CreateSpaces(int startAmount, int frontSwitchAmount, int backSwitchAmount, int quayAmount, int railAmount)
        {
            for(int i = 0; i < startAmount; i++)
            {
            
            }
        }
    }
}
