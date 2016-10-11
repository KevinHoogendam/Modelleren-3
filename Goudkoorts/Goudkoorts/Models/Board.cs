using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Models
{
    class Board
    {
        public StartSpace StartA;
        public StartSpace StartB;
        public StartSpace StartC;

        public BackSwitchSpace BackSwitchA;
        public BackSwitchSpace BackSwitchB;
        public BackSwitchSpace BackSwitchC;
        public FrontSwitchSpace FrontSwitchA;
        public FrontSwitchSpace FrontSwitchB;

        public QuaySpace QuayTop;
        public QuaySpace QuayBottom;

        public EndSpace EndTop;
        public EndSpace EndBottom;

        public BoatSpace BoatTop;
        public BoatSpace BoatBottom;

        public BoatLoadingSpace LoadTop;
        public BoatLoadingSpace LoadBottom;

        public Board()
        {
            StartA = new StartSpace("A");
            StartB = new StartSpace("B");
            StartC = new StartSpace("C");
            BackSwitchA = new BackSwitchSpace("A");
            BackSwitchB = new BackSwitchSpace("C");
            BackSwitchC = new BackSwitchSpace("D");
            FrontSwitchA = new FrontSwitchSpace("B");
            FrontSwitchB = new FrontSwitchSpace("E");
            QuayTop = new QuaySpace();
            QuayBottom = new QuaySpace();
            EndTop = new EndSpace();
            EndBottom = new EndSpace();
            BoatTop = new BoatSpace();
            BoatBottom = new BoatSpace();
            LoadBottom = new BoatLoadingSpace();
            LoadTop = new BoatLoadingSpace();
        }
    }
}