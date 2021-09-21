using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.IndividualCreditHistory
{
    public class CreditHistory
    {
        [Key]
        public int CreditHistoryId { get; set; }
        public string PersonalCreditRating { get; set; }
        public string IVAorCVA { get; set; }
        public string DeclaredBankrupt { get; set; }
        public string PropertyRepossessed { get; set; }
        public string LegalAction { get; set; }
        public string GuarantorOnLoan { get; set; }
        public string CriminalConvictions { get; set; }
    }
}
