using System;
using System.Collections.Generic;

namespace lexis.hms.services.Models
{
    public partial class UserProfile
    {
        public int UserKey { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public UserProfile UserKeyNavigation { get; set; }
        public UserProfile InverseUserKeyNavigation { get; set; }
        public LoginSession LoginSession { get; set; }
    }
}
