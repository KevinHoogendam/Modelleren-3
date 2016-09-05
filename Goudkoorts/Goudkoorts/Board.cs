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
        }

        public void CreateBoard()
        {
            Space current;
            bool frontSwitchMade = false;
            //LijstA
            current = startA;
            for(int i = 0; i < 27; i++)
            {
                switch (i)
                {
                    case 2:
                        backSwitchA = addBackSwitch(backSwitchA, true, current);
                        current.next = backSwitchA;
                        current = current.next;
                        break;
                    case 4:
                        current.next = frontSwitchA;
                        current = current.next;
                        current.next = addFrontSwitch(frontSwitchA, true, current);
                        current = current.next;
                        frontSwitchMade = true;
                        break;
                    case 10:
                        addBackSwitch(backSwitchB, true, current);
                        current.next = backSwitchB;
                        current = current.next;
                        break;
                    case 17:
                        QuaySpace tempQuay = new QuaySpace();
                        tempQuay.previous = current;
                        current.next = tempQuay;
                        current = current.next;
                        break;
                    case 26:
                        EndSpace tempEnd = new EndSpace();
                        tempEnd.previous = current;
                        current.next = tempEnd;
                        current = current.next;
                        break;
                    default:
                        if (!frontSwitchMade)
                        {
                            RailSpace temp = new RailSpace();
                            temp.previous = current;
                            current.next = temp;
                            current = current.next;
                        }
                        else
                        {
                            frontSwitchMade = false;
                        }
                        break;
                }
            }
            //Lijst C
            current = startC;
            for (int i = 0; i < 24; i++)
            {
                switch (i)
                {
                    case 5:
                        addBackSwitch(backSwitchC, false, current);
                        current.next = backSwitchC;
                        current = current.next;
                        break;
                    case 7:
                        if (frontSwitchB.previous == null)
                        {
                            frontSwitchB.previous = current;
                        }
                        current.next = frontSwitchB;
                        current = current.next;
                        current.next = addFrontSwitch(frontSwitchB, false, current);
                        current = current.next;

                        frontSwitchMade = true;
                        break;
                    case 14:
                        QuaySpace tempQuay = new QuaySpace();
                        tempQuay.previous = current;
                        current.next = tempQuay;
                        current = current.next;
                        break;
                    case 23:
                        EndSpace tempEnd = new EndSpace();
                        tempEnd.previous = current;
                        current.next = tempEnd;
                        current = current.next;
                        break;
                    default:
                        if (!frontSwitchMade)
                        {
                        RailSpace temp = new RailSpace();
                        temp.previous = current;
                        current.next = temp;
                        current = current.next;
                         }
                         else
                         {
                             frontSwitchMade = false;
                         }
                        break;
                }

            }
            //Lijst B
            current = startB;
            for (int i = 0; i < 13; i++)
            {
                switch (i)
                {
                    case 2:
                        backSwitchA = addBackSwitch(backSwitchA, false, current);
                        current.next = backSwitchA;
                        current = current.next;
                        break;
                    case 4:
                        if (frontSwitchA.previous == null)
                        {
                            frontSwitchA.previous = current;
                        }
                        current.next = frontSwitchA;
                        current = current.next;
                        current.next = addFrontSwitch(frontSwitchA, false, current);
                        current = current.next;
                        frontSwitchMade = true;
                        break;
                    case 7:
                        backSwitchC = addBackSwitch(backSwitchC, true, current);
                        current.next = backSwitchC;
                        current = current.next;
                        break;
                    case 9:
                        if (frontSwitchB.previous == null)
                        {
                            frontSwitchB.previous = current;
                        }
                        current.next = frontSwitchB;
                        current = current.next;
                        current.next = addFrontSwitch(frontSwitchB, true, current);
                        current = current.next;
                        frontSwitchMade = true;
                        break;
                    case 12:
                        backSwitchB = addBackSwitch(backSwitchB, false, current);
                        current.next = backSwitchB;
                        current = current.next;
                        break;
                    case 3:
                    case 8:
                        current = current.next;
                        break;
                    default:
                        if (!frontSwitchMade)
                        {
                            RailSpace temp = new RailSpace();
                            temp.previous = current;
                            current.next = temp;
                            current = current.next;
                        }
                        else
                        {
                            frontSwitchMade = false;
                        }
                        break;
                }
            }

            boardTest();
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
            Console.WriteLine("");
            Console.WriteLine("Switch all!");
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
                Console.Write(current.symbol);
                current = current.next;
            }
            Console.WriteLine("");
        }

        private Space addFrontSwitch(FrontSwitchSpace frontSwitch, bool isUp, Space current)
        {
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
            current.previous = frontSwitch;
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
