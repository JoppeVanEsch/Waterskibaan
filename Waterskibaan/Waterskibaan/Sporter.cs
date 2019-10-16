using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class Sporter
    {
        static int Counter = 0;
        public int Id;
        public int AantalRondenNogTeGaan { get; set; }
        public Zwemvest Zwemvest { get; set; }
        public Skies Skies { get; set; }
        public Color KledingKleur { get; set; }
        public List<IMoves> Moves { get; set; }
        public int Score { get; set; }
        public IMoves HuidigeMove { get; set; }

        public Sporter(List<IMoves> moves)
        {
            Random random = new Random();

            int R = (byte)random.Next(0, 255);
            int G = (byte)random.Next(0, 255);
            int B = (byte)random.Next(0, 255);
            Color color = Color.FromArgb(R, G, B);

            KledingKleur = color;
            Moves = moves;

            Id = Counter;
            Counter++;
        }

        public override string ToString()
        {
            string returnString = "Sporter:\n";
            foreach (IMoves move in Moves)
            {
                returnString += $"|{move}\t| Score: {move.Score}\t| Moeilijkheidsgraad: {move.MoelijkheidGraad} |\n";
            }
            return returnString;
        }
    }
}
