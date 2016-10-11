using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Goudkoorts.Models;

namespace Goudkoorts.Controllers
{
    class TrainController
    {
        public bool TrainHasCrashed;

        public TrainController()
        {
            TrainHasCrashed = false;
        }

        

        public bool MoveTrains(Board board)
        {
            Space currentA = board.EndTop;
            Space currentB = board.BackSwitchB.switchDown;
            Space currentC = board.EndBottom;

            bool isDone = false;
            bool isDoneA = false;
            bool isDoneB = false;
            bool isDoneC = false;

            bool aIsChecked = false;
            bool bIsChecked = false;
            bool cIsChecked = false;

            while(!isDone)
            {
                //currentA
                if(!isDoneA)
                {
                    if (!cIsChecked && bIsChecked)
                    {
                    
                    }
                    else
                    {
                        if (currentA == board.StartA)
                        {
                            isDoneA = true;
                        }

                        currentA = MoveTrainOnSpace(currentA);

                        if (currentA == board.BackSwitchB)
                        {
                            currentA = MoveTrainOnSpace(currentA);
                            currentA = board.BackSwitchB.switchUp;
                            bIsChecked = true;
                        }
                        else if (currentA == board.BackSwitchA)
                        {
                            currentA = MoveTrainOnSpace(currentA);
                            currentA = board.BackSwitchA.switchUp;
                            aIsChecked = true;
                        }
                    }

                }

                //currentC
                if (!isDoneC)
                {
                    if (bIsChecked)
                    {
                        if (currentC == board.StartC)
                        {
                            isDoneC = true;
                        }

                        currentC = MoveTrainOnSpace(currentC);

                        if (currentC == board.BackSwitchC)
                        {
                            currentC = MoveTrainOnSpace(currentC);
                            currentC = board.BackSwitchC.switchDown;
                            cIsChecked = true;
                        }
                    }
                }
                //currentB
                if (!isDoneB)
                {
                    if(currentB == board.StartB)
                    {
                        isDoneB = true;
                    }

                    if (currentB == board.BackSwitchB.switchDown)
                    {
                        if (bIsChecked)
                        {
                            currentB = MoveTrainOnSpace(currentB);
                        }
                    }
                    else if (currentB == board.BackSwitchC.switchUp)
                    {
                        if (cIsChecked)
                        {
                            currentB = MoveTrainOnSpace(currentB);
                        }
                    }
                    else if (currentB == board.BackSwitchA.switchDown)
                    {
                        if (aIsChecked)
                        {
                            currentB = MoveTrainOnSpace(currentB);
                        }
                    }
                    else
                    {
                        currentB = MoveTrainOnSpace(currentB);
                    }

                    if (currentB == board.FrontSwitchB)
                    {
                        currentB = board.BackSwitchC.switchUp;
                    }
                    if (currentB == board.FrontSwitchA)
                    {
                        currentB = board.BackSwitchA.switchDown;
                    }
                }

                if(isDoneA && isDoneB && isDoneC)
                {
                    isDone = true;
                }
            }
            return TrainHasCrashed;
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
                        TrainHasCrashed = true;
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

        public void GenerateNewTrain(Board board)
        {
            Random rnd = new Random();
            int list = rnd.Next(1, 4);
            if (list == 1)
            {
                board.StartA.Train = new Train();
            }
            else if (list == 2)
            {
                board.StartB.Train = new Train();
            }
            else if (list == 3)
            {
                board.StartC.Train = new Train();
            }
        }

    }
}
