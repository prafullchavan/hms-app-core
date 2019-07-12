using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lexis.hms.entity.Models.Login
{
    public class AuthenticationResponse: BaseResponse
    { 
        public string authToken { get; set; }
        public string userDisplayName { get; set; }
    }
}
