using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.IndividualCreditHistory
{
    public class CreditHistory
    {
        public string PersonalCreditRating { get; set; }
        public string IVAorCVA { get; set; }
        public string DeclaredBankrupt { get; set; }
        public string PropertyRepossessed { get; set; }
        public string LegalAction { get; set; }
        public string GuarantorOnLoan { get; set; }
        public string CriminalConvictions { get; set; }
    }
}
