using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goudkoorts.Models;

namespace Goudkoorts.Controllers
{
    class BoatController
    {
        public Board MoveBoats(Board board)
        {
            Space current = board.BoatTop;
            while (current.Next != null)
            {
                current = current.Next;
            }
            while (current.Previous != null)
            {
                current = MoveBoatOnSpace(current, board);
            }
            current = MoveBoatOnSpace(current, board);

            current = board.BoatBottom;
            while (current.Next != null)
            {
                current = current.Next;
            }
            while (current.Previous != null)
            {
                current = MoveBoatOnSpace(current, board);
            }
            current = MoveBoatOnSpace(current, board);
            return board;
        }

        private Space MoveBoatOnSpace(Space current, Board board)
        {
            if (current == board.LoadBottom || current == board.LoadTop)
            {
                if (current.Boat != null && current.Boat.isFull && current == current.Next.Previous)
                {
                    if (current.Next.Boat == null)
                    {
                        current.Next.Boat = current.Boat;
                        current.Boat = null;
                    }
                }
            }
            else if (current.Next != null)
            {
                if (current.Boat != null && current == current.Next.Previous)
                {
                    if (current.Next.Boat == null)
                    {
                        current.Next.Boat = current.Boat;
                        current.Boat = null;
                    }
                }
            }
            else if (current.Boat != null)
            {
                current.Boat = null;
            }
            if (current.Previous != null)
            {
                current = current.Previous;
            }
            return current;
        }
        public void GenerateNewBoat(Board board)
        {
            Random rnd = new Random();
            int list = rnd.Next(1, 3);
            if (list == 1)
            {
                board.BoatTop.Boat = new Boat();
            }
            else if (list == 2)
            {
                board.BoatBottom.Boat = new Boat();
            }
        }
    }
}
