using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lexis.hms.services.Models.Login
{
    public class AuthenticationRequest
    {
        [Required]
        public string userName { get; set; }
        [Required]
        public string password { get; set; }
    }
}   
