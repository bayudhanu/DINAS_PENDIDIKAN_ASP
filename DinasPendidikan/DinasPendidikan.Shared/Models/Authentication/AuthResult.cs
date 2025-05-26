using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
