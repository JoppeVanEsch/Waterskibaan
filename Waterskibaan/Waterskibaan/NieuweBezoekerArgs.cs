using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class NieuweBezoekerArgs : EventArgs
    {
        public Sporter Sporter { get; set; }
    }
}