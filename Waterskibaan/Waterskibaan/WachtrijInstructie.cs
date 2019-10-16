using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class WachtrijInstructie : Wachtrij
    {
        public override int MAX_LENGTE_RIJ { get { return 100; } }

        public WachtrijInstructie() {}

        public void NieuweBezoeker(NieuweBezoekerArgs args)
        {
            SporterNeemPlaatsInRij(args.Sporter);
        }

        public override string ToString()
        {
            return $"instructie wachtrij: {GetAlleSporters().Count}";
        }
    }
}
