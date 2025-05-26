using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinasPendidikan.Shared.Models.Authentication
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username wajib diisi")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password wajib diisi")]
        [DataType(DataType.Password )]
        public string Password { get; set; } = string.Empty;
        public bool RememberMe { get; set; } = false;
        public LoginModel() { }
        public LoginModel(string username, string password, bool rememberMe)
        {
            Username = username;
            Password = password;
            RememberMe = rememberMe;
        }
    }
}
