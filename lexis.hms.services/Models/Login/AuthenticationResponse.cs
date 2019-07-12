using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lexis.hms.services.Models.Login
{
    public class AuthenticationResponse
    {
        public bool success { get; set; }
        public string authToken { get; set; }
        public string lastLoginTime { get; set; }
    }
}
