using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinasPendidikan.Shared.Models.Shared;

namespace DinasPendidikan.Shared.Models.Inventory
{
    public class TransaksiBarang : BaseUserTrackedModel
    {
       
        [Required]
        public int DaftarBarangId { get; set; }
        public DaftarBarang DaftarBarang { get; set; } = null!;

        [Required]
        public int Jumlah { get; set; } // Positive for addition, negative for subtraction

        [Required]
        [MaxLength(20)]
        public string JenisTransaksi { get; set; } = "Masuk"; // Masuk, Keluar, Penyesuaian

        [MaxLength(200)]
        public string? Catatan { get; set; }
    }
}
