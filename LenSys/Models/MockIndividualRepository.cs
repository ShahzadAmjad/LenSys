using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models
{
    public class MockIndividualRepository : IindividualRepository
    {
        private List<Individual> _individualList;
        public MockIndividualRepository()
        {
                
        }
        public Individual Add(Individual employee)
        {
            throw new NotImplementedException();
        }
    }
}
