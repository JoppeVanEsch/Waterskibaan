using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Kabel
    {
        private LinkedList<Lijn> _lijnen = new LinkedList<Lijn>();

        public bool IsStartPositieLeeg()
        {
            if (_lijnen.Count == 0 || _lijnen.First.Value.PositieOpDeKabel > 0)
            {
                return true;
            }
            return false;
        }

        public void NeemLijnInGebruik(Lijn lijn)
        {
            if (IsStartPositieLeeg())
            {
                //lijn.PositieOpDeKabel = 0;
                _lijnen.AddFirst(lijn);
            }
        }

        public void VerschuiftLijnen()
        {
            foreach (Lijn lijn in _lijnen)
            {
                if (lijn.PositieOpDeKabel < 9)
                {
                    lijn.PositieOpDeKabel++;
                }
                else
                {
                    //_lijnen.Remove(lijn);
                    //_lijnen.AddFirst(lijn);
                    lijn.PositieOpDeKabel = 0;
                    if (lijn.Sporter.AantalRondenNogTeGaan > 0)
                    {
                        Console.WriteLine("Ronde minder");
                        lijn.Sporter.AantalRondenNogTeGaan--;
                    }
                    //break;
                }
            }
        }

        public Lijn VerwijderLijnVanKabel()
        {
            foreach (Lijn lijn in _lijnen)
            {
                if (lijn.PositieOpDeKabel == 9 && lijn.Sporter.AantalRondenNogTeGaan == 1)
                {
                    //_lijnen.Remove(lijn);
                    return lijn;
                }
            }
            return null;
        }

        public override string ToString()
        {
            string returnString = "Kabel: ";
            int i = 0;
            foreach (Lijn lijn in _lijnen)
            {
                if (i > 0)
                {
                    returnString += "|";
                }
                returnString += lijn.PositieOpDeKabel.ToString();
                i++;
            }
            return returnString;
        }
    }
}
