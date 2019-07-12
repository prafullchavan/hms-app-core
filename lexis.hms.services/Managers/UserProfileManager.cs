using lexis.hms.data.Contracts;
using lexis.hms.data.Models;
using lexis.hms.services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lexis.hms.services.Managers
{
    public class UserProfileManager: IUserProfileManager
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public UserProfileManager(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public UserProfile GetUserProfileByAuthToken(string authToken)
        {
            return null;
        }
    }
}
