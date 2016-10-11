using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goudkoorts.Models;

namespace Goudkoorts.Views
{
    class BoardView
    {
        public void DrawBoard(Board board)
        {
            Console.Clear();
            bool frontA = board.FrontSwitchA.switchIsUp;
            bool frontB = board.FrontSwitchB.switchIsUp;
            Space current;

            //regel 1
            current = board.BoatTop;
            for (int i = 0; i < 33; i++)
            {
                current = current.Next;
            }
            for (int reverse = 33; reverse > 16; reverse--)
            {
                Console.Write(current.GetSymbol());
                current = current.Previous;
            }
            Console.WriteLine("");

            //regel 2
            current = board.BoatTop;
            for (int i = 0; i < 16; i++)
            {
                Console.Write(current.GetSymbol());
                current = current.Next;
            }
            Console.WriteLine("");
            //regel 3
            if (!board.FrontSwitchA.switchIsUp)
            {
                board.FrontSwitchA.switchIsUp = true;
                board.FrontSwitchA.Next = board.FrontSwitchA.switchUp;
            }
            Console.Write("         ");
            current = board.StartA;
            for (int i = 0; i < 27; i++)
            {
                current = current.Next;
            }
            for (int reverse = 27; reverse > 15; reverse--)
            {
                Console.Write(current.GetSymbol() + "  ");
                current = current.Previous;
            }
            Console.WriteLine("");

            //regel 4
            Console.Write("                                                 ");
            Console.WriteLine(current.GetSymbol());

            //regel 5
            current = board.StartA;
            for (int i = 0; i < 3; i++)
            {
                Console.Write(current.GetSymbol() + "  ");
                current = current.Next;
            }
            Console.Write("            ");
            for (int i = 0; i < 8; i++)
            {
                if (i >= 3 && i <= 7)
                {
                    Console.Write(current.GetSymbol() + "   ");
                }
                current = current.Next;
            }
            Console.Write("      ");
            for (int i = 0; i < 4; i++)
            {
                if (i == 3)
                {
                    Console.Write(current.GetSymbol() + "  ");
                }
                current = current.Next;
            }
            Console.WriteLine("");

            //regel 6
            current = board.StartA;
            Console.Write("         ");
            for (int i = 0; i < 6; i++)
            {
                if (i >= 3 && i <= 5)
                {
                    Console.Write(current.GetSymbol() + " ");
                }
                current = current.Next;
            }
            Console.Write("                  ");
            for (int i = 0; i < 9; i++)
            {
                if (i >= 5 && i <= 7)
                {
                    Console.Write(current.GetSymbol() + " ");
                }
                current = current.Next;
            }
            Console.WriteLine("");

            //regel 7
            if (board.FrontSwitchA.switchIsUp)
            {
                board.FrontSwitchA.switchIsUp = false;
                board.FrontSwitchA.Next = board.FrontSwitchA.switchDown;
            }
            if (!board.FrontSwitchB.switchIsUp)
            {
                board.FrontSwitchB.switchIsUp = true;
                board.FrontSwitchB.Next = board.FrontSwitchB.switchUp;
            }

            current = board.StartB;
            for (int i = 0; i < 3; i++)
            {
                Console.Write(current.GetSymbol() + "  ");
                current = current.Next;
            }
            Console.Write("           ");
            for(int i = 0; i < 5; i++)
            {
                if (i >= 3 && i <= 4)
                {
                    Console.Write(current.GetSymbol() + " ");
                }
                current = current.Next;
            }

            Console.Write("            ");
            for(int i = 0; i < 5; i++)
            {
                if (i >= 3 && i <= 4)
                {
                    Console.Write(current.GetSymbol() + " ");
                }
                current = current.Next;
            }
            Console.WriteLine("");

            //regel 8

            current = board.StartB;
            Console.Write("                         ");
            for (int i = 0; i < 11; i++)
            {
                if (i >= 8 && i <= 10)
                {
                    Console.Write(current.GetSymbol() + " ");
                }
                current = current.Next;
            }
            Console.WriteLine("");

            //regel 9

            if (board.FrontSwitchB.switchIsUp)
            {
                board.FrontSwitchB.switchIsUp = false;
                board.FrontSwitchB.Next = board.FrontSwitchB.switchDown;
            }
            Console.Write("  ");
            current = board.StartC;
            for (int i = 0; i < 6; i++)
            {
                Console.Write(current.GetSymbol() + "   ");
                current = current.Next;
            }

            Console.Write("          ");
            for (int i = 0; i < 6; i++)
            {
                if (i >= 3 && i <= 5)
                {
                    Console.Write(current.GetSymbol() + "  ");
                }
                current = current.Next;
            }
            Console.WriteLine("");

            //regel 10
            Console.Write("                                            ");
            Console.Write(current.GetSymbol());
            Console.WriteLine("");

            //regel 11
            Console.Write("    ");
            while (current.Next != null)
            {
                current = current.Next;
            }

            for (int reverse = 0; reverse < 12; reverse++)
            {
                Console.Write(current.GetSymbol() + "  ");
                current = current.Previous;
            }
            Console.WriteLine("");

            if (board.FrontSwitchA.switchIsUp != frontA)
            {
                board.FrontSwitchA.Switch();
            }
            if (board.FrontSwitchB.switchIsUp != frontB)
            {
                board.FrontSwitchB.Switch();
            }

            //regel 12
            current = board.BoatBottom;
            for (int i = 0; i < 16; i++)
            {
                Console.Write(current.GetSymbol());
                current = current.Next;
            }
            Console.WriteLine("");

            //regel 13
            current = board.BoatBottom;
            for (int i = 0; i < 33; i++)
            {
                current = current.Next;
            }
            for (int reverse = 33; reverse > 16; reverse--)
            {
                Console.Write(current.GetSymbol());
                current = current.Previous;
            }
            Console.WriteLine("");
        }
    }
}
