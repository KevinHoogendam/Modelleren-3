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
                current = CheckSpace(current);
            }
            current = CheckSpace(current);

            current = board.BoatBottom;
            while (current.Next != null)
            {
                current = current.Next;
            }
            while (current.Previous != null)
            {
                current = CheckSpace(current);
            }
            current = CheckSpace(current);
            return board;
        }

        private Space CheckSpace(Space current)
        {
            current.Move();
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
