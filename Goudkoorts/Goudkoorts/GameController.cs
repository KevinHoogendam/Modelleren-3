using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class GameController
    {
        public BoardController boardView;
        public GameInputView gameInputView;
        public bool gameOver;
        public GameController()
        {
            boardView = new BoardController();
            gameInputView = new GameInputView(this);
            gameOver = false;
        }

        public void StartGame()
        {
            boardView.DrawBoard();
            gameInputView.GetUserSwitchInput();
        }

        public bool SwitchByInput(Char input)
        {
            bool succes = false;

            switch (input)
            {
                case 'a':
                    boardView.board.backSwitchA.Switch();
                    succes = true;
                    break;
                case 'b':
                    boardView.board.frontSwitchA.Switch();
                    succes = true;
                    break;
                case 'c':
                    boardView.board.backSwitchB.Switch();
                    succes = true;
                    break;
                case 'd':
                    boardView.board.backSwitchC.Switch();
                    succes = true;
                    break;
                case 'e':
                    boardView.board.frontSwitchB.Switch();
                    succes = true;
                    break;
            }

            if(succes)
            {
                Console.Clear();
                boardView.DrawBoard();
                Console.Beep(1000,2);
            }

            return succes;
        }
    }
}
