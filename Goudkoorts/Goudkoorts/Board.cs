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
            startA = new StartSpace();
            startB = new StartSpace();
            startC = new StartSpace();
            backSwitchA = new BackSwitchSpace();
            backSwitchB = new BackSwitchSpace();
            backSwitchC = new BackSwitchSpace();
            frontSwitchA = new FrontSwitchSpace();
            frontSwitchB = new FrontSwitchSpace();
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
                    default:
                        if (!frontSwitchMade)
                        {
                            Space temp = new Space();
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
                    default:
                        if (!frontSwitchMade)
                        {
                        Space temp = new Space();
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
                            Space temp = new Space();
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
            backSwitchA.Switch();
            backSwitchB.Switch();
            backSwitchC.Switch();
            frontSwitchA.Switch();
            frontSwitchB.Switch();
            Console.WriteLine("Lijst A:");
            Space current = startA;
            while (current != null)
            {
                Console.WriteLine(current);
                current = current.next;
            }
            Console.WriteLine("");
            Console.WriteLine("Lijst B:");
            current = startB;
            while (current != null)
            {
                Console.WriteLine(current);
                current = current.next;
            }
            Console.WriteLine("");
            Console.WriteLine("Lijst C:");
            current = startC;
            while (current != null)
            {
                Console.WriteLine(current);
                current = current.next;
            }

            Console.WriteLine("");
            Console.WriteLine("Switch");
            Console.WriteLine("");

            backSwitchA.Switch();
            backSwitchB.Switch();
            backSwitchC.Switch();
            frontSwitchA.Switch();
            frontSwitchB.Switch();
            Console.WriteLine("Lijst A:");
            current = startA;
            while (current.next != null)
            {
                Console.WriteLine(current);
                current = current.next;
            }
            Console.WriteLine("");
            Console.WriteLine("Lijst B:");
            current = startB;
            while (current.next != null)
            {
                Console.WriteLine(current);
                current = current.next;
            }
            Console.WriteLine("");
            Console.WriteLine("Lijst C:");
            current = startC;
            while (current.next != null)
            {
                Console.WriteLine(current);
                current = current.next;
            }
        }
        private Space addFrontSwitch(FrontSwitchSpace frontSwitch, bool isUp, Space current)
        {
            if(isUp)
            {
                frontSwitch.switchUp = new Space();
                current = frontSwitch.switchUp;
            }
            else
            {
                frontSwitch.switchDown = new Space();
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
