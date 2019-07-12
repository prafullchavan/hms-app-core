using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lexis.hms.entity.Models.Login
{
    public class AuthenticationRequest
    {
        public string userName { get; set; }
        public string password { get; set; }
    }
}
