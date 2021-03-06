﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class Jump : IMoves
    {
        public string name { get { return "Jump"; } }

        public int MoelijkheidGraad { get { return 30; } }

        public int Score { get { return 70; } }

        public int Move()
        {
            Random random = new Random();
            int successChance = random.Next(0, 100);

            if (successChance < MoelijkheidGraad)
            {
                return 0;
            }
            return Score;
        }
    }

    public class Omdraaien : IMoves
    {
        public string name { get { return "Omdraaien"; } }

        public int MoelijkheidGraad { get { return 20; } }

        public int Score { get { return 80; } }

        public int Move()
        {
            Random random = new Random();
            int successChance = random.Next(0, 100);

            if (successChance < MoelijkheidGraad)
            {
                return 0;
            }
            return Score;
        }
    }

    public class EenBeen : IMoves
    {
        public string name { get { return "EenBeen"; } }
        public int MoelijkheidGraad { get { return 50; } }
        public int Score { get { return 50; } }

        public int Move()
        {
            Random random = new Random();
            int successChance = random.Next(0, 100);

            if (successChance < MoelijkheidGraad)
            {
                return 0;
            }
            return Score;
        }
    }
    public class EenHand : IMoves
    {
        public string name { get { return "EenHand"; } }
        public int MoelijkheidGraad { get { return 80; } }
        public int Score { get { return 20; } }

        public int Move()
        {
            Random random = new Random();
            int successChance = random.Next(0, 100);

            if (successChance < MoelijkheidGraad)
            {
                return 0;
            }
            return Score;
        }
    }
}
