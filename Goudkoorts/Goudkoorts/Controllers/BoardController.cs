using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goudkoorts.Models;

namespace Goudkoorts.Controllers
{
    class BoardController
    {

        public Board Board
        {
            get;
            set;
        }

        public BoardController()
        {
            this.Board = new Board();
        }

        public void CreateBoard()
        {
            Space current;
            bool frontSwitchMade = false;
            //BoatTop
            current = Board.BoatTop;
            for (int i = 0; i < 33; i++)
            {
                switch (i)
                {
                    case 12:
                        Board.LoadTop.Previous = current;
                        current.Next = Board.LoadTop;
                        current = current.Next;
                        break;
                    default:
                        BoatSpace temp = new BoatSpace();
                        temp.Previous = current;
                        current.Next = temp;
                        current = current.Next;
                        break;

                }
            }

            //BoatBottom
            current = Board.BoatBottom;
            for (int i = 0; i < 33; i++)
            {
                switch (i)
                {
                    case 10:
                        Board.LoadBottom.Previous = current;
                        current.Next = Board.LoadBottom;
                        current = current.Next;
                        break;
                    default:
                        BoatSpace temp = new BoatSpace();
                        temp.Previous = current;
                        current.Next = temp;
                        current = current.Next;
                        break;

                }
            }

            //LijstA
            current = Board.StartA;
            for(int i = 0; i < 27; i++)
            {
                switch (i)
                {
                    case 2:
                        Board.BackSwitchA = addBackSwitch(Board.BackSwitchA, true, current);
                        current.Next = Board.BackSwitchA;
                        current = current.Next;
                        break;
                    case 4:
                        current.Next = Board.FrontSwitchA;
                        current = current.Next;
                        current.Next = addFrontSwitch(Board.FrontSwitchA, true);
                        current = current.Next;
                        frontSwitchMade = true;
                        break;
                    case 10:
                        addBackSwitch(Board.BackSwitchB, true, current);
                        current.Next = Board.BackSwitchB;
                        current = current.Next;
                        break;
                    case 17:
                        Board.QuayTop.Previous = current;
                        current.Next = Board.QuayTop;
                        current = current.Next;
                        break;
                    case 26:
                        Board.EndTop.Previous = current;
                        current.Next = Board.EndTop;
                        current = current.Next;
                        break;
                    default:
                        if (!frontSwitchMade)
                        {
                            RailSpace temp = new RailSpace();
                            temp.Previous = current;
                            current.Next = temp;
                            current = current.Next;
                        }
                        else
                        {
                            frontSwitchMade = false;
                        }
                        break;
                      
                }
            }
            //Lijst C
            current = Board.StartC;
            for (int i = 0; i < 24; i++)
            {
                switch (i)
                {
                    case 5:
                        addBackSwitch(Board.BackSwitchC, false, current);
                        current.Next = Board.BackSwitchC;
                        current = current.Next;
                        break;
                    case 7:
                        if (Board.FrontSwitchB.Previous == null)
                        {
                            Board.FrontSwitchB.Previous = current;
                        }
                        current.Next = Board.FrontSwitchB;
                        current = current.Next;
                        current.Next = addFrontSwitch(Board.FrontSwitchB, false);
                        current = current.Next;

                        frontSwitchMade = true;
                        break;
                    case 14:
                        Board.QuayBottom.Previous = current;
                        current.Next = Board.QuayBottom;
                        current = current.Next;
                        break;
                    case 23:
                        Board.EndBottom.Previous = current;
                        current.Next = Board.EndBottom;
                        current = current.Next;
                        break;
                    default:
                        if (!frontSwitchMade)
                        {
                            RailSpace temp = new RailSpace();
                            temp.Previous = current;
                            current.Next = temp;
                            current = current.Next;
                         }
                         else
                         {
                             frontSwitchMade = false;
                         }
                        break;
                }
            }
            //Lijst B
            current = Board.StartB;
            for (int i = 0; i < 13; i++)
            {
                switch (i)
                {
                    case 2:
                        Board.BackSwitchA = addBackSwitch(Board.BackSwitchA, false, current);
                        current.Next = Board.BackSwitchA;
                        current = current.Next;
                        break;
                    case 4:
                        if (Board.FrontSwitchA.Previous == null)
                        {
                            Board.FrontSwitchA.Previous = current;
                        }
                        current.Next = Board.FrontSwitchA;
                        current = current.Next;
                        current.Next = addFrontSwitch(Board.FrontSwitchA, false);
                        current = current.Next;
                        frontSwitchMade = true;
                        break;
                    case 7:
                        Board.BackSwitchC = addBackSwitch(Board.BackSwitchC, true, current);
                        current.Next = Board.BackSwitchC;
                        current = current.Next;
                        break;
                    case 9:
                        if (Board.FrontSwitchB.Previous == null)
                        {
                            Board.FrontSwitchB.Previous = current;
                        }
                        current.Next = Board.FrontSwitchB;
                        current = current.Next;
                        current.Next = addFrontSwitch(Board.FrontSwitchB, true);
                        current = current.Next;
                        frontSwitchMade = true;
                        break;
                    case 12:
                        Board.BackSwitchB = addBackSwitch(Board.BackSwitchB, false, current);
                        current.Next = Board.BackSwitchB;
                        current = current.Next;
                        break;
                    case 3:
                    case 8:
                        current = current.Next;
                        break;
                    default:
                        if (!frontSwitchMade)
                        {
                            RailSpace temp = new RailSpace();
                            temp.Previous = current;
                            current.Next = temp;
                            current = current.Next;
                        }
                        else
                        {
                            frontSwitchMade = false;
                        }
                        break;
                }
            }
            Board.BackSwitchA.Switch();
            Board.BackSwitchB.Switch();
            Board.BackSwitchC.Switch();
            Board.FrontSwitchA.Switch();
            Board.FrontSwitchB.Switch();
        }

        private Space addFrontSwitch(FrontSwitchSpace frontSwitch, bool isUp)
        {
            Space current;
            if(isUp)
            {
                frontSwitch.switchUp = new RailSpace();
                current = frontSwitch.switchUp;
            }
            else
            {
                frontSwitch.switchDown = new RailSpace();
                current = frontSwitch.switchDown;
            }
            current.Previous = frontSwitch;
            return current;
        }
        private BackSwitchSpace addBackSwitch(BackSwitchSpace backSwitch, bool isUp, Space current)
        {  
            if (isUp)
            {
                backSwitch.switchUp = current;
            }
            else
            {
                backSwitch.switchDown = current;
            }

            return backSwitch;
        }
    }
}
