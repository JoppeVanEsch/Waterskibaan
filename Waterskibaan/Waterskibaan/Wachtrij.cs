using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    abstract class Wachtrij
    {
        public abstract int MAX_LENGTE_RIJ { get; }
        private Queue<Sporter> _sporters = new Queue<Sporter>();
        public void SporterNeemPlaatsInRij(Sporter sporter)
        {
            if (_sporters.Count < MAX_LENGTE_RIJ)
            {
                _sporters.Enqueue(sporter);
            }
        }

        List<Sporter> GetAlleSporters()
        {
            return _sporters.ToList();
        }

        List<Sporter> SportersVerlatenRij(int aantal)
        {
            List<Sporter> l = new List<Sporter>();
            while (aantal > 0 && _sporters.Count > 0)
            {
                l.Add(_sporters.Dequeue());
                aantal--;
            }

            return l;
        }

        public override string ToString()
        {
            return $"{_sporters.Count} sporters in de wachtrij";
        }
    }
}
