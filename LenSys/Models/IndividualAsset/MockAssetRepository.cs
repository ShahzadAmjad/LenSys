using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.IndividualAsset
{
    public class MockAssetRepository : IAssetRepository
    {
        private List<Asset> _assetLiabilities;
        public MockAssetRepository()
        {
                
        }
        public Asset Add(Asset assetLiabilities)
        {
            throw new NotImplementedException();
        }
    }
}
