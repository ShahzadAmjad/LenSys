using LenSys.Models.BusniessKeyPrincipals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.ViewModels.BusniessKeyPrincipals
{
    public class KeyPrincipalsCreateViewModel
    {
        public KeyPrincipals keyPrincipals { get; set; }
        public IEnumerable<KeyPrincipals> _keyPrincipals { get; set; }
    }
}
