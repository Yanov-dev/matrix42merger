using Matrix42Merger.Dto;

namespace Matrix42Merger.Repositories.UserLogin
{
    public interface IUserRepository
    {
        UserInfoDto GetUserInfo(UserLoginInfo userLoginInfo);
    }
}