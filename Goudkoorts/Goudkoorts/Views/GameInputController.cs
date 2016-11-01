using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goudkoorts.Models;

namespace Goudkoorts.Controllers
{
    class GameInputController
    {

        public bool GetUserSwitchInput(Board board)
        {
            bool succes;
            Char input = Console.ReadKey().KeyChar;
            if (!SwitchByInput(input, board))
            {
                Console.WriteLine("");
                Console.WriteLine("Invalid input");
                succes = false;
            }
            else
            {
                succes = true;
            }
            return succes;
        }

        private bool SwitchByInput(Char input, Board board)
        {
            bool succes = false;

            switch (input)
            {
                case 'a':
                    if (board.BackSwitchA.Train == null)
                    {
                        board.BackSwitchA.Switch();
                    }
                    succes = true;
                    break;
                case 'b':
                    if (board.FrontSwitchA.Train == null)
                    {
                        board.FrontSwitchA.Switch();
                    }
                    succes = true;
                    break;
                case 'c':
                    if (board.BackSwitchB.Train == null)
                    {
                        board.BackSwitchB.Switch();
                    }
                    succes = true;
                    break;
                case 'd':
                    if (board.BackSwitchC.Train == null)
                    {
                        board.BackSwitchC.Switch();
                    }
                    succes = true;
                    break;
                case 'e':
                    if (board.FrontSwitchB.Train == null)
                    {
                        board.FrontSwitchB.Switch();
                    }
                    succes = true;
                    break;
            }
            return succes;
        }
    }
}
