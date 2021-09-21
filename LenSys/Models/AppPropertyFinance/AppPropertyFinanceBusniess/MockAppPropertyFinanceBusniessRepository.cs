using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppPropertyFinance.AppPropertyFinanceBusniess
{
    public class MockAppPropertyFinanceBusniessRepository : IAppPropertyFinanceBusniessRepository
    {
        private List<AppPropertyFinanceBusniess> _busniess;
        public MockAppPropertyFinanceBusniessRepository()
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
        public AppPropertyFinanceBusniess Add(AppPropertyFinanceBusniess busniess)
        {
            if (_busniess.Count == 0)
            {
                busniess.BusniessId = 0;

            }
            else
            {
                busniess.BusniessId = _busniess.Max(e => e.BusniessId) + 1;
            }

            _busniess.Add(busniess);
            return busniess;
        }

        public AppPropertyFinanceBusniess Delete(int BusniessId)
        {
            AppPropertyFinanceBusniess busniess = _busniess.FirstOrDefault(e => e.BusniessId == BusniessId);
            if (_busniess != null)
            {
                _busniess.Remove(busniess);
            }
            return busniess;
        }

        public IEnumerable<AppPropertyFinanceBusniess> GetAllBusniess()
        {
            return _busniess;
        }

        public AppPropertyFinanceBusniess GetBusniess(int BusniessId)
        {
            return _busniess.FirstOrDefault(e => e.BusniessId == BusniessId);
        }

        public AppPropertyFinanceBusniess Update(AppPropertyFinanceBusniess model)
        {
            AppPropertyFinanceBusniess busniess = _busniess.FirstOrDefault(e => e.BusniessId == model.BusniessId);
            if (busniess != null)
            {
                //appBusniessFinanceSecurityDetails.Notes = model.Notes;
                //appBusniessFinanceSecurityDetails.LegalChargeOverProperty = model.LegalChargeOverProperty;
                //appBusniessFinanceSecurityDetails.SecurityType = model.SecurityType;
                //appBusniessFinanceSecurityDetails.PropertyType = model.PropertyType;
                //appBusniessFinanceSecurityDetails.NameOfPropertyOwner = model.NameOfPropertyOwner;
                //appBusniessFinanceSecurityDetails.Tenure = model.Tenure;
                //appBusniessFinanceSecurityDetails.YearsRemainingOnLeaseIfLeaseHold = model.YearsRemainingOnLeaseIfLeaseHold;

                //appBusniessFinanceSecurityDetails.PropertyValue = model.PropertyValue;
                //appBusniessFinanceSecurityDetails.OriginalPurchasePrice = model.OriginalPurchasePrice;
                //appBusniessFinanceSecurityDetails.AddressForPropertyOfSecurity = model.AddressForPropertyOfSecurity;
                //appBusniessFinanceSecurityDetails.SecondLineAddress = model.SecondLineAddress;
                //appBusniessFinanceSecurityDetails.City = model.City;
                //appBusniessFinanceSecurityDetails.PostCode = model.PostCode;

            }
            return busniess;
        }
    }
}
