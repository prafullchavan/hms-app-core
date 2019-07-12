using System;
using System.Collections.Generic;

namespace lexis.hms.data.Models
{
    public partial class MtnAddressType
    {
        public MtnAddressType()
        {
            PatientAddress = new HashSet<PatientAddress>();
        }

        public int AddressTypeId { get; set; }
        public string AddressTypeName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public UserProfile CreatedByNavigation { get; set; }
        public UserProfile UpdatedByNavigation { get; set; }
        public ICollection<PatientAddress> PatientAddress { get; set; }
    }
}
