using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinasPendidikan.Shared.Models.Shared;

namespace DinasPendidikan.Shared.Models.Inventory
{
    public class DaftarBarang : BaseModel
    {

        [MaxLength(20)]
        public string KodeBarang { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string NamaBarang { get; set; } = string.Empty;

        [Required]
        public int KategoriBarangId { get; set; }
        public KategoriBarang KategoriBarang { get; set; } = null!;

        [MaxLength(500)]
        public string? Deskripsi { get; set; }

        [Required]
        public int Jumlah { get; set; }

        [Required]
        [MaxLength(20)]
        public string Kondisi { get; set; } = "Baik"; // Baik, Rusak Ringan, Rusak Berat

        public DateTime? TanggalPembelian { get; set; }
        public decimal? HargaPembelian { get; set; }

        [MaxLength(100)]
        public string? Lokasi { get; set; }

        // Navigation properties
        public ICollection<TransaksiBarang> TransaksiBarang { get; set; } = new List<TransaksiBarang>();
    }
}
