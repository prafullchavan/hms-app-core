using System;
using System.Collections.Generic;

namespace lexis.hms.data.Models
{
    public partial class Patient
    {
        public Patient()
        {
            PatientAddress = new HashSet<PatientAddress>();
        }

        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FhfirstName { get; set; }
        public string FhlastName { get; set; }
        public string Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string Age { get; set; }
        public string EmailAddress { get; set; }
        public string BloodGroup { get; set; }
        public string Remark { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public UserProfile CreatedByNavigation { get; set; }
        public UserProfile UpdatedByNavigation { get; set; }
        public ICollection<PatientAddress> PatientAddress { get; set; }
    }
}
