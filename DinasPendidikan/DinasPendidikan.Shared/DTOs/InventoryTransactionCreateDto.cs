using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinasPendidikan.Shared.Enums;

namespace DinasPendidikan.Shared.DTOs
{
    public class InventoryTransactionCreateDto
    {
        [Required(ErrorMessage = "ID barang wajib diisi")]
        [Display(Name = "Barang")]
        public int ItemId { get; set; }

        [Required(ErrorMessage = "Jumlah transaksi wajib diisi")]
        [Display(Name = "Jumlah")]
        public int QuantityChange { get; set; }

        [Required(ErrorMessage = "Jenis transaksi wajib dipilih")]
        [Display(Name = "Jenis Transaksi")]
        public InventoryTransactionType TransactionType { get; set; }

        [Required(ErrorMessage = "Tanggal transaksi wajib diisi")]
        [Display(Name = "Tanggal Transaksi")]
        [DataType(DataType.DateTime)]
        public DateTime TransactionDate { get; set; } = DateTime.Now;

        [StringLength(500, ErrorMessage = "Keterangan maksimal 500 karakter")]
        [Display(Name = "Keterangan")]
        public string? Notes { get; set; }

        [Required(ErrorMessage = "Penanggung jawab wajib diisi")]
        [Display(Name = "Penanggung Jawab")]
        public int ProcessedById { get; set; }

        // For transfers between departments
        [Display(Name = "Departmen Tujuan")]
        public int? TargetDepartmentId { get; set; }

        // For damage/loss reporting
        [Display(Name = "Kondisi Setelah Transaksi")]
        public InventoryCondition? NewCondition { get; set; }

        [Display(Name = "Lampiran Bukti")]
        public byte[]? Attachment { get; set; }

        [Display(Name = "Tipe Lampiran")]
        [StringLength(50, ErrorMessage = "Tipe lampiran maksimal 50 karakter")]
        public string? AttachmentContentType { get; set; }

        [Display(Name = "Nama File Lampiran")]
        [StringLength(100, ErrorMessage = "Nama file maksimal 100 karakter")]
        public string? AttachmentFileName { get; set; }
    }
}
