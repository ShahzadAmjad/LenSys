using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models
{
    interface IindividualRepository
    {
        Individual Add(Individual employee);
    }
}
