using lexis.hms.data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace lexis.hms.data.Contracts
{
    public interface IUserProfileRepository
    {
        IEnumerable<UserProfile> GetUserProfiles();
        Task<UserProfile> GetUserProfile(int id);
        Task<int> GetUserKeyFromUserName(string userName);
    }
}