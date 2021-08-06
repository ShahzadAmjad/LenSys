using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.IndividualAddressDetails
{
    interface IAddressDetails
    {
        AddressDetails Add(AddressDetails addressDetails);
    }
}
