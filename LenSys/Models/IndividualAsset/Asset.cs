using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.IndividualAsset
{
    public class Asset
    {
        [Key]
        public int AssetId { get; set; }
        public int Cash { get; set; }
        public int Shares { get; set; }
        public int LifePolicy { get; set; }
        public int PersonalDewellingHouse { get; set; }
        public int OtherInvestments { get; set; }
        public int TotalAssets { get; set; }//C

    }
}
