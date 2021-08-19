using LenSys.Models.BusniessServiceability;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.ViewModels.BusniessServiceability
{
    public class ServiceabilityCreateViewModel
    {
        public Serviceability serviceability { get; set; }
        public IEnumerable<Serviceability> _serviceability { get; set; }
    }
}
