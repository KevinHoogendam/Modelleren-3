using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class GameController
    {
        public BoardView boardView;

        public GameController()
        {
            boardView = new BoardView();
        }

        public void StartGame()
        {
            boardView.DrawBoard();
        }
    }
}
