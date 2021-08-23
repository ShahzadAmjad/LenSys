using LenSys.Models.BusniessLiabilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.ViewModels.BusniessLiabilities
{
    public class BusniessLiabilitiesCreateViewModel
    {
        public LenSys.Models.BusniessLiabilities.BusniessLiabilities busniessLiabilities { get; set; }
        public IEnumerable<LenSys.Models.BusniessLiabilities.BusniessLiabilities> _busniessLiabilities { get; set; }
    }
}
