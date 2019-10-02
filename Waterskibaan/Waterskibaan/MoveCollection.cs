using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    static class MoveCollection
    {
        static List<IMoves> moves = new List<IMoves>();

        public static List<IMoves> GetWillekeurigeMoves()
        {
            Random random1 = new Random();
            Random random2 = new Random();

            int aantalMoves = random1.Next(1, 9);

            for (int i = 0; i < aantalMoves; i++)
            {
                int welkeMove = random2.Next(1,4);

                switch (welkeMove)
                {
                    case 1:
                        moves.Add(new Jump());
                        break;
                    case 2:
                        moves.Add(new Omdraaien());
                        break;
                    case 3:
                        moves.Add(new EenBeen());
                        break;
                    case 4:
                        moves.Add(new EenHand());
                        break;
                    case 5:
                        moves.Add(new Jump());
                        break;
                }
            }
            return moves;
        }
    }
}
