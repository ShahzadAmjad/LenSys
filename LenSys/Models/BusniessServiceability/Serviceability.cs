using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.BusniessServiceability
{
    public class Serviceability
    {
        [Key]
        public int ServiceabilityId { get; set; }
        public string Year { get; set; }
        public int TurnOver { get; set; }
        public int NetProfit { get; set; }
        public string EBITDA { get; set; }

    }
}
