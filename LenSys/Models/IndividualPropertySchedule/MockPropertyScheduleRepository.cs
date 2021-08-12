using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.IndividualPropertySchedule
{
    public class MockPropertyScheduleRepository : IPropertyScheduleRepository
    {
        private List<PropertySchedule> _propertySchedule;
        public MockPropertyScheduleRepository()
        {
            _propertySchedule = new List<PropertySchedule>()
            {
                new PropertySchedule{PropertyId=1,Owner="Mary", PropertyAddress="Istanbul", 
                    Lender="Peter", PurchaseDate=DateTime.Today, PurchasePrice=20000,
                    OrigionalMortgageAmount=15000,CurrentMarketValue=25000,OutstandingMortgage=5000,
                    RemainingTerm=2, TypeOfRate="Fixed", InterestRate=10, RentPcm=2250, LTV="ssas", MortgagePcm=1500 ,
                    PropertyType="Semi-Commercial", PropertyDescription="One bed apartment",TypeOfTenancyLeaseASTBoth="Lease",RemainingTermOfLease=5},
                
                new PropertySchedule{PropertyId=2,Owner="John", PropertyAddress="Istanbul",
                    Lender="Peter", PurchaseDate=DateTime.Today, PurchasePrice=20000,
                    OrigionalMortgageAmount=15000,CurrentMarketValue=25000,OutstandingMortgage=5000,
                    RemainingTerm=2, TypeOfRate="Fixed", InterestRate=10, RentPcm=2250, LTV="ssas", MortgagePcm=1500 ,
                    PropertyType="Semi-Commercial", PropertyDescription="One bed apartment",TypeOfTenancyLeaseASTBoth="Lease",RemainingTermOfLease=5},

                new PropertySchedule{PropertyId=3,Owner="Aly", PropertyAddress="Istanbul",
                    Lender="Peter", PurchaseDate=DateTime.Today, PurchasePrice=20000,
                    OrigionalMortgageAmount=15000,CurrentMarketValue=25000,OutstandingMortgage=5000,
                    RemainingTerm=2, TypeOfRate="Fixed", InterestRate=10, RentPcm=2250, LTV="ssas", MortgagePcm=1500 ,
                    PropertyType="Semi-Commercial", PropertyDescription="One bed apartment",TypeOfTenancyLeaseASTBoth="Lease",RemainingTermOfLease=5}

            };

        }
        public PropertySchedule Add(PropertySchedule propertySchedule)
        {
            propertySchedule.PropertyId = _propertySchedule.Max(e => e.PropertyId) + 1;
            _propertySchedule.Add(propertySchedule);
            return propertySchedule;
        }

        public PropertySchedule Delete(int propertyId)
        {
            PropertySchedule propertySchedule = _propertySchedule.FirstOrDefault(e => e.PropertyId == propertyId);
            if (propertySchedule != null)
            {
                _propertySchedule.Remove(propertySchedule);
            }
            return propertySchedule;
        }

        public IEnumerable<PropertySchedule> GetAllPropertySchedule()
        {
            return _propertySchedule;
        }

        public PropertySchedule GetPropertySchedule(int propertyId)
        {
            return _propertySchedule.FirstOrDefault(e => e.PropertyId == propertyId);
        }

        public PropertySchedule Update(PropertySchedule model)
        {
            PropertySchedule propertySchedule = _propertySchedule.FirstOrDefault(e => e.PropertyId == model.PropertyId);
            if (propertySchedule != null)
            {
                //propertySchedule.Name = employeeChanges.Name;
                //propertySchedule.Email = employeeChanges.Email;
                //propertySchedule.Department = employeeChanges.Department;

                //propertySchedule.PropertyId = model.PropertyId;
                propertySchedule.Owner = model.Owner;
                propertySchedule.PropertyAddress = model.PropertyAddress;
                propertySchedule.Lender = model.Lender;
                propertySchedule.PurchaseDate = model.PurchaseDate;
                propertySchedule.PurchasePrice = model.PurchasePrice;
                propertySchedule.OrigionalMortgageAmount = model.OrigionalMortgageAmount;
                propertySchedule.CurrentMarketValue = model.CurrentMarketValue;
                propertySchedule.OutstandingMortgage = model.OutstandingMortgage;
                propertySchedule.RemainingTerm = model.RemainingTerm;
                propertySchedule.TypeOfRate = model.TypeOfRate;
                propertySchedule.InterestRate = model.InterestRate;
                propertySchedule.RentPcm = model.RentPcm;
                propertySchedule.MortgagePcm = model.MortgagePcm;
                propertySchedule.LTV = model.LTV;
                propertySchedule.PropertyType = model.PropertyType;
                propertySchedule.PropertyDescription = model.PropertyDescription;
                propertySchedule.TypeOfTenancyLeaseASTBoth = model.TypeOfTenancyLeaseASTBoth;
                propertySchedule.RemainingTermOfLease = model.RemainingTermOfLease;

                //return propertySchedule;
            }
            //PropertySchedule propertySchedule2 = _propertySchedule.FirstOrDefault(e => e.PropertyId == model.PropertyId);
            //_propertySchedule.Remove(propertySchedule2);
            //_propertySchedule.Add(propertySchedule);

            return propertySchedule;
        }
    }
}
