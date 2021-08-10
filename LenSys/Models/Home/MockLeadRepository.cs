using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.Home
{
    public class MockLeadRepository: ILeadRepository
    {
        private List<Lead> _lead;
        public MockLeadRepository()
        {
                
        }

        public Lead Add(Lead lead)
        {
            throw new NotImplementedException();
        }
    }
}
