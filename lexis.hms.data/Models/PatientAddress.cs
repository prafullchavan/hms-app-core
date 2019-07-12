using System;
using System.Collections.Generic;

namespace lexis.hms.data.Models
{
    public partial class PatientAddress
    {
        public int PatientAddressId { get; set; }
        public int PatientId { get; set; }
        public int AddressType { get; set; }
        public string Address { get; set; }
        public string Pin { get; set; }
        public int? City { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public MtnAddressType AddressTypeNavigation { get; set; }
        public MtnCity CityNavigation { get; set; }
        public UserProfile CreatedByNavigation { get; set; }
        public Patient Patient { get; set; }
        public UserProfile UpdatedByNavigation { get; set; }
    }
}
