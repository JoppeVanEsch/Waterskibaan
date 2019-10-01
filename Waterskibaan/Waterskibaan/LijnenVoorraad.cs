using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class LijnenVoorraad
    {
        Queue<Lijn> _lijnen = new Queue<Lijn>();

        public void LijnToevoegenAanRij(Lijn lijn)
        {
            _lijnen.Enqueue(lijn);
        }

        public Lijn VerwijderEersteLijn()
        {
            if (GetAantalLijnen() == 0)
            {
                return null;
            }
            return _lijnen.Dequeue();
        }
        public int GetAantalLijnen()
        {
            return _lijnen.Count();
        }

        public override string ToString()
        {
            return $"{GetAantalLijnen()} lijnen op voorraad";
        }
    }
}
