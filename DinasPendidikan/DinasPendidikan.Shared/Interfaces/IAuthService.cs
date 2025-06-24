using DinasPendidikan.Shared.Models.Authentication;

namespace DinasPendidikan.Shared.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResult> LoginAsync(LoginModel loginModel);
        Task LogoutAsync();
        Task<AuthResult> RefreshTokenAsync(string token);
        Task<bool> ChangePasswordAsync(int userId, string currentPassword, string newPassword);
    }
}
