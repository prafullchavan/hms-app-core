using System;
using System.Collections.Generic;

namespace lexis.hms.data.Models
{
    public partial class MtnCity
    {
        public MtnCity()
        {
            PatientAddress = new HashSet<PatientAddress>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public UserProfile CreatedByNavigation { get; set; }
        public MtnState State { get; set; }
        public UserProfile UpdatedByNavigation { get; set; }
        public ICollection<PatientAddress> PatientAddress { get; set; }
    }
}
