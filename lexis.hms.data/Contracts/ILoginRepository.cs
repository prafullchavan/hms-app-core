using lexis.hms.data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace lexis.hms.data.Contracts
{
    public interface ILoginRepository
    {
        UserProfile Authenticate(string userName, string password);
        Task<DateTime> SaveUserSession(int userId, bool loginSuccess);
        Task<LoginSession> GetUserSession(string authToken);
        Task<int> GetUserIdByAuthToken(string authToken);

    }
}
