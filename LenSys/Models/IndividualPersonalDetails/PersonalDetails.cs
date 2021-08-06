using LenSys.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.IndividualPersonalDetails
{
    public class PersonalDetails
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public int PhoneNo { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public CountryEnum Nationality { get; set; }
        public string PermanentRightForUkResident { get; set; }
        public int LengthOfResidencyYears { get; set; }
        public string MaritalStatus { get; set; }

    }
}
