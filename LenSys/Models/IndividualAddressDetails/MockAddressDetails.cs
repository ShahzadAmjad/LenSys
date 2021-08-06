using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.IndividualAddressDetails
{
    public class MockAddressDetails : IAddressDetails
    {
        private List<AddressDetails> _addressDetails;
        public MockAddressDetails()
        {

        }
        public AddressDetails Add(AddressDetails addressDetails)
        {
            throw new NotImplementedException();
        }
    }
}
