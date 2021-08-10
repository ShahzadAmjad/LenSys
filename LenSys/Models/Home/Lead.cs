using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.Home
{
    public class Lead
    {
        public string LoanPurpose { get; set; }
        public int LoanAmount { get; set; }
        public int IntroducerName { get; set; }
        public string ApplicationType { get; set; }
        public int CompanyBusniessName { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public int PhoneNo { get; set; }
        public string Email { get; set; }
    }
}
