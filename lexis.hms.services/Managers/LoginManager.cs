using lexis.hms.data.Contracts;
using lexis.hms.data.Models;
using lexis.hms.services.Contracts;
using lexis.hms.entity.Models.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lexis.hms.entity.Models.Login;

namespace lexis.hms.services.Managers
{
    public class LoginManager:ILoginManager
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IUserProfileRepository _userProfileRepository;

        public LoginManager(ILoginRepository loginRepository, IUserProfileRepository userProfileRepository)
        {
            _loginRepository = loginRepository;
            _userProfileRepository = userProfileRepository;
        }
        public AuthenticationResponse Authenticate(AuthenticationRequest authenticationRequest)
        {
                        
            // First validate the request, UserName and Password are required.
            if (!ValidateRequest(authenticationRequest))
            {
                return new AuthenticationResponse { status = false, authToken = ""};
            }

            // Validate user credentials
            var userProfile = _loginRepository.Authenticate(authenticationRequest.userName, authenticationRequest.password);

            if (userProfile != null && userProfile.UserKey > 0) //User is authenticated
            {
                var loginTime = _loginRepository.SaveUserSession(userProfile.UserKey, true);

                //TODO: Generate AuthToken
                var authToken = GenerateAuthToken();
                return new AuthenticationResponse { status = true, authToken = authToken,  userDisplayName=userProfile.UserName};
            }
            else
            {
                return new AuthenticationResponse { status = false, authToken = ""};
            }
            
        }

        private bool ValidateRequest(AuthenticationRequest authenticationRequest)
        {
            if (string.IsNullOrWhiteSpace(authenticationRequest.userName) || string.IsNullOrWhiteSpace(authenticationRequest.password))
            {
                return false;
            }
            return true;
        }

        //Generate JWToken for User Validation for Subsequent requests
        private string GenerateAuthToken()
        {
            return "sdkfskdjfjsd42sdmfsdkml4ksdmksdljg34wtwes,mdjt3";
        }

        //Generate JWToken for User Validation for Subsequent requests
        private async Task<string> GetUserIdByTokenAsync()
        {
            var userSession = await _loginRepository.GetUserSession("test");

            return Convert.ToString(userSession.UserId);
        }

    }
}
