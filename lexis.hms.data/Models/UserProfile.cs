using System;
using System.Collections.Generic;

namespace lexis.hms.data.Models
{
    public partial class UserProfile
    {
        public UserProfile()
        {
            InverseCreatedByNavigation = new HashSet<UserProfile>();
            MtnAddressTypeCreatedByNavigation = new HashSet<MtnAddressType>();
            MtnAddressTypeUpdatedByNavigation = new HashSet<MtnAddressType>();
            MtnCasteCreatedByNavigation = new HashSet<MtnCaste>();
            MtnCasteUpdatedByNavigation = new HashSet<MtnCaste>();
            MtnCityCreatedByNavigation = new HashSet<MtnCity>();
            MtnCityUpdatedByNavigation = new HashSet<MtnCity>();
            MtnCountryCreatedByNavigation = new HashSet<MtnCountry>();
            MtnCountryUpdatedByNavigation = new HashSet<MtnCountry>();
            MtnReligionCreatedByNavigation = new HashSet<MtnReligion>();
            MtnReligionUpdatedByNavigation = new HashSet<MtnReligion>();
            MtnStateCreatedByNavigation = new HashSet<MtnState>();
            MtnStateUpdatedByNavigation = new HashSet<MtnState>();
            PatientAddressCreatedByNavigation = new HashSet<PatientAddress>();
            PatientAddressUpdatedByNavigation = new HashSet<PatientAddress>();
            PatientContactCreatedByNavigation = new HashSet<PatientContact>();
            PatientContactUpdatedByNavigation = new HashSet<PatientContact>();
            PatientCreatedByNavigation = new HashSet<Patient>();
            PatientUpdatedByNavigation = new HashSet<Patient>();
        }

        public int UserKey { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        

        public UserProfile CreatedByNavigation { get; set; }
        public LoginSession LoginSession { get; set; }
        public ICollection<UserProfile> InverseCreatedByNavigation { get; set; }
        public ICollection<MtnAddressType> MtnAddressTypeCreatedByNavigation { get; set; }
        public ICollection<MtnAddressType> MtnAddressTypeUpdatedByNavigation { get; set; }
        public ICollection<MtnCaste> MtnCasteCreatedByNavigation { get; set; }
        public ICollection<MtnCaste> MtnCasteUpdatedByNavigation { get; set; }
        public ICollection<MtnCity> MtnCityCreatedByNavigation { get; set; }
        public ICollection<MtnCity> MtnCityUpdatedByNavigation { get; set; }
        public ICollection<MtnCountry> MtnCountryCreatedByNavigation { get; set; }
        public ICollection<MtnCountry> MtnCountryUpdatedByNavigation { get; set; }
        public ICollection<MtnReligion> MtnReligionCreatedByNavigation { get; set; }
        public ICollection<MtnReligion> MtnReligionUpdatedByNavigation { get; set; }
        public ICollection<MtnState> MtnStateCreatedByNavigation { get; set; }
        public ICollection<MtnState> MtnStateUpdatedByNavigation { get; set; }
        public ICollection<PatientAddress> PatientAddressCreatedByNavigation { get; set; }
        public ICollection<PatientAddress> PatientAddressUpdatedByNavigation { get; set; }
        public ICollection<PatientContact> PatientContactCreatedByNavigation { get; set; }
        public ICollection<PatientContact> PatientContactUpdatedByNavigation { get; set; }
        public ICollection<Patient> PatientCreatedByNavigation { get; set; }
        public ICollection<Patient> PatientUpdatedByNavigation { get; set; }
    }
}
