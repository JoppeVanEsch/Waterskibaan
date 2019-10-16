using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class InstructieGroep : Wachtrij
    {
        public override int MAX_LENGTE_RIJ { get { return 5; } }

        public void InstructieAfgelopen(InstructieAfgelopenArgs args)
        {
            foreach (Sporter sporter in args.SportersNieuw)
            {
                SporterNeemPlaatsInRij(sporter);
            }
        }

        public override string ToString()
        {
            return $"Instructie groep: {GetAlleSporters().Count} wachtenden";
        }
    }
}
