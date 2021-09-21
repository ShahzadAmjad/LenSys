using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppAssetFinance.AppAssetFinanceIndividual
{
    public class MockAppAssetFinanceIndividualRepository : IAppAssetFinanceIndividualRepository
    {
        private List<AppAssetFinanceIndividual> _individual;
        public MockAppAssetFinanceIndividualRepository()
        {
            //_individual = new List<Individual>()
            //{
            //                    new Individual{

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
        public AppAssetFinanceIndividual Add(AppAssetFinanceIndividual individual)
        {
            if (_individual.Count == 0)
            {
                individual.IndividualId = 0;

            }
            else
            {
                individual.IndividualId = _individual.Max(e => e.IndividualId) + 1;
            }

            _individual.Add(individual);
            return individual;
        }

        public AppAssetFinanceIndividual Delete(int IndividualId)
        {
            AppAssetFinanceIndividual individual = _individual.FirstOrDefault(e => e.IndividualId == IndividualId);
            if (_individual != null)
            {
                _individual.Remove(individual);
            }
            return individual;
        }

        public IEnumerable<AppAssetFinanceIndividual> GetAllIndividual()
        {
            return _individual;
        }

        public AppAssetFinanceIndividual GetIndividual(int IndividualId)
        {
            return _individual.FirstOrDefault(e => e.IndividualId == IndividualId);
        }

        public AppAssetFinanceIndividual Update(AppAssetFinanceIndividual model)
        {
            AppAssetFinanceIndividual individual = _individual.FirstOrDefault(e => e.IndividualId == model.IndividualId);
            if (individual != null)
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
            return individual;
        }
    }
}
