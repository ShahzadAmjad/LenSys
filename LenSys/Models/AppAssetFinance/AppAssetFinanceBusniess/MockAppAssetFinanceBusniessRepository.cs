using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppAssetFinance.AppAssetFinanceBusniess
{
    public class MockAppAssetFinanceBusniessRepository : IAppAssetFinanceBusniessRepository
    {
        private List<AppAssetFinanceBusniess> _busniess;
        public MockAppAssetFinanceBusniessRepository()
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
        public AppAssetFinanceBusniess Add(AppAssetFinanceBusniess busniess)
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

        public AppAssetFinanceBusniess Delete(int BusniessId)
        {
            AppAssetFinanceBusniess busniess = _busniess.FirstOrDefault(e => e.BusniessId == BusniessId);
            if (_busniess != null)
            {
                _busniess.Remove(busniess);
            }
            return busniess;
        }

        public IEnumerable<AppAssetFinanceBusniess> GetAllBusniess()
        {
            return _busniess;
        }

        public AppAssetFinanceBusniess GetBusniess(int BusniessId)
        {
            return _busniess.FirstOrDefault(e => e.BusniessId == BusniessId);
        }

        public AppAssetFinanceBusniess Update(AppAssetFinanceBusniess model)
        {
            AppAssetFinanceBusniess busniess = _busniess.FirstOrDefault(e => e.BusniessId == model.BusniessId);
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
