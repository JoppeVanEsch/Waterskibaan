﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Sporter
    {
        public int AantalRondenNogTeGaan { get; set; }
        public Zwemvest Zwemvest { get; set; }
        public Skies Skies { get; set; }
        public Color KledingKleur { get; set; }
        public List<IMoves> MyProperty { get; set; }

        public Sporter(List<IMoves> moves)
        {

        }
    }

    interface IMoves
    {
        public int Move()
        {
            return 1;
        }
    }

    class Lijn
    {
        public int PositieOpDeKabel { get; set; }
    }

    class Skies
    {

    }

    class Zwemvest
    {

    }
}
