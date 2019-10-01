﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Waterskibaan
    {
        public LijnenVoorraad LijnenVoorraad { get; }
        public Kabel Kabel { get; }

        public Waterskibaan(LijnenVoorraad lijnenVoorraad, Kabel kabel)
        {
            for (int i = 0; i < 15; i++)
            {
                lijnenVoorraad.LijnToevoegenAanRij(new Lijn());
            }

            LijnenVoorraad = lijnenVoorraad;
            Kabel = kabel;
        }

        public void VerplaatsKabel()
        {
            Kabel.VerschuiftLijnen();
            Lijn tempKabel = Kabel.VerwijderLijnVanKabel();
            if (tempKabel != null)
            {
                LijnenVoorraad.LijnToevoegenAanRij(tempKabel);
            }
        }

        public override string ToString()
        {
            return LijnenVoorraad.ToString() + " " + Kabel.ToString();
        }
    }
}
