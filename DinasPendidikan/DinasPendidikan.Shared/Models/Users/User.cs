using DinasPendidikan.Shared.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace DinasPendidikan.Shared.Models.Users
{
    public class User : BaseModel
    {

        [Required]
        [MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;
        public string PasswordSalt { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public DateTime? LastLogin { get; set; }

    }
}
