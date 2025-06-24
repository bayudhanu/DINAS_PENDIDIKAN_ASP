using DinasPendidikan.Shared.DTOs;

namespace DinasPendidikan.Shared.Models.Authentication
{
    public class AuthResult
    {
        public string Token { get; set; } = string.Empty;
        public DateTime Expiration { get; set; }
        public UserDto User { get; set; } = null!;
    }
}
