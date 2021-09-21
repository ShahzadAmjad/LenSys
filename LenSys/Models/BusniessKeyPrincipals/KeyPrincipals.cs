using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.BusniessKeyPrincipals
{
    public class KeyPrincipals
    {
        [Key]
        public int KeyPrincipalsId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public string PercentageShareholding { get; set; }
    }
}
