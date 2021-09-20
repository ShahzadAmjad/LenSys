using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.Individual
{
    public class MockIndividualRepository : IindividualRepository
    {
        private List<Individual> _individual;

        public MockIndividualRepository()
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
        public Individual Add(Individual individual)
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

        public Individual Delete(int IndividualId1)
        {
            Individual individual = _individual.FirstOrDefault(e => e.IndividualId == IndividualId1);
            if (_individual != null)
            {
                _individual.Remove(individual);
            }
            return individual;
        }

        public IEnumerable<Individual> GetAllIndividual()
        {
            return _individual;
        }

        public Individual GetIndividual(int IndividualId)
        {
            return _individual.FirstOrDefault(e => e.IndividualId == IndividualId);
        }

        public Individual Update(Individual model)
        {
            Individual individual = _individual.FirstOrDefault(e => e.IndividualId == model.IndividualId);
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
