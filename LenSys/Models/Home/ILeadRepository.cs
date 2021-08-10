using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.Home
{
    interface ILeadRepository
    {
        Lead Add(Lead lead);
    }
}
