﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class Train
    {
        public Char symbol;
        public bool isFull;

        public Train()
        {
            isFull = true;
            this.symbol = '#';
        }
    }
}
