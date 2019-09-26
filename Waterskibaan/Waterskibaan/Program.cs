using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Program
    {
        private static void TestOpdracht2()
        {
            Kabel kabel = new Kabel();
            Lijn lijn = new Lijn();
            Lijn lijn1 = new Lijn();
            Lijn lijn2 = new Lijn();

            kabel.NeemLijnInGebruik(lijn);
            Console.WriteLine(kabel.ToString());
            kabel.VerschuiftLijnen();
            Console.WriteLine(kabel.ToString());
            kabel.VerschuiftLijnen();
            Console.WriteLine(kabel.ToString());
            kabel.NeemLijnInGebruik(lijn1);
            Console.WriteLine(kabel.ToString());
            kabel.NeemLijnInGebruik(lijn2);
            Console.WriteLine(kabel.ToString());
            for (int i = 0; i < 7; i++)
            {
                kabel.VerschuiftLijnen();
                Console.WriteLine(kabel.ToString());
            }
            kabel.VerwijderLijnVanKabel();
            Console.WriteLine(kabel.ToString());
            for (int i = 0; i < 7; i++)
            {
                kabel.VerschuiftLijnen();
                Console.WriteLine(kabel.ToString());
            }
        }

        static void Main(string[] args)
        {
            TestOpdracht2();
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
        int Move();
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

    class Kabel
    {
        LinkedList<Lijn> _lijnen = new LinkedList<Lijn>();

        public bool IsStartPositieLeeg()
        {
            if (_lijnen.Count == 0 || _lijnen.First.Value.PositieOpDeKabel >= 0)
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
                    _lijnen.Remove(lijn);
                    _lijnen.AddFirst(lijn);
                    lijn.PositieOpDeKabel = 0;
                }
            }
        }

        public Lijn VerwijderLijnVanKabel()
        {
            foreach (Lijn lijn in _lijnen)
            {
                if (lijn.PositieOpDeKabel == 9)
                {
                    return lijn;
                }
            }
            return null;
        }

        public override string ToString()
        {
            string returnString = null;
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
