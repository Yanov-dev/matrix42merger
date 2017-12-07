using Matrix42Merger.Dto;

namespace Matrix42Merger.Services.AuthService
{
    public interface IAuthService
    {
        string GenerateJwtToken(UserInfoDto userInfoDto);

        bool IsTokenValid(string token);
    }
}