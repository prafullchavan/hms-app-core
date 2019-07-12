using lexis.hms.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lexis.hms.services.Contracts
{
    public interface IUserProfileManager
    {
        UserProfile GetUserProfileByAuthToken(string authToken);
    }
}
