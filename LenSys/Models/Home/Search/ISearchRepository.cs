using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.Home.Search
{
    public interface ISearchRepository
    {
        Search PerformSearch(Search search);
    }
}
