using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.IndividualPersonalDetails
{
    public class MockPersonalDetailsRepository : IPersonalDetailsRepository
    {
        private List<PersonalDetails> _personalDetails;
        public MockPersonalDetailsRepository()
        {

        }
        public PersonalDetails Add(PersonalDetails personalDetails)
        {
            throw new NotImplementedException();
        }
    }
}
