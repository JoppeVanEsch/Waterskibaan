using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class Program
    {
        static void Main(string[] args)
        {
            //TestOpdracht2();
            //TestOpdracht3();
            //TestOpdracht4();
            //TestOpdracht5();
            //TestOpdracht7();
            //TestOpdracht8();
            //TestOpdracht10();
            //TestOpdracht11();
            //TestOpdracht12();
        }

        private static void TestOpdracht11()
        {
            //Game game = new Game();
            //game.Initialize();
        }

        static void TestOpdracht12()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Opdracht 12:");
            Console.ResetColor();

            //Game game = new Game();
            //game.Initialize();
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
            Waterskibaan waterskibaan = new Waterskibaan();
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

        private static void TestOpdracht5()
        {
            Sporter sporter = new Sporter(MoveCollection.GetWillekeurigeMoves());
            Console.WriteLine(sporter.ToString());
        }

        private static void TestOpdracht7()
        {
            LijnenVoorraad lijnenVoorraad = new LijnenVoorraad();
            Kabel kabel = new Kabel();
            Waterskibaan waterskibaan = new Waterskibaan(/*lijnenVoorraad, kabel*/);
            Skies skies = new Skies();
            Zwemvest zwemvest = new Zwemvest();
            Sporter sporter = new Sporter(MoveCollection.GetWillekeurigeMoves());

            sporter.Zwemvest = zwemvest;
            sporter.Skies = skies;
            waterskibaan.SporterStart(sporter);

            for (int i = 0; i < 15; i++)
            {
                waterskibaan.VerplaatsKabel();
                Console.WriteLine(waterskibaan.ToString());
            }

            //Console.WriteLine(sporter.ToString());
        }

        private static void TestOpdracht8()
        {
            LijnenVoorraad lijnenVoorraad = new LijnenVoorraad();
            Kabel kabel = new Kabel();
            Waterskibaan waterskibaan = new Waterskibaan(/*lijnenVoorraad, kabel*/);
            Sporter sporter = new Sporter(MoveCollection.GetWillekeurigeMoves());
            Skies skies = new Skies();
            Zwemvest zwemvest = new Zwemvest();

            sporter.Zwemvest = zwemvest;
            sporter.Skies = skies;
            waterskibaan.SporterStart(sporter);


            Console.WriteLine(sporter.ToString());
        }

        private static void TestOpdracht10()
        {

            WachtrijInstructie wachtrijInstructie = new WachtrijInstructie();
            InstructieGroep instructieGroep = new InstructieGroep();
            WachtrijStarten wachtrijStarten = new WachtrijStarten();

            Sporter sp1 = new Sporter(MoveCollection.GetWillekeurigeMoves());
            Sporter sp2 = new Sporter(MoveCollection.GetWillekeurigeMoves());
            Sporter sp3 = new Sporter(MoveCollection.GetWillekeurigeMoves());

            Console.WriteLine(wachtrijInstructie.ToString());
            wachtrijInstructie.SporterNeemPlaatsInRij(sp1);
            wachtrijInstructie.SporterNeemPlaatsInRij(sp2);
            Console.WriteLine(wachtrijInstructie.ToString());
            wachtrijInstructie.SporterNeemPlaatsInRij(sp3);
            Console.WriteLine(wachtrijInstructie.ToString());

            Console.WriteLine(instructieGroep.ToString());
            instructieGroep.SporterNeemPlaatsInRij(sp1);
            instructieGroep.SporterNeemPlaatsInRij(sp2);
            Console.WriteLine(instructieGroep.ToString());
            instructieGroep.SporterNeemPlaatsInRij(sp3);
            Console.WriteLine(instructieGroep.ToString());

            Console.WriteLine(wachtrijStarten.ToString());
            wachtrijStarten.SporterNeemPlaatsInRij(sp1);
            wachtrijStarten.SporterNeemPlaatsInRij(sp2);
            Console.WriteLine(wachtrijStarten.ToString());
            wachtrijStarten.SporterNeemPlaatsInRij(sp3);
            Console.WriteLine(wachtrijStarten.ToString());
        }
    }
}
