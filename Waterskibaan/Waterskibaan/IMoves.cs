﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public interface IMoves
    {
        int MoelijkheidGraad { get; }
        int Score { get; }
        int Move();
    }
}
