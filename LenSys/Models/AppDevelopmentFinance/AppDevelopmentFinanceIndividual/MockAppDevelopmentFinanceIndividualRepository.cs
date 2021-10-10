using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppDevelopmentFinance.AppDevelopmentFinanceIndividual
{
    public class MockAppDevelopmentFinanceIndividualRepository : IAppDevelopmentFinanceIndividualRepository
    {
        private List<AppDevelopmentFinanceIndividual> _individual;
        public MockAppDevelopmentFinanceIndividualRepository()
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
        public AppDevelopmentFinanceIndividual Add(AppDevelopmentFinanceIndividual individual)
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

        public IEnumerable<AppDevelopmentFinanceIndividual> ClearIndividualList()
        {
            _individual.Clear();
            return _individual;
        }

        public AppDevelopmentFinanceIndividual Delete(int IndividualId)
        {
            AppDevelopmentFinanceIndividual individual = _individual.FirstOrDefault(e => e.IndividualId == IndividualId);
            if (_individual != null)
            {
                _individual.Remove(individual);
            }
            return individual;
        }

        public IEnumerable<AppDevelopmentFinanceIndividual> GetAllIndividual()
        {
            return _individual;
        }

        public AppDevelopmentFinanceIndividual GetIndividual(int IndividualId)
        {
            return _individual.FirstOrDefault(e => e.IndividualId == IndividualId);
        }

        public IEnumerable<AppDevelopmentFinanceIndividual> SetIndividualList(IEnumerable<AppDevelopmentFinanceIndividual> IndividualList)
        {
            _individual = (List<AppDevelopmentFinanceIndividual>)IndividualList;
            return _individual;
        }

        public AppDevelopmentFinanceIndividual Update(AppDevelopmentFinanceIndividual model)
        {
            AppDevelopmentFinanceIndividual individual = _individual.FirstOrDefault(e => e.IndividualId == model.IndividualId);
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
