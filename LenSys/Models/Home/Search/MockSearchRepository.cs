using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.Home.Search
{
    public class MockSearchRepository : ISearchRepository
    {
        public MockSearchRepository()
        {

        }
        public Search PerformSearch(Search search)
        {
            throw new NotImplementedException();
        }
    }
}
