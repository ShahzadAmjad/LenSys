﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.IndividualAssetLiabilities
{
    interface IAssetLiabilitiesRepository
    {
        AssetLiabilities Add(AssetLiabilities assetLiabilities);
    }
}
