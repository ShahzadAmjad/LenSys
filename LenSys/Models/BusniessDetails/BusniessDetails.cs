using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.BusniessDetails
{
    public class BusniessDetails
    {
        [Key]
        public int BusniessDetailsId { get; set; }
        public string ApplicationType { get; set; }
        public string CompanyBusniessName { get; set; }
        public int RegisteredNumber { get; set; }
        public string NatureOfBusniess { get; set; }
        public int RegisteredAddress { get; set; }
        public string TradingAddress { get; set; }
        public string CorrespondenceAddress { get; set; }
        public string TradingSince { get; set; }
        
    }
}
