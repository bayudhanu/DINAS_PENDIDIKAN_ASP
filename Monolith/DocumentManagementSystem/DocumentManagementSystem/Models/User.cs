using Microsoft.AspNetCore.Identity;

namespace DocumentManagementSystem.Models
{
    public class User : IdentityUser
    {
        public string NamaLengkap { get; set; }
        public string Jabatan { get; set; }
        public string Departemen { get; set; }
    }
}
