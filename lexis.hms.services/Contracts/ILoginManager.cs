using lexis.hms.entity.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lexis.hms.services.Contracts
{
    public interface ILoginManager
    {
        AuthenticationResponse Authenticate(AuthenticationRequest authenticationRequest);
    }
}
