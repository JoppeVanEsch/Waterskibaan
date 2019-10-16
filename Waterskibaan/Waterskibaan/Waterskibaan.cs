using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class Waterskibaan
    {
        public LijnenVoorraad _lijnen = new LijnenVoorraad();
        public Kabel _kabel = new Kabel();
        public bool isGestart = false;

        public Waterskibaan()
        {
            for (int i = 0; i < 15; i++)
            {
                _lijnen.LijnToevoegenAanRij(new Lijn());
            }
        }

        public void SporterStart(Sporter sporter)
        {
            if (sporter.Skies == null || sporter.Zwemvest == null)
                throw new Exception("Een sporter heeft skies en een zwemvest nodig!");

            if (!_kabel.IsStartPositieLeeg()) return;

            Lijn lijn = _lijnen.VerwijderEersteLijn();

            lijn.Sporter = sporter;
            Random random = new Random();
            lijn.Sporter.AantalRondenNogTeGaan = random.Next(1, 2);

            _kabel.NeemLijnInGebruik(lijn);
        }

        public void VerplaatsKabel()
        {
            _kabel.VerschuiftLijnen();
            
            Lijn lijn = _kabel.VerwijderLijnVanKabel();
            if (lijn != null)
            {
                _lijnen.LijnToevoegenAanRij(lijn);
            }
        }

        public void Start()
        {
            isGestart = true;
        }

        public void Stop()
        {
            isGestart = false;
        }

        public override string ToString()
        {
            return _lijnen.ToString() + "\t" + _kabel.ToString();
        }
    }
}
