using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Goudkoorts
{
    class GameController
    {
        public BoardController boardController;
        public GameInputView gameInputView;
        public MusicController musicController;
        public TrainController trainController;
        public bool gameOver;
        public GameController()
        {
            boardController = new BoardController();
            gameInputView = new GameInputView(this);
            musicController = new MusicController();
            trainController = new TrainController(this);
            gameOver = false;
        }

        public void StartGame()
        {
            musicController.Play();
            trainController.InitThread();
            boardController.DrawBoard();
            gameInputView.GetUserSwitchInput(); // final

        }

        public bool SwitchByInput(Char input)
        {
            bool succes = false;

            switch (input)
            {
                case 'a':
                    boardController.board.backSwitchA.Switch();
                    succes = true;
                    break;
                case 'b':
                    boardController.board.frontSwitchA.Switch();
                    succes = true;
                    break;
                case 'c':
                    boardController.board.backSwitchB.Switch();
                    succes = true;
                    break;
                case 'd':
                    boardController.board.backSwitchC.Switch();
                    succes = true;
                    break;
                case 'e':
                    boardController.board.frontSwitchB.Switch();
                    succes = true;
                    break;
            }

            if(succes)
            {
                Console.Clear();
                boardController.DrawBoard();
            }

            return succes;
        }
    }
}
