using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Goudkoorts.Models;
using Goudkoorts.Views;

namespace Goudkoorts.Controllers
{
    class GameController
    {
        public Player Player
        {
            get;
            set;
        }

        public TrainController TrainController
        {
            get;
            set;
        }

        public BoatController BoatController
        {
            get;
            set;
        }

        public MusicController MusicController
        {
            get;
            set;
        }

        public BoardController BoardController
        {
            get;
            set;
        }

        public GameInputController GameInputView
        {
            get;
            set;
        }

        public BoardView BoardView
        {
            get;
            set;
        }
        public bool gameOver;
        private Thread thread;
        public GameController()
        {
            this.BoardController = new BoardController();
            this.BoardView = new BoardView();
            this.GameInputView = new GameInputController();
            this.MusicController = new MusicController();
            this.TrainController = new TrainController();
            this.BoatController = new BoatController();
            this.Player = new Player();
            this.gameOver = false;
            thread = new Thread(new ThreadStart(this.RunThread));
        }



        public void StartGame()
        {
            MusicController.Play();
            InitThread();
            while(!gameOver)
            {
                if (GameInputView.GetUserSwitchInput(BoardController.Board))
                {
                    Console.Clear();
                    BoardView.DrawBoard(BoardController.Board);
                    BoardView.DrawScore(Player.Score);
                }
            }
        }

        private void InitThread()
        {
            BoardController.CreateBoard();
            thread.Start();
        }

        private void RunThread()
        {
            int counter = 50;
            while (!gameOver)
            {
                Board board = BoardController.Board;
                BoatController.MoveBoats(board);
                TrainController.MoveTrains(board);
                gameOver = TrainController.TrainHasCrashed;
                if (counter % (10 - (Player.Score / 8)) == 0)
                {
                    TrainController.GenerateNewTrain(board);
                }
                if (counter % 50 == 0)
                {
                    BoatController.GenerateNewBoat(board);
                }
                CalculatePoints(board);
                BoardView.DrawBoard(board);
                BoardView.DrawScore(Player.Score);

                if (!gameOver)
                {
                    Countdown();
                    counter++;
                }
            }
            BoardView.DrawGameOver();
            thread.Abort();
        }

        private void Countdown()
        {
            int timer = 2000 - (Player.Score * 40);
            Thread.Sleep(timer);
        }

        private void CalculatePoints(Board board)
        {
            if (board.LoadTop.Boat != null && board.QuayTop.Train != null)
            {
                board.LoadTop.Boat.AddLoad(board.QuayTop.Train.Load);
                board.QuayTop.Train.Load = 0;
                board.QuayTop.Train.Symbol = 'U';
                Player.Score =Player.Score + 1;
                if (board.LoadTop.Boat.isFull)
                {
                    Player.Score = Player.Score + 10;
                }
            }

            if (board.LoadBottom.Boat != null && board.QuayBottom.Train != null)
            {
                board.LoadBottom.Boat.AddLoad(board.QuayBottom.Train.Load);
                board.QuayBottom.Train.Load = 0;
                board.QuayBottom.Train.Symbol = 'U';
               Player.Score = Player.Score + 1;
                if (board.LoadBottom.Boat.isFull)
                {
                    Player.Score = Player.Score + 10;
                }
            }
        }


    }
}
