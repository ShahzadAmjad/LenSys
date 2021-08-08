using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.IndividualAssetLiabilities
{
    public class MockAssetLiabilitiesRepository : IAssetLiabilitiesRepository
    {
        private List<AssetLiabilities> _assetLiabilities;
        public MockAssetLiabilitiesRepository()
        {
                
        }
        public AssetLiabilities Add(AssetLiabilities assetLiabilities)
        {
            throw new NotImplementedException();
        }
    }
}
