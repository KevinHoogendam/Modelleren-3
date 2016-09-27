using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class Board
    {
        public StartSpace StartA;
        public StartSpace StartB;
        public StartSpace StartC;

        public BackSwitchSpace BackSwitchA;
        public BackSwitchSpace BackSwitchB;
        public BackSwitchSpace BackSwitchC;
        public FrontSwitchSpace FrontSwitchA;
        public FrontSwitchSpace FrontSwitchB;

        public QuaySpace QuayTop;
        public QuaySpace QuayBottom;

        public EndSpace EndTop;
        public EndSpace EndBottom;

        public BoatSpace BoatTop;
        public BoatSpace BoatBottom;

        public BoatLoadingSpace LoadTop;
        public BoatLoadingSpace LoadBottom;

        public Board()
        {
            StartA = new StartSpace("A");
            StartB = new StartSpace("B");
            StartC = new StartSpace("C");
            BackSwitchA = new BackSwitchSpace("A");
            BackSwitchB = new BackSwitchSpace("C");
            BackSwitchC = new BackSwitchSpace("D");
            FrontSwitchA = new FrontSwitchSpace("B");
            FrontSwitchB = new FrontSwitchSpace("E");
            QuayTop = new QuaySpace();
            QuayBottom = new QuaySpace();
            EndTop = new EndSpace();
            EndBottom = new EndSpace();
            BoatTop = new BoatSpace();
            BoatBottom = new BoatSpace();
            LoadBottom = new BoatLoadingSpace();
            LoadTop = new BoatLoadingSpace();
        }

        public void CreateBoard()
        {
            Space current;
            bool frontSwitchMade = false;
            //BoatTop
            current = BoatTop;
            for (int i = 0; i < 33; i++)
            {
                switch (i)
                {
                    case 12:
                        LoadTop.Previous = current;
                        current.Next = LoadTop;
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
            current = BoatBottom;
            for (int i = 0; i < 33; i++)
            {
                switch (i)
                {
                    case 10:
                        LoadBottom.Previous = current;
                        current.Next = LoadBottom;
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
            current = StartA;
            for(int i = 0; i < 27; i++)
            {
                switch (i)
                {
                    case 2:
                        BackSwitchA = addBackSwitch(BackSwitchA, true, current);
                        current.Next = BackSwitchA;
                        current = current.Next;
                        break;
                    case 4:
                        current.Next = FrontSwitchA;
                        current = current.Next;
                        current.Next = addFrontSwitch(FrontSwitchA, true);
                        current = current.Next;
                        frontSwitchMade = true;
                        break;
                    case 10:
                        addBackSwitch(BackSwitchB, true, current);
                        current.Next = BackSwitchB;
                        current = current.Next;
                        break;
                    case 17:
                        QuayTop.Previous = current;
                        current.Next = QuayTop;
                        current = current.Next;
                        break;
                    case 26:
                        EndTop.Previous = current;
                        current.Next = EndTop;
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
            current = StartC;
            for (int i = 0; i < 24; i++)
            {
                switch (i)
                {
                    case 5:
                        addBackSwitch(BackSwitchC, false, current);
                        current.Next = BackSwitchC;
                        current = current.Next;
                        break;
                    case 7:
                        if (FrontSwitchB.Previous == null)
                        {
                            FrontSwitchB.Previous = current;
                        }
                        current.Next = FrontSwitchB;
                        current = current.Next;
                        current.Next = addFrontSwitch(FrontSwitchB, false);
                        current = current.Next;

                        frontSwitchMade = true;
                        break;
                    case 14:
                        QuayBottom.Previous = current;
                        current.Next = QuayBottom;
                        current = current.Next;
                        break;
                    case 23:
                        EndBottom.Previous = current;
                        current.Next = EndBottom;
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
            current = StartB;
            for (int i = 0; i < 13; i++)
            {
                switch (i)
                {
                    case 2:
                        BackSwitchA = addBackSwitch(BackSwitchA, false, current);
                        current.Next = BackSwitchA;
                        current = current.Next;
                        break;
                    case 4:
                        if (FrontSwitchA.Previous == null)
                        {
                            FrontSwitchA.Previous = current;
                        }
                        current.Next = FrontSwitchA;
                        current = current.Next;
                        current.Next = addFrontSwitch(FrontSwitchA, false);
                        current = current.Next;
                        frontSwitchMade = true;
                        break;
                    case 7:
                        BackSwitchC = addBackSwitch(BackSwitchC, true, current);
                        current.Next = BackSwitchC;
                        current = current.Next;
                        break;
                    case 9:
                        if (FrontSwitchB.Previous == null)
                        {
                            FrontSwitchB.Previous = current;
                        }
                        current.Next = FrontSwitchB;
                        current = current.Next;
                        current.Next = addFrontSwitch(FrontSwitchB, true);
                        current = current.Next;
                        frontSwitchMade = true;
                        break;
                    case 12:
                        BackSwitchB = addBackSwitch(BackSwitchB, false, current);
                        current.Next = BackSwitchB;
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
            SwitchAll();
        }
        private void boardTest()
        {
            SwitchAll();
            ShowList(StartA);
            ShowList(StartB);
            ShowList(StartC);

            SwitchAll();
            ShowList(StartA);
            ShowList(StartB);
            ShowList(StartC);

            SwitchAll();
            ShowList(StartA);
            ShowList(StartB);
            ShowList(StartC);
        }

        private void SwitchAll()
        {
            BackSwitchA.Switch();
            BackSwitchB.Switch();
            BackSwitchC.Switch();
            FrontSwitchA.Switch();
            FrontSwitchB.Switch();
        }

        private void ShowList(Space start)
        {
            Console.WriteLine("");
            Space current = start;
            while (current != null)
            {
                Console.Write(current.Symbol);
                current = current.Next;
            }
            Console.WriteLine("");
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
