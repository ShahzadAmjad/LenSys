using LenSys.Models.Home;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppAssetFinance
{
    public class AppAssetFinance
    {
        //Developer Assigned id//not by user
        [Key]
        public int AssetFinId { get; set; }

        public Lead Lead { get; set; }
        public string ApplicationType { get; set; }
        
        public string AssetType { get; set; }
        public string Description { get; set; }
        public int PurchasePriceOfAssetValue { get; set; }
        public int Deposit { get; set; }
        public int LoanAmount { get; set; }
        public string VATincluded { get; set; }
        public string RepaymentTermMonths { get; set; }
        public string BalloonPayment { get; set; }

        //Supplier Details

        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
    }
}
