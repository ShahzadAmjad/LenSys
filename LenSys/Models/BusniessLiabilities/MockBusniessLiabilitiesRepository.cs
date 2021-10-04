using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.BusniessLiabilities
{
    public class MockBusniessLiabilitiesRepository : IBusniessLiabilitiesRepository
    {
        private List<BusniessLiabilities> _busniessLiabilities;
        public MockBusniessLiabilitiesRepository()
        {
            _busniessLiabilities = new List<BusniessLiabilities>()
            {
                //new BusniessLiabilities{BusniessLiabilityId=1,Lender="John", OrigionalLoanAmount=50000,
                //    OutstandingBalance=3000, MonthlyPayment=20000,InitialTerm="7",RemainingTerm="4",Rate=5,
                //    FixedOrVariable="Fixed", FixedTerm="Fixed", CommitmentTerm=10, EarlyRepaymentCharge=2250},
                //new BusniessLiabilities{BusniessLiabilityId=2,Lender="Mary", OrigionalLoanAmount=50000,
                //    OutstandingBalance=3000, MonthlyPayment=20000,InitialTerm="7",RemainingTerm="4",Rate=5,
                //    FixedOrVariable="Fixed", FixedTerm="Fixed", CommitmentTerm=10, EarlyRepaymentCharge=2250},
                //new BusniessLiabilities{BusniessLiabilityId=3,Lender="ALY", OrigionalLoanAmount=50000,
                //    OutstandingBalance=3000, MonthlyPayment=20000,InitialTerm="7",RemainingTerm="4",Rate=5,
                //    FixedOrVariable="Fixed", FixedTerm="Fixed", CommitmentTerm=10, EarlyRepaymentCharge=2250}


            };
        }
        public BusniessLiabilities Add(BusniessLiabilities busniessLiabilities)
        {
            busniessLiabilities.BusniessLiabilityId = _busniessLiabilities.Max(e => e.BusniessLiabilityId) + 1;
            _busniessLiabilities.Add(busniessLiabilities);
            return busniessLiabilities;
        }

        public IEnumerable<BusniessLiabilities> ClearBusniessLiabilitiesList()
        {
            _busniessLiabilities.Clear();
            return _busniessLiabilities;
        }

        public BusniessLiabilities Delete(int id)
        {
            BusniessLiabilities busniessLiabilities = _busniessLiabilities.FirstOrDefault(e => e.BusniessLiabilityId == id);
            if (busniessLiabilities != null)
            {
                _busniessLiabilities.Remove(busniessLiabilities);
            }
            return busniessLiabilities;
        }

        public IEnumerable<BusniessLiabilities> GetAllBusniessLiabilities()
        {
            return _busniessLiabilities;
        }

        public BusniessLiabilities GetBusniessLiabilities(int busniessLiabilityId)
        {
            return _busniessLiabilities.FirstOrDefault(e => e.BusniessLiabilityId == busniessLiabilityId);
        }

        public IEnumerable<BusniessLiabilities> SetBusniessLiabilitiesList(IEnumerable<BusniessLiabilities> BusniessLiabilitiesList)
        {
            _busniessLiabilities = (List<BusniessLiabilities>)BusniessLiabilitiesList;
            return _busniessLiabilities;
        }

        public BusniessLiabilities Update(BusniessLiabilities model)
        {
            BusniessLiabilities busniessLiabilities = _busniessLiabilities.FirstOrDefault(e => e.BusniessLiabilityId == model.BusniessLiabilityId);
            if (busniessLiabilities != null)
            {
                //busniessLiabilities.BusniessLiabilityId = model.BusniessLiabilityId;
                busniessLiabilities.Lender = model.Lender;
                busniessLiabilities.OrigionalLoanAmount = model.OrigionalLoanAmount;
                busniessLiabilities.OutstandingBalance = model.OutstandingBalance;
                busniessLiabilities.MonthlyPayment = model.MonthlyPayment;
                busniessLiabilities.InitialTerm = model.InitialTerm;
                busniessLiabilities.RemainingTerm = model.RemainingTerm;
                busniessLiabilities.Rate = model.Rate;
                busniessLiabilities.FixedOrVariable = model.FixedOrVariable;
                busniessLiabilities.FixedTerm = model.FixedTerm;
                busniessLiabilities.CommitmentTerm = model.CommitmentTerm;
                busniessLiabilities.EarlyRepaymentCharge = model.EarlyRepaymentCharge;                            
            }
            return busniessLiabilities;
        }
    }
}
