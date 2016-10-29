using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goudkoorts.Controllers;

namespace Goudkoorts
{
    class Program
    {
        public GameController Game
        {
            get;
            set;
        }
    
        static void Main(string[] args)
        {
            GameController Game = new GameController();
            Game.StartGame();
            Console.ReadKey();
        }
    }
}
