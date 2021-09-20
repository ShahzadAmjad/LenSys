using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.Busniess
{
    public class MockBusniessRepository : IBusniessRepository
    {
        private List<Busniess> _busniess;
        public MockBusniessRepository()
        {
            //_busniess = new List<Busniess>()
            //{
            //                    new Busniess{

            //                        SecurityDetailsId=1,
            //                        Notes="Security Property",
            //                        LegalChargeOverProperty="YES",
            //                        SecurityType= "Residential ",
            //                        PropertyType="1 Bed Appartment",
            //                        NameOfPropertyOwner = "John",
            //                        Tenure= 2,
            //                        YearsRemainingOnLeaseIfLeaseHold= 1,
            //                        PropertyValue= 5454,
            //                        OriginalPurchasePrice= 6000,
            //                        AddressForPropertyOfSecurity="Russia",
            //                        SecondLineAddress= "Cremlin",
            //                        City= "Moscow",
            //                        PostCode= 85000

            //                    }
            //};
        }
        public Busniess Add(Busniess busniess)
        {
            throw new NotImplementedException();
        }

        public Busniess Delete(int BusniessId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Busniess> GetAllBusniess()
        {
            throw new NotImplementedException();
        }

        public Busniess GetBusniess(int BusniessId)
        {
            throw new NotImplementedException();
        }

        public Busniess Update(Busniess busniessChanges)
        {
            throw new NotImplementedException();
        }
    }
}
