using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models
{
    public class SiteGlobalVariables
    {
        private static int IndividualId = 0;
    public static int _IndividualId
        {
        get { return IndividualId; }
        set { IndividualId = value; }
    }
    }
}
