using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.BusniessKeyPrincipals
{
    public class MockKeyPrincipalsRepository : IKeyPrincipalsRepository
    {
        private List<KeyPrincipals> _keyPrincipals;
        public MockKeyPrincipalsRepository()
        {

        }
        public KeyPrincipals Add(KeyPrincipals keyPrincipals)
        {
            throw new NotImplementedException();
        }
    }
}
