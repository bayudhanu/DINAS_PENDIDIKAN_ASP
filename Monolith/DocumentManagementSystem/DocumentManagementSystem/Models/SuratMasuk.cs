using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Components.Forms;

namespace DocumentManagementSystem.Models
{
    public class SuratMasuk
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nomor surat wajib diisi")]
        [Display(Name = "Nomor Surat")]
        public string NomorSurat { get; set; }

        [Required(ErrorMessage = "Perihal wajib diisi")]
        public string Perihal { get; set; }

        public string? IsiSurat { get; set; } = null;

        [Required(ErrorMessage = "Sifat surat wajib dipilih")]
        [Display(Name = "Sifat Surat")]
        public string SifatSurat { get; set; } // Biasa, Penting, Rahasia

        [Required(ErrorMessage = "Pengirim wajib diisi")]
        public string Pengirim { get; set; }

        [Required(ErrorMessage = "Tanggal surat wajib diisi")]
        [Display(Name = "Tanggal Surat")]
        public DateTime TanggalSurat { get; set; }

        [Required(ErrorMessage = "Tanggal diterima wajib diisi")]
        [Display(Name = "Tanggal Diterima")]
        public DateTime TanggalDiterima { get; set; }

        public string? Keterangan { get; set; }
        public StatusSurat Status { get; set; } = StatusSurat.Diterima;

        [Display(Name = "File Surat")]
        public string? FilePath { get; set; }

        [NotMapped]
        [Display(Name = "Upload File")]
        public IFormFile? FileSurat { get; set; }

        [NotMapped]
        public Stream? FileSuratStream { get; set; } // New property to hold the file stream

        [NotMapped]
        public string? FileSuratName { get; set; } // New property to hold the file name

        // Untuk tracking
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        
    }

    public enum StatusSurat
    {
        Diterima,
        Diproses,
        Ditindaklanjuti,
        Ditolak,
        Arsip
    }
}
