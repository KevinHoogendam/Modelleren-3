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
            gameInputView.GetUserSwitchInput(); // final

        }

        public bool SwitchByInput(Char input)
        {
            bool succes = false;

            switch (input)
            {
                case 'a':
                    if (boardController.board.BackSwitchA.Train == null)
                    {
                        boardController.board.BackSwitchA.Switch();
                    }
                    succes = true;
                    break;
                case 'b':
                    if (boardController.board.FrontSwitchA.Train == null)
                    {
                        boardController.board.FrontSwitchA.Switch();
                    }                 
                    succes = true;
                    break;
                case 'c':
                    if(boardController.board.BackSwitchB.Train == null)
                    {
                        boardController.board.BackSwitchB.Switch();
                    }
                    succes = true;
                    break;
                case 'd':
                    if (boardController.board.BackSwitchC.Train == null)
                    {
                        boardController.board.BackSwitchC.Switch();
                    }
                    succes = true;
                    break;
                case 'e':
                    if (boardController.board.FrontSwitchB.Train == null)
                    {
                        boardController.board.FrontSwitchB.Switch();
                    }
                    boardController.board.FrontSwitchB.Switch();
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
