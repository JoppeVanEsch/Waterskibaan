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
        static void Main(string[] args)
        {
            //TestOpdracht2();
            //TestOpdracht3();
            TestOpdracht4();
        }

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
            for (int i = 0; i < 10; i++)
            {
                kabel.VerschuiftLijnen();
                Console.WriteLine(kabel.ToString());
            }
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

        private static void TestOpdracht3()
        {
            LijnenVoorraad lijnenVoorraad = new LijnenVoorraad();
            //Lijn lijn = new Lijn();
            //Lijn lijn1 = new Lijn();
            //Lijn lijn2 = new Lijn();
            for (int i = 0; i < 5; i++)
            {
                lijnenVoorraad.LijnToevoegenAanRij(new Lijn());
            }
            Console.WriteLine(lijnenVoorraad.ToString());
            lijnenVoorraad.VerwijderEersteLijn();
            Console.WriteLine(lijnenVoorraad.ToString());
        }
        private static void TestOpdracht4()
        {
            LijnenVoorraad lijnenVoorraad = new LijnenVoorraad();
            Kabel kabel = new Kabel();
            Waterskibaan waterskibaan = new Waterskibaan(lijnenVoorraad, kabel);
            Lijn lijn1 = new Lijn();
            Lijn lijn2 = new Lijn();
            Lijn lijn3 = new Lijn();
            kabel.NeemLijnInGebruik(lijn1);
            kabel.VerschuiftLijnen();
            kabel.NeemLijnInGebruik(lijn2);
            kabel.VerschuiftLijnen();
            kabel.NeemLijnInGebruik(lijn3);
            Console.WriteLine(waterskibaan.ToString());
            for (int i = 0; i < 15; i++)
            {
                waterskibaan.VerplaatsKabel();
                Console.WriteLine(waterskibaan.ToString());
            }
        }
    }
}
