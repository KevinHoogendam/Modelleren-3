using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class GameInputView
    {
        public GameController controller;

        public GameInputView(GameController controller)
        {
            this.controller = controller;
        }

        public void GetUserSwitchInput()
        {
            while(!controller.gameOver)
            {
                Char input = Console.ReadKey().KeyChar;
                if(!controller.SwitchByInput(input))
                {
                    Console.WriteLine("");
                    Console.WriteLine("Invalid input");
                }
            }
        }
    }
}
