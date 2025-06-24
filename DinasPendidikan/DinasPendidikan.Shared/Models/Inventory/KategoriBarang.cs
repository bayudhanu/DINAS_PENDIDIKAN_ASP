using DinasPendidikan.Shared.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace DinasPendidikan.Shared.Models.Inventory
{
    public class KategoriBarang : BaseModel
    {

        [Required]
        [MaxLength(50)]
        public string Nama { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? Deskripsi { get; set; }

    }
}
