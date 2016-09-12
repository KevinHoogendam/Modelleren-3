using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class BoardController
    {
        public Board board;

        public BoardController()
        {
            board = new Board();
            board.CreateBoard();
        }

        public void DrawBoard()
        {
            bool frontA = board.frontSwitchA.switchIsUp;
            bool frontB = board.frontSwitchB.switchIsUp;
            Space current;

            //regel 1
            if (!board.frontSwitchA.switchIsUp)
            {
                board.frontSwitchA.switchIsUp = true;
                board.frontSwitchA.next = board.frontSwitchA.switchUp;
            }
            current = board.startA;
            for (int i = 0; i < 27; i++)
            {
                current = current.next;
            }
            for (int reverse = 27; reverse > 15; reverse--)
            {
                Console.Write(current.symbol + "  ");
                current = current.previous;
            }
            Console.WriteLine("");

            //regel 2
            Console.Write("                                         ");
            current = current.previous;
            Console.WriteLine(current.symbol);

            //regel 3
            current = board.startA;
            for (int i = 0; i < 3; i++)
            {
                Console.Write(current.symbol + "  ");
                current = current.next;
            }
            Console.Write("         ");
            for (int i = 0; i < 8; i++)
            {
                if (i >= 3 && i <= 7)
                {
                    Console.Write(current.symbol + "  ");
                }
                current = current.next;
            }
            Console.Write("      ");
            for (int i = 0; i < 4; i++)
            {
                if (i == 3)
                {
                    Console.Write(current.symbol + "  ");
                }
                current = current.next;
            }
            Console.WriteLine("");

            //regel 4
            current = board.startA;
            Console.Write("         ");
            for (int i = 0; i < 6; i++)
            {
                if (i >= 3 && i <= 5)
                {
                    Console.Write(current.symbol + " ");
                }
                current = current.next;
            }
            Console.Write("                ");
            for (int i = 0; i < 9; i++)
            {
                if (i >= 5 && i <= 7)
                {
                    Console.Write(current.symbol + " ");
                }
                current = current.next;
            }
            Console.WriteLine("");

            //regel 5
            if (board.frontSwitchA.switchIsUp)
            {
                board.frontSwitchA.switchIsUp = false;
                board.frontSwitchA.next = board.frontSwitchA.switchDown;
            }
            if (!board.frontSwitchB.switchIsUp)
            {
                board.frontSwitchB.switchIsUp = true;
                board.frontSwitchB.next = board.frontSwitchB.switchUp;
            }

            current = board.startB;
            for (int i = 0; i < 3; i++)
            {
                Console.Write(current.symbol + "  ");
                current = current.next;
            }
            Console.Write("       ");
            for(int i = 0; i < 5; i++)
            {
                if (i >= 3 && i <= 4)
                {
                    Console.Write(current.symbol + "  ");
                }
                current = current.next;
            }

            Console.Write("       ");
            for(int i = 0; i < 5; i++)
            {
                if (i >= 3 && i <= 4)
                {
                    Console.Write(current.symbol + "  ");
                }
                current = current.next;
            }
            Console.WriteLine("");

            //regel 6

            current = board.startB;
            Console.Write("                      ");
            for (int i = 0; i < 11; i++)
            {
                if (i >= 8 && i <= 10)
                {
                    Console.Write(current.symbol + " ");
                }
                current = current.next;
            }
            Console.WriteLine("");

            //regel 7

            if (board.frontSwitchB.switchIsUp)
            {
                board.frontSwitchB.switchIsUp = false;
                board.frontSwitchB.next = board.frontSwitchB.switchDown;
            }
            Console.Write("    ");
            current = board.startC;
            for (int i = 0; i < 6; i++)
            {
                Console.Write(current.symbol + "  ");
                current = current.next;
            }

            Console.Write("       ");
            for (int i = 0; i < 6; i++)
            {
                if (i >= 3 && i <= 5)
                {
                    Console.Write(current.symbol + "  ");
                }
                current = current.next;
            }
            Console.WriteLine("");

            //regel 8
            Console.Write("                                       ");
            current = current.next;
            Console.Write(current.symbol);
            Console.WriteLine("");

            //regel 9
            while (current.next != null)
            {
                current = current.next;
            }

            for (int reverse = 0; reverse < 12; reverse++)
            {
                Console.Write(current.symbol + "  ");
                current = current.previous;
            }
            Console.WriteLine("");

            if (board.frontSwitchA.switchIsUp != frontA)
            {
                board.frontSwitchA.Switch();
            }
            if (board.frontSwitchB.switchIsUp != frontB)
            {
                board.frontSwitchB.Switch();
            }
        }
    }
}
