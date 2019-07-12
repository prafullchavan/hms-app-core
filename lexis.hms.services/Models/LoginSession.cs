using System;
using System.Collections.Generic;

namespace lexis.hms.services.Models
{
    public partial class LoginSession
    {
        public int LoginSessionId { get; set; }
        public int UserId { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime? LogOutTime { get; set; }
        public bool LoginSuccess { get; set; }
        public string LoginErrorCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public string AuthToken { get; set; }

        public UserProfile LoginSessionNavigation { get; set; }
    }
}
