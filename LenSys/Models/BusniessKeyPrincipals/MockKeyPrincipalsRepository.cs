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
            _keyPrincipals = new List<KeyPrincipals>()
            {
                    //            new KeyPrincipals{KeyPrincipalsId=1,Title="John", FirstName="John",
                    //MiddleName="Peter",  Surname="ALY",Position="CEO",PercentageShareholding="50"},
                    //            new KeyPrincipals{KeyPrincipalsId=2,Title="Mary", FirstName="Mary",
                    //MiddleName="Peter",  Surname="ALY",Position="MD",PercentageShareholding="25"},
                    //            new KeyPrincipals{KeyPrincipalsId=3,Title="ALY", FirstName="ALY",
                    //MiddleName="Peter",  Surname="ALY",Position="GM",PercentageShareholding="10"}
            };
        }
        public KeyPrincipals Add(KeyPrincipals keyPrincipals)
        {
            if (_keyPrincipals.Count == 0)
            {
                keyPrincipals.KeyPrincipalsId = 1;

            }
            else
            {
                keyPrincipals.KeyPrincipalsId = _keyPrincipals.Max(e => e.KeyPrincipalsId) + 1;
            }
            
            _keyPrincipals.Add(keyPrincipals);
            return keyPrincipals;
        }

        public IEnumerable<KeyPrincipals> ClearKeyPrincipalsList()
        {
            _keyPrincipals.Clear();
            return _keyPrincipals;
        }

        public KeyPrincipals Delete(int keyPrincipalsId)
        {
            KeyPrincipals keyPrincipals = _keyPrincipals.FirstOrDefault(e => e.KeyPrincipalsId == keyPrincipalsId);
            if (keyPrincipals != null)
            {
                _keyPrincipals.Remove(keyPrincipals);
            }
            return keyPrincipals;
        }

        public IEnumerable<KeyPrincipals> GetAllKeyPrincipals()
        {
           
            return _keyPrincipals;
        }

        public KeyPrincipals GetKeyPrincipals(int keyPrincipalsId)
        {
            return _keyPrincipals.FirstOrDefault(e => e.KeyPrincipalsId == keyPrincipalsId);
        }

        public IEnumerable<KeyPrincipals> SetKeyPrincipalsList(IEnumerable<KeyPrincipals> keyPrincipalsList)
        {
            _keyPrincipals = (List<KeyPrincipals>)keyPrincipalsList;
            return _keyPrincipals;
        }

        public KeyPrincipals Update(KeyPrincipals model)
        {
            KeyPrincipals keyPrincipals = _keyPrincipals.FirstOrDefault(e => e.KeyPrincipalsId == model.KeyPrincipalsId);
            if (keyPrincipals != null)
            {
                //keyPrincipals.KeyPrincipalsId = model.KeyPrincipalsId;
                keyPrincipals.Title = model.Title;
                keyPrincipals.FirstName = model.FirstName;
                keyPrincipals.MiddleName = model.MiddleName;
                keyPrincipals.Surname = model.Surname;
                keyPrincipals.Position = model.Position;
                keyPrincipals.PercentageShareholding = model.PercentageShareholding;              
            }
            return keyPrincipals;
        }
    }
}
