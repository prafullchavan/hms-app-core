using lexis.hms.data.Contracts;
using lexis.hms.data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace lexis.hms.data.Repository
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly lexis_hmsContext _context;

        public UserProfileRepository(lexis_hmsContext context)
        {
            _context = context;
        }
        
        public async Task<UserProfile> GetUserProfile(int id)
        {
            return await _context.UserProfile.SingleOrDefaultAsync(m => m.UserKey == id);
        }

        public IEnumerable<UserProfile> GetUserProfiles()
        {
            return _context.UserProfile;
        }

        public async Task<int> GetUserKeyFromUserName(string userName)
        {
            var profile =  await _context.UserProfile.SingleOrDefaultAsync(m => m.UserName == userName);
            return profile.UserKey;
        }
    }
}
