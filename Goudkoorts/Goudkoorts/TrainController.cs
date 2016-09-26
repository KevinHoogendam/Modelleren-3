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
            Space currentA = gameController.boardController.board.endTop;
            Space currentB = gameController.boardController.board.backSwitchB.switchDown;
            Space currentC = gameController.boardController.board.endBottom;

            bool isDone = false;
            bool isDoneA = false;
            bool isDoneB = false;
            bool isDoneC = false;

            gameController.boardController.board.backSwitchA.isChecked = false;
            gameController.boardController.board.backSwitchB.isChecked = false;
            gameController.boardController.board.backSwitchC.isChecked = false;

            while(!isDone)
            {
                //currentA
                if(!isDoneA)
                {
                    if (currentA == gameController.boardController.board.startA)
                    {
                        isDoneA = true;
                    }

                    currentA = MoveTrainOnSpace(currentA);

                    if (currentA == gameController.boardController.board.backSwitchB)
                    {
                        currentA = MoveTrainOnSpace(currentA);
                        currentA = gameController.boardController.board.backSwitchB.switchUp;
                        gameController.boardController.board.backSwitchB.isChecked = true;
                    }
                    else if (currentA == gameController.boardController.board.backSwitchA)
                    {
                        currentA = MoveTrainOnSpace(currentA);
                        currentA = gameController.boardController.board.backSwitchA.switchUp;
                        gameController.boardController.board.backSwitchA.isChecked = true;
                    }
                }

                //currentC
                if (!isDoneC)
                {
                    if (currentC == gameController.boardController.board.startC)
                    {
                        isDoneC = true;
                    }

                    currentC = MoveTrainOnSpace(currentC);

                    if (currentC == gameController.boardController.board.backSwitchC)
                    {
                        currentC = MoveTrainOnSpace(currentC);
                        currentC = gameController.boardController.board.backSwitchC.switchDown;
                        gameController.boardController.board.backSwitchC.isChecked = true;
                    }
                }
                //currentB
                if (!isDoneB)
                {
                    if(currentB == gameController.boardController.board.startB)
                    {
                        isDoneB = true;
                    }

                    if (currentB == gameController.boardController.board.backSwitchB.switchDown)
                    {
                        if(gameController.boardController.board.backSwitchB.isChecked)
                        {
                            currentB = MoveTrainOnSpace(currentB);
                        }
                    }
                    else if (currentB == gameController.boardController.board.backSwitchC.switchUp)
                    {
                        if (gameController.boardController.board.backSwitchC.isChecked)
                        {
                            currentB = MoveTrainOnSpace(currentB);
                        }
                    }
                    else if (currentB == gameController.boardController.board.backSwitchA.switchDown)
                    {
                        if (gameController.boardController.board.backSwitchA.isChecked)
                        {
                            currentB = MoveTrainOnSpace(currentB);
                        }
                    }
                    else
                    {
                        currentB = MoveTrainOnSpace(currentB);
                    }

                    if (currentB == gameController.boardController.board.frontSwitchB)
                    {
                        currentB = gameController.boardController.board.backSwitchC.switchUp;
                    }
                    if (currentB == gameController.boardController.board.frontSwitchA)
                    {
                        currentB = gameController.boardController.board.backSwitchA.switchDown;
                    }
                }

                if(isDoneA && isDoneB && isDoneC)
                {
                    isDone = true;
                }
            }
        }

        private Space MoveTrainOnSpace(Space current)
        {
            if (current.next != null)
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
                        current.next.train.symbol = "X";
                        // gameController.gameOver = true;
                    }
                }
            }
            else if (current.train != null)
            {
                current.train = null;
            }
            if (current.previous != null)
            {
                current = current.previous;
            }
            return current;
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
