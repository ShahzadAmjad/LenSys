using LenSys.Models.BusniessKeyPrincipals;
using LenSys.Models.BusniessServiceability;
using LenSys.Models.BusniessUploadDocument;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppBusniessFinance.AppBusniessFinanceBusniess
{
    public class AppBusniessFinanceBusniess
    {
        [Key]
        public int BusniessId { get; set; }
        public BusniessDetails.BusniessDetails busniessDetails { get; set; }
        //Multiple Properties
        public List<KeyPrincipals> keyPrincipals { get; set; }
        public List<BusniessLiabilities.BusniessLiabilities> busniessLiabilities { get; set; }
        public List<Serviceability> serviceability { get; set; }
        public List<BusniessDocuments> busniessDocuments { get; set; }
    }
}
