using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class Kabel
    {
        public LinkedList<Lijn> Lijnen { get; } = new LinkedList<Lijn>();

        public bool IsStartPositieLeeg()
        {
            if (Lijnen.Count == 0 || Lijnen.First.Value.PositieOpDeKabel > 0)
            {
                return true;
            }
            return false;
        }

        public void NeemLijnInGebruik(Lijn lijn)
        {
            if (IsStartPositieLeeg())
            {
                lijn.PositieOpDeKabel = 0;
                Lijnen.AddFirst(lijn);
            }
        }

        public void VerschuiftLijnen()
        {
            if (Lijnen?.Last?.Value?.PositieOpDeKabel >= 9)
            {
                Lijn lijnL = Lijnen.Last.Value;
                lijnL.PositieOpDeKabel = -1;
                lijnL.Sporter.AantalRondenNogTeGaan--;
                Lijnen.RemoveLast();
                Lijnen.AddFirst(lijnL);
            }
            foreach (Lijn lijn in Lijnen)
            {
                if (lijn.PositieOpDeKabel < 9)
                {
                    lijn.PositieOpDeKabel++;
                }
                /*else
                {
                    Lijnen.Remove(lijn);
                    Lijnen.AddFirst(lijn);
                    lijn.PositieOpDeKabel = 0;
                    if (lijn.Sporter.AantalRondenNogTeGaan > 0)
                    {
                        Console.WriteLine("Ronde minder");
                        lijn.Sporter.AantalRondenNogTeGaan--;
                    }
                    break;
                }*/
            }

        }

        public Lijn VerwijderLijnVanKabel()
        {
            foreach (Lijn lijn in Lijnen)
            {
                if (lijn.PositieOpDeKabel == 9 && lijn.Sporter.AantalRondenNogTeGaan <= 0)
                {
                    Lijnen.Remove(lijn);
                    return lijn;
                }
            }
            return null;
        }

        public override string ToString()
        {
            string returnString = "Kabel: ";
            int i = 0;
            foreach (Lijn lijn in Lijnen)
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
