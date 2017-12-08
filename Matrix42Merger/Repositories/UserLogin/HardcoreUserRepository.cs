using System;
using Matrix42Merger.Dto;

namespace Matrix42Merger.Repositories.UserLogin
{
    public class HardcoreUserRepository : IUserRepository
    {
        public UserInfoDto GetUserInfo(UserLoginInfo userLoginInfo)
        {
            if (userLoginInfo == null)
                throw new ArgumentNullException(nameof(userLoginInfo));

            if (userLoginInfo.UserName == "1" && userLoginInfo.Password == "1")
                return new UserInfoDto
                {
                    Role = "user",
                    UserName = "1"
                };

            return null;
        }
    }
}