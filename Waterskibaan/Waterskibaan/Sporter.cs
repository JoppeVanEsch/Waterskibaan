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
        private int _aantalRondenNogTeGaan;
        private Zwemvest _zwemvest;
        private Skies _skies;
        private Color _kledingKleur;
        private List<IMoves> _moves;
        private int _score;

        public int AantalRondenNogTeGaan { get => _aantalRondenNogTeGaan; set => _aantalRondenNogTeGaan = value; }
        public Zwemvest Zwemvest { get => _zwemvest; set => _zwemvest = value; }
        public Skies Skies { get => _skies; set => _skies = value; }
        public Color KledingKleur { get => _kledingKleur; set => _kledingKleur = value; }
        public List<IMoves> Moves { get => _moves; set => _moves = value; }
        public int Score { get => _score; set => _score = value; }

        public Sporter(List<IMoves> moves)
        {
            Random random = new Random();

            int R = (byte)random.Next(0, 255);
            int G = (byte)random.Next(0, 255);
            int B = (byte)random.Next(0, 255);
            Color color = Color.FromArgb(R, G, B);

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
