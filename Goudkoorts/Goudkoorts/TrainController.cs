using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Goudkoorts
{
    class TrainController
    {
        private GameController gameController;
        private Thread thread;
        public Boolean working;
        public TrainController(GameController gameController)
        {
            this.gameController = gameController;
            thread = new Thread(new ThreadStart(this.RunThread));
            working = false;
        }

        public void InitThread()
        {
            thread.Start();
        }

        private void RunThread()
        {
            int counter = 3;
            while (!gameController.gameOver)
            {
                working = true;
                //MoveBoats();//TODO: BoatList implementeren
                MoveTrains();
                if (counter % 3 == 0)
                {
                    GenerateNewTrain();
                }
                //if (counter % 20 == 0)
                //{
                //    GenerateNewBoat();//TODO: BoatList implementeren
                //}
                //CalculatePoints();
                gameController.boardController.DrawBoard();
                working = false;
                if (!gameController.gameOver)
                {
                    Countdown();
                }
            }
            thread.Abort();
        }

        private void MoveTrains()
        {
            Space current;
            bool backA = gameController.boardController.board.backSwitchA.switchIsUp;
            bool backB = gameController.boardController.board.backSwitchB.switchIsUp;
            bool backC = gameController.boardController.board.backSwitchC.switchIsUp;

            //End naar A
            current = gameController.boardController.board.endTop;
            bool noPre = false;
            while(!noPre)
            {

                if(current.train != null && current == current.next.previous)
                {
                    if(current.next.train == null)
                    {
                        current.next.train = current.train;
                        current.train = null;
                    }
                    else
                    {
                        current.train = null;
                        current.next.train.symbol = "X";
                       // gameController.gameOver = true;
                    }
                }
                if (current.previous != null)
                {
                    if (!backA)
                    {
                        gameController.boardController.board.backSwitchA.Switch();
                    }
                    if (!backB)
                    {
                        gameController.boardController.board.backSwitchB.Switch();
                    }
                    current = current.previous;
                    if (!backA)
                    {
                        gameController.boardController.board.backSwitchA.Switch();
                    }
                    if (!backB)
                    {
                        gameController.boardController.board.backSwitchB.Switch();
                    }
                }
                else
                {
                    noPre = true;
                }
            }

            //End naar C
            current = gameController.boardController.board.endBottom;
            noPre = false;
            while (!noPre)
            {

                if (current.train != null && current == current.next.previous)
                {
                    if (current.next.train == null)
                    {
                        current.next.train = current.train;
                        current.train = null;
                    }
                    else
                    {
                        current.train = null;
                        current.next.train.symbol = "#";
                        //gameController.gameOver = true;
                    }
                }
                if (current.previous != null)
                {
                    if (backC)
                    {
                        gameController.boardController.board.backSwitchC.Switch();
                    }
                    current = current.previous;
                    if (backC)
                    {
                        gameController.boardController.board.backSwitchC.Switch();
                    }
                }
                else
                {
                    noPre = true;
                }
            }
            //switch C naar begin B
            current = gameController.boardController.board.backSwitchB.switchDown;
            noPre = false;
            bool checkSpace = true;
            while (!noPre)
            {
                if (current == gameController.boardController.board.frontSwitchB || current == gameController.boardController.board.frontSwitchA)
                {
                    checkSpace = false;
                }

                if (current == gameController.boardController.board.backSwitchC.switchUp || current == gameController.boardController.board.backSwitchA.switchDown)
                {
                    checkSpace = true;
                }

                if (current.train != null && current == current.next.previous && checkSpace)
                {
                    if (current.next.train == null)
                    {
                        current.next.train = current.train;
                        current.train = null;
                    }
                    else
                    {
                        current.train = null;
                        current.next.train.symbol = "X";
                        //gameController.gameOver = true;
                    }
                }
                if (current.previous != null)
                {
                    if (!backC)
                    {
                        gameController.boardController.board.backSwitchC.Switch();
                    }
                    if (backA)
                    {
                        gameController.boardController.board.backSwitchA.Switch();
                    }
                    current = current.previous;
                    if (!backC)
                    {
                        gameController.boardController.board.backSwitchC.Switch();
                    }
                    if (backA)
                    {
                        gameController.boardController.board.backSwitchA.Switch();
                    }
                }
                else
                {
                    noPre = true;
                }
            }
        }

        private void GenerateNewTrain()
        {
            Random rnd = new Random();
            int list = rnd.Next(1, 4);
            if (list == 1)
            {
                gameController.boardController.board.startA.train = new Train();
            }
            else if (list == 2)
            {
                gameController.boardController.board.startB.train = new Train();
            }
            else if (list == 3)
            {
                gameController.boardController.board.startC.train = new Train();
            }
        }

        public void Countdown()
        {
            int counter = 3;
            int timer = 3000; //- game.player.Score;
            timer = timer / 3;

            while (counter > 0)
            {
                Console.WriteLine(counter);
                Thread.Sleep(timer);
                counter--;
            }
        }
    }
}
