using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinasPendidikan.Shared.Models.Shared;

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
