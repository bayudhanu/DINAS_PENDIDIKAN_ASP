using Microsoft.AspNetCore.Identity;

namespace DocumentManagementSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string NamaLengkap { get; set; }
        public string Jabatan { get; set; }
        public string Departemen { get; set; }
    }
}
