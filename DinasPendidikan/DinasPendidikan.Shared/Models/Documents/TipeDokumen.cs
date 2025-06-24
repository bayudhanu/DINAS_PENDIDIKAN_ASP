using DinasPendidikan.Shared.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace DinasPendidikan.Shared.Models.Documents
{
    public class TipeDokumen : BaseModel
    {

        [MaxLength(50)]
        public string Nama { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Kode { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? Deskripsi { get; set; }

    }
}
