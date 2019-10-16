using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class Logger
    {
        public List<Sporter> Bezoeker { get; }
        public Kabel Kabel;

        public Logger(Kabel kabel)
        {
            Bezoeker = new List<Sporter>();
            Kabel = kabel;
        }
    }
}
