using lexis.hms.data.Contracts;
using lexis.hms.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lexis.hms.data.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly lexis_hmsContext _context;

        public LoginRepository(lexis_hmsContext context)
        {
            _context = context;
        }

        public UserProfile Authenticate(string userName, string password)
        {
            try
            {
                var storedUserProfile = _context.UserProfile.FirstOrDefault(x => x.UserName == userName.Trim() && x.Password == password.Trim());
                if ((storedUserProfile != null && storedUserProfile.UserKey > 0))
                    return storedUserProfile;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
            return null;
        }


        public async Task<DateTime> SaveUserSession(int userId, bool loginSuccess)
        {
            var loginSession = new LoginSession()
            {
                UserId = userId,
                LoginSuccess = loginSuccess
            };

           var loginSessionEntry =  _context.LoginSession.Add(loginSession);
            await _context.SaveChangesAsync();

            return loginSessionEntry.Entity.LoginTime;
        }


        public async Task<LoginSession> GetUserSession(string authToken)
        {
            var loginSessionEntry = _context.LoginSession.Where(x=>x.AuthToken== authToken).FirstOrDefault();
            await _context.SaveChangesAsync();
            return loginSessionEntry;
        }

        public async Task<int> GetUserIdByAuthToken(string authToken)
        {
            authToken = "test";
            var loginSessionEntry = _context.LoginSession.Where(x => x.AuthToken == authToken).FirstOrDefault();
            await _context.SaveChangesAsync();
            return loginSessionEntry.UserId;
        }
    }
}
