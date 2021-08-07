using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.IndividualEmploymentDetails
{
    public class MockEmploymentDetails : IEmploymentDetails
    {
        private List<EmploymentDetails> _employmentDetails;
        public MockEmploymentDetails()
        {

        }
        public EmploymentDetails Add(EmploymentDetails addressDetails)
        {
            throw new NotImplementedException();
        }
    }
}
