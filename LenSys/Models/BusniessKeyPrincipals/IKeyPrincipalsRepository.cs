using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.BusniessKeyPrincipals
{
    public interface IKeyPrincipalsRepository
    {
        KeyPrincipals GetKeyPrincipals(int KeyPrincipalsId);
        IEnumerable<KeyPrincipals> ClearKeyPrincipalsList();
        IEnumerable<KeyPrincipals> SetKeyPrincipalsList(IEnumerable<KeyPrincipals> keyPrincipalsList);
        IEnumerable<KeyPrincipals> GetAllKeyPrincipals();
        KeyPrincipals Add(KeyPrincipals keyPrincipals);
        KeyPrincipals Update(KeyPrincipals keyPrincipalsChanges);
        KeyPrincipals Delete(int KeyPrincipalsId);
    }
}
