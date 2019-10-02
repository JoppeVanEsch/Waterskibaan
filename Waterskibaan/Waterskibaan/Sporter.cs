using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Sporter
    {
        public int AantalRondenNogTeGaan { get; set; }
        public Zwemvest Zwemvest { get; set; }
        public Skies Skies { get; set; }
        public Color KledingKleur { get; set; }
        public List<IMoves> Moves { get; set; }

        public Sporter(List<IMoves> moves)
        {
            Random random = new Random();
            Color color = new Color();

            int R = (byte)random.Next(0, 255);
            int G = (byte)random.Next(0, 255);
            int B = (byte)random.Next(0, 255);
            color = Color.FromArgb(R, G, B);

            KledingKleur = color;
            Moves = moves;
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
