using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.IndividualLiabilities
{
    interface ILiabilitiesRepository
    {
        Liabilities Add(Liabilities liabilities);
    }
}
