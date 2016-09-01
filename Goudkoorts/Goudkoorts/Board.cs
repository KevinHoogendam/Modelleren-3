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
            frontSwitchA = new FrontSwitchSpace();
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
                        addBackSwitch(backSwitchA, true, current);
                        break;
                    case 4:
                        current = addFrontSwitch(frontSwitchA, true, current);
                        frontSwitchMade = true;
                        break;
                    case 10:
                        addBackSwitch(backSwitchB, true, current);
                        break;
                    case 17:
                        current.next = new QuaySpace();
                        break;
                    default:
                        if(!frontSwitchMade)
                        {
                            current.next = new Space();
                        }
                        else
                        {
                            frontSwitchMade = false;
                        }
                        break;
                }
            }
            current = startB;
            for (int i = 0; i < 12; i++)
            {
                switch (i)
                {
                    case 2:
                        addBackSwitch(backSwitchA, false, current);
                        break;
                    case 4:
                        current = addFrontSwitch(frontSwitchA, false, current);
                        frontSwitchMade = true;
                        break;
                    case 7:
                        addBackSwitch(backSwitchC, true, current);
                        break;
                    case 9:
                        current = addFrontSwitch(frontSwitchB, true, current);
                        frontSwitchMade = true;
                        break;
                    case 12:
                        addBackSwitch(backSwitchB, false, current);
                        break;
                    case 3:
                    case 8:
                        current = current.next;
                        break;
                    default:
                        if (!frontSwitchMade)
                        {
                            current.next = new Space();
                        }
                        else
                        {
                            frontSwitchMade = false;
                        }
                        break;
                }
            }
            current = startC;
            for (int i = 0; i < 23; i++)
            {
                switch (i)
                {
                    case 5:
                        addBackSwitch(backSwitchC, false, current);
                        break;
                    case 7:
                        current = addFrontSwitch(frontSwitchB, false, current);
                        frontSwitchMade = true;
                        break;
                    case 14:
                        current.next = new QuaySpace();
                        break;
                    default:
                        if (!frontSwitchMade)
                        {
                            current.next = new Space();
                        }
                        else
                        {
                            frontSwitchMade = false;
                        }
                        break;
                }
            }
        }
        private Space addFrontSwitch(FrontSwitchSpace frontSwitch, bool isUp, Space current)
        {
            current.next = frontSwitch;
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
            return current;
        }
        private void addBackSwitch(BackSwitchSpace backSwitch, bool isUp, Space current)
        {
            current.next = backSwitch;
            if (isUp)
            {
                backSwitch.switchUp = current;
            }
            else
            {
                backSwitch.switchDown = current;
            }
        }
    }
}
