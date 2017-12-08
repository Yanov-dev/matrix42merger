using System.Web.Http;
using Matrix42Merger.Dto;
using Matrix42Merger.Repositories.UserLogin;
using Matrix42Merger.Services.AuthService;
using Unity.Attributes;

namespace Matrix42Merger.Controllers
{
    [Route("api/account")]
    public class AccountController : ApiController
    {
        [Dependency]
        public IUserRepository UserRepository { get; set; }

        [Dependency]
        public IAuthService AuthService { get; set; }

        [HttpPost]
        public LoginResult Post([FromBody] UserLoginInfo userLoginInfo)
        {
            var userInfo = UserRepository.GetUserInfo(userLoginInfo);
            if (userInfo == null)
                return new LoginResult
                {
                    Error = "User not found"
                };

            return new LoginResult {AccessToken = AuthService.GenerateJwtToken(userInfo)};
        }
    }
}