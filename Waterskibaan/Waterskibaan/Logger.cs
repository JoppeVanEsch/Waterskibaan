using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class Logger
    {
        public List<Sporter> Bezoeker { get; set; }
        public Kabel Kabel;

        public Logger(Kabel kabel)
        {
            Bezoeker = new List<Sporter>();
            Kabel = kabel;
        }

        public void AddBezoeker(Sporter sporter)
        {
            Bezoeker.Add(sporter);
        }

        public int GetTotalBezoekers()
        {
            return Bezoeker.Count;
        }

        public int GetHighScore()
        {
            if (Bezoeker.Count > 0)
            {
                var highScore =
                    (from sporter in Bezoeker
                     where sporter.Score == (from sporter1 in Bezoeker select sporter1.Score).Max()
                     select sporter.Score).First();
            return highScore;
            }
            return 0;
        }

        public int GetAmountOfRedSporters()
        {
            var rodeSporter =
                (from sporter in Bezoeker
                 where ColorsAreClose(sporter.KledingKleur, Color.Red, 50)
                 select sporter.Score).Count();
            return rodeSporter;
        }

        public List<Color> GetListWithLightestClothes()
        {
            var LightSporter =
                (from sporter in Bezoeker
                 orderby CalculateColorValue(sporter.KledingKleur) descending
                 select sporter.KledingKleur).Take(10).ToList();
            return LightSporter;
        }

        public int GetAmountOfLaps()
        {
            var TotalLaps = Kabel.Laps;
            return TotalLaps;
        }

        public List<string> GetUniqueMoves()
        {
            List<IMoves> tempMoves = new List<IMoves>();

            foreach (Lijn lijn in Kabel.Lijnen)
            {
                lijn.Sporter.Moves.ForEach(move => tempMoves.Add(move));
            }

            return tempMoves.Select(move => move.name).Distinct().Take(10).ToList();

            /*
            List<IMoves> uniekeMoves = new List<IMoves>();
            Kabel.Lijnen.ToList().ForEach(line => line.Sporter.Moves.ForEach(move => uniekeMoves.Add(move)));
            uniekeMoves = uniekeMoves.Distinct().ToList();
            Console.WriteLine("-------------------/");
            foreach (var item in uniekeMoves)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------------------");

            return uniekeMoves;
            /*
            
            Kabel.Lijnen.ToList().ForEach(line => line.Sporter.Moves.ForEach(move => uniekeMoves.Add(move)));
            uniekeMoves = uniekeMoves.Distinct().ToList();

            var Moves =
                (from bezoeker in Kabel.Lijnen
                 select returnData =  from Sporter.Moves.ForEach(move => returnData.Add(move)));

            foreach (List<IMoves> list in Moves.ToList())
            {
                foreach (IMoves item in list)
                {
                    returnData.Add(item);
                }
            }
            return returnData.Distinct().ToList();*/
        }

        private bool ColorsAreClose(Color a, Color z, int threshold = 50)
        {
            int r = (int)a.R - z.R,
                g = (int)a.G - z.G,
                b = (int)a.B - z.B;
            return (r * r + g * g + b * b) <= threshold * threshold;
        }

        private int CalculateColorValue(Color color)
        {
            return (color.R * color.R + color.G * color.G + color.B * color.B);
        }
    }
}
