using System;
using System.Collections.Generic;

namespace lexis.hms.data.Models
{
    public partial class MtnReligion
    {
        public int ReligionId { get; set; }
        public string ReligionName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public UserProfile CreatedByNavigation { get; set; }
        public UserProfile UpdatedByNavigation { get; set; }
    }
}
