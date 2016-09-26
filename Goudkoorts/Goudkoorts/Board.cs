using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class Board
    {
        public StartSpace startA;
        public StartSpace startB;
        public StartSpace startC;

        public BackSwitchSpace backSwitchA;
        public BackSwitchSpace backSwitchB;
        public BackSwitchSpace backSwitchC;
        public FrontSwitchSpace frontSwitchA;
        public FrontSwitchSpace frontSwitchB;

        public EndSpace endTop;
        public EndSpace endBottom;

        public Board()
        {
            startA = new StartSpace("A");
            startB = new StartSpace("B");
            startC = new StartSpace("C");
            backSwitchA = new BackSwitchSpace("A");
            backSwitchB = new BackSwitchSpace("C");
            backSwitchC = new BackSwitchSpace("D");
            frontSwitchA = new FrontSwitchSpace("B");
            frontSwitchB = new FrontSwitchSpace("E");
            endTop = new EndSpace();
            endBottom = new EndSpace();
        }

        public void CreateBoard()
        {
            Space current;
            bool frontSwitchMade = false;
            //LijstA
            current = startA;
            int counter = 1;
            for(int i = 0; i < 27; i++)
            {
                switch (i)
                {
                    case 2:
                        backSwitchA = addBackSwitch(backSwitchA, true, current);
                        current.Next = backSwitchA;
                        current = current.Next;
                        break;
                    case 4:
                        current.Next = frontSwitchA;
                        current = current.Next;
                        current.Next = addFrontSwitch(frontSwitchA, true, counter);
                        current = current.Next;
                        frontSwitchMade = true;
                        break;
                    case 10:
                        addBackSwitch(backSwitchB, true, current);
                        current.Next = backSwitchB;
                        current = current.Next;
                        break;
                    case 17:
                        QuaySpace tempQuay = new QuaySpace();
                        tempQuay.Previous = current;
                        current.Next = tempQuay;
                        current = current.Next;
                        break;
                    case 26:
                        endTop.Previous = current;
                        current.Next = endTop;
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
                counter++;
            }
            //Lijst C
            current = startC;
            for (int i = 0; i < 24; i++)
            {
                switch (i)
                {
                    case 5:
                        addBackSwitch(backSwitchC, false, current);
                        current.Next = backSwitchC;
                        current = current.Next;
                        break;
                    case 7:
                        if (frontSwitchB.Previous == null)
                        {
                            frontSwitchB.Previous = current;
                        }
                        current.Next = frontSwitchB;
                        current = current.Next;
                        current.Next = addFrontSwitch(frontSwitchB, false, counter);
                        current = current.Next;

                        frontSwitchMade = true;
                        break;
                    case 14:
                        QuaySpace tempQuay = new QuaySpace();
                        tempQuay.Previous = current;
                        current.Next = tempQuay;
                        current = current.Next;
                        break;
                    case 23:
                        endBottom.Previous = current;
                        current.Next = endBottom;
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
                counter++;

            }
            //Lijst B
            current = startB;
            for (int i = 0; i < 13; i++)
            {
                switch (i)
                {
                    case 2:
                        backSwitchA = addBackSwitch(backSwitchA, false, current);
                        current.Next = backSwitchA;
                        current = current.Next;
                        break;
                    case 4:
                        if (frontSwitchA.Previous == null)
                        {
                            frontSwitchA.Previous = current;
                        }
                        current.Next = frontSwitchA;
                        current = current.Next;
                        current.Next = addFrontSwitch(frontSwitchA, false, counter);
                        current = current.Next;
                        frontSwitchMade = true;
                        break;
                    case 7:
                        backSwitchC = addBackSwitch(backSwitchC, true, current);
                        current.Next = backSwitchC;
                        current = current.Next;
                        break;
                    case 9:
                        if (frontSwitchB.Previous == null)
                        {
                            frontSwitchB.Previous = current;
                        }
                        current.Next = frontSwitchB;
                        current = current.Next;
                        current.Next = addFrontSwitch(frontSwitchB, true, counter);
                        current = current.Next;
                        frontSwitchMade = true;
                        break;
                    case 12:
                        backSwitchB = addBackSwitch(backSwitchB, false, current);
                        current.Next = backSwitchB;
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
                counter++;
            }
            SwitchAll();
        }
        private void boardTest()
        {
            SwitchAll();
            ShowList(startA);
            ShowList(startB);
            ShowList(startC);

            SwitchAll();
            ShowList(startA);
            ShowList(startB);
            ShowList(startC);

            SwitchAll();
            ShowList(startA);
            ShowList(startB);
            ShowList(startC);
        }

        private void SwitchAll()
        {
            backSwitchA.Switch();
            backSwitchB.Switch();
            backSwitchC.Switch();
            frontSwitchA.Switch();
            frontSwitchB.Switch();
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

        private Space addFrontSwitch(FrontSwitchSpace frontSwitch, bool isUp, int c)
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
