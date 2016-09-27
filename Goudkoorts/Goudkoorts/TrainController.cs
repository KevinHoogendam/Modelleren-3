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
                MoveBoats();
                MoveTrains();
                if (counter % 3 == 0)
                {
                    GenerateNewTrain();
                }
                if (counter % 3 == 0)
                {
                    GenerateNewBoat();
                }
                //CalculatePoints();
                gameController.boardController.DrawBoard();
                working = false;
                if (!gameController.gameOver)
                {
                    Countdown();
                    counter++;
                }
            }
            thread.Abort();
        }

        private void MoveBoats()
        {
            Space current = gameController.boardController.board.BoatTop;
            while(current.Next != null)
            {
                current = current.Next;
            }
            while (current.Previous != null)
            {
                current = MoveBoatOnSpace(current);
            }
            current = MoveBoatOnSpace(current);

            current = gameController.boardController.board.BoatBottom;
            while (current.Next != null)
            {
                current = current.Next;
            }
            while (current.Previous != null)
            {
                current = MoveBoatOnSpace(current);
            }
            current = MoveBoatOnSpace(current);
        }

        private void MoveTrains()
        {
            Space currentA = gameController.boardController.board.EndTop;
            Space currentB = gameController.boardController.board.BackSwitchB.switchDown;
            Space currentC = gameController.boardController.board.EndBottom;

            bool isDone = false;
            bool isDoneA = false;
            bool isDoneB = false;
            bool isDoneC = false;

            gameController.boardController.board.BackSwitchA.isChecked = false;
            gameController.boardController.board.BackSwitchB.isChecked = false;
            gameController.boardController.board.BackSwitchC.isChecked = false;

            while(!isDone)
            {
                //currentA
                if(!isDoneA)
                {
                    if (currentA == gameController.boardController.board.StartA)
                    {
                        isDoneA = true;
                    }

                    currentA = MoveTrainOnSpace(currentA);

                    if (currentA == gameController.boardController.board.BackSwitchB)
                    {
                        currentA = MoveTrainOnSpace(currentA);
                        currentA = gameController.boardController.board.BackSwitchB.switchUp;
                        gameController.boardController.board.BackSwitchB.isChecked = true;
                    }
                    else if (currentA == gameController.boardController.board.BackSwitchA)
                    {
                        currentA = MoveTrainOnSpace(currentA);
                        currentA = gameController.boardController.board.BackSwitchA.switchUp;
                        gameController.boardController.board.BackSwitchA.isChecked = true;
                    }
                }

                //currentC
                if (!isDoneC)
                {
                    if (currentC == gameController.boardController.board.StartC)
                    {
                        isDoneC = true;
                    }

                    currentC = MoveTrainOnSpace(currentC);

                    if (currentC == gameController.boardController.board.BackSwitchC)
                    {
                        currentC = MoveTrainOnSpace(currentC);
                        currentC = gameController.boardController.board.BackSwitchC.switchDown;
                        gameController.boardController.board.BackSwitchC.isChecked = true;
                    }
                }
                //currentB
                if (!isDoneB)
                {
                    if(currentB == gameController.boardController.board.StartB)
                    {
                        isDoneB = true;
                    }

                    if (currentB == gameController.boardController.board.BackSwitchB.switchDown)
                    {
                        if(gameController.boardController.board.BackSwitchB.isChecked)
                        {
                            currentB = MoveTrainOnSpace(currentB);
                        }
                    }
                    else if (currentB == gameController.boardController.board.BackSwitchC.switchUp)
                    {
                        if (gameController.boardController.board.BackSwitchC.isChecked)
                        {
                            currentB = MoveTrainOnSpace(currentB);
                        }
                    }
                    else if (currentB == gameController.boardController.board.BackSwitchA.switchDown)
                    {
                        if (gameController.boardController.board.BackSwitchA.isChecked)
                        {
                            currentB = MoveTrainOnSpace(currentB);
                        }
                    }
                    else
                    {
                        currentB = MoveTrainOnSpace(currentB);
                    }

                    if (currentB == gameController.boardController.board.FrontSwitchB)
                    {
                        currentB = gameController.boardController.board.BackSwitchC.switchUp;
                    }
                    if (currentB == gameController.boardController.board.FrontSwitchA)
                    {
                        currentB = gameController.boardController.board.BackSwitchA.switchDown;
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
            if (current.Next != null)
            {

                if (current.Train != null && current == current.Next.Previous)
                {
                    if (current.Next.Train == null)
                    {
                        current.Next.Train = current.Train;
                        current.Train = null;
                    }
                    else
                    {
                        current.Train = null;
                        current.Next.Train.Symbol = 'X';
                        gameController.gameOver = true;
                    }
                }
            }
            else if (current.Train != null)
            {
                current.Train = null;
            }
            if (current.Previous != null)
            {
                current = current.Previous;
            }
            return current;
        }

        private Space MoveBoatOnSpace(Space current)
        {
            if(current == gameController.boardController.board.LoadBottom || current == gameController.boardController.board.LoadTop)
            {
                if (current.Boat != null && current.Boat.isFull && current == current.Next.Previous)
                {
                    if (current.Next.Boat == null)
                    {
                        current.Next.Boat = current.Boat;
                        current.Boat = null;
                    }
                }
            }
            else if (current.Next != null)
            {
                if (current.Boat != null && current == current.Next.Previous)
                {
                    if (current.Next.Boat == null)
                    {
                        current.Next.Boat = current.Boat;
                        current.Boat = null;
                    }
                }
            }
            else if (current.Boat != null)
            {
                current.Boat = null;
            }
            if (current.Previous != null)
            {
                current = current.Previous;
            }
            return current;
        }

        private void GenerateNewTrain()
        {
            Random rnd = new Random();
            int list = rnd.Next(1, 4);
            if (list == 1)
            {
                gameController.boardController.board.StartA.Train = new Train();
            }
            else if (list == 2)
            {
                gameController.boardController.board.StartB.Train = new Train();
            }
            else if (list == 3)
            {
                gameController.boardController.board.StartC.Train = new Train();
            }
        }

        private void GenerateNewBoat()
        {
            Random rnd = new Random();
            int list = rnd.Next(1, 3);
            if (list == 1)
            {
                gameController.boardController.board.BoatTop.Boat = new Boat();
            }
            else if (list == 2)
            {
                gameController.boardController.board.BoatBottom.Boat = new Boat();
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
