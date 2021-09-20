using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.IndividualAsset
{
    public class Asset
    {
        public int Cash { get; set; }
        public int Shares { get; set; }
        public int LifePolicy { get; set; }
        public int PersonalDewellingHouse { get; set; }
        public int OtherInvestments { get; set; }
        public int TotalAssets { get; set; }//C

    }
}
