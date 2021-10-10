using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppBusniessFinance.AppBusniessFinanceIndividual
{
    public class MockAppBusniessFinanceIndividualRepository : IAppBusniessFinanceIndividualRepository
    {
        private List<AppBusniessFinanceIndividual> _individual;
        public MockAppBusniessFinanceIndividualRepository()
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
        public AppBusniessFinanceIndividual Add(AppBusniessFinanceIndividual individual)
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

        public IEnumerable<AppBusniessFinanceIndividual> ClearIndividualList()
        {
            _individual.Clear();
            return _individual;
        }

        public AppBusniessFinanceIndividual Delete(int IndividualId)
        {
            AppBusniessFinanceIndividual individual = _individual.FirstOrDefault(e => e.IndividualId == IndividualId);
            if (_individual != null)
            {
                _individual.Remove(individual);
            }
            return individual;
        }

        public IEnumerable<AppBusniessFinanceIndividual> GetAllIndividual()
        {
            return _individual;
        }

        public AppBusniessFinanceIndividual GetIndividual(int IndividualId)
        {
            return _individual.FirstOrDefault(e => e.IndividualId == IndividualId);
        }

        public IEnumerable<AppBusniessFinanceIndividual> SetIndividualList(IEnumerable<AppBusniessFinanceIndividual> IndividualList)
        {
            _individual = (List<AppBusniessFinanceIndividual>)IndividualList;
            return _individual;
        }

        public AppBusniessFinanceIndividual Update(AppBusniessFinanceIndividual model)
        {
            AppBusniessFinanceIndividual individual = _individual.FirstOrDefault(e => e.IndividualId == model.IndividualId);
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
