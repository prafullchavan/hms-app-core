using System;
using System.Collections.Generic;

namespace lexis.hms.data.Models
{
    public partial class MtnState
    {
        public MtnState()
        {
            MtnCity = new HashSet<MtnCity>();
        }

        public int StateId { get; set; }
        public string StateName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public UserProfile CreatedByNavigation { get; set; }
        public UserProfile UpdatedByNavigation { get; set; }
        public ICollection<MtnCity> MtnCity { get; set; }
    }
}
