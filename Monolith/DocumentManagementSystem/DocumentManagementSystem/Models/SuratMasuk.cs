using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models
{
    public class SuratMasuk
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nomor Surat")]
        public string NomorSurat { get; set; }

        [Required]
        [StringLength(200)]
        public string Perihal { get; set; }

        [Required]
        [Display(Name = "Isi Surat")]
        public string IsiSurat { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Tanggal Surat")]
        public DateTime TanggalSurat { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Asal Surat")]
        public string AsalSurat { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Tujuan Surat")]
        public string TujuanSurat { get; set; }

        [Display(Name = "Lampiran")]
        public string LampiranPath { get; set; }

        [Required]
        [Display(Name = "Status Surat")]
        public StatusSurat Status { get; set; } = StatusSurat.Diterima;

        [Display(Name = "Tanggal Diterima")]
        public DateTime TanggalDiterima { get; set; } = DateTime.Now;

        [StringLength(200)]
        [Display(Name = "Keterangan")]
        public string Keterangan { get; set; }

        [StringLength(50)]
        [Display(Name = "Sifat Surat")]
        public string SifatSurat { get; set; }
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
