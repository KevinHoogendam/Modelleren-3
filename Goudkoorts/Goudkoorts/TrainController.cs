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
                //MoveCarts();
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
            int counter = 5;
            int timer = 5000; //- game.player.Score;
            timer = timer / 5;

            while (counter > 0)
            {
                Console.WriteLine(counter);
                Thread.Sleep(timer);
                counter--;
            }
        }
    }
}
