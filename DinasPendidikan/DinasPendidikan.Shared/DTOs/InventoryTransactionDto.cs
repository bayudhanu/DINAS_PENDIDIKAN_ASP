using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinasPendidikan.Shared.Enums;

namespace DinasPendidikan.Shared.DTOs
{
    public class InventoryTransactionDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "ID barang wajib diisi")]
        [Display(Name = "Barang")]
        public int ItemId { get; set; }

        [Required(ErrorMessage = "Jumlah transaksi wajib diisi")]
        [Range(1, 1000, ErrorMessage = "Jumlah harus antara 1-1000")]
        [Display(Name = "Jumlah")]
        public int QuantityChange { get; set; }

        [Required(ErrorMessage = "Jenis transaksi wajib dipilih")]
        [Display(Name = "Jenis Transaksi")]
        public InventoryTransactionType TransactionType { get; set; }

        [Required(ErrorMessage = "Tanggal transaksi wajib diisi")]
        [Display(Name = "Tanggal Transaksi")]
        [DataType(DataType.DateTime)]
        public DateTime TransactionDate { get; set; } = DateTime.Now;

        [StringLength(200, ErrorMessage = "Catatan maksimal 200 karakter")]
        [Display(Name = "Catatan")]
        public string? Notes { get; set; }

        [Required(ErrorMessage = "Penanggung jawab wajib diisi")]
        [Display(Name = "Penanggung Jawab")]
        public int ProcessedById { get; set; }

        // Navigation properties (for display purposes)
        [Display(Name = "Nama Barang")]
        public string? ItemName { get; set; }

        [Display(Name = "Kode Barang")]
        public string? ItemCode { get; set; }

        [Display(Name = "Ditangani Oleh")]
        public string? ProcessedBy { get; set; }

        [Display(Name = "Stok Sebelumnya")]
        public int PreviousQuantity { get; set; }

        [Display(Name = "Stok Sekarang")]
        public int NewQuantity { get; set; }
    }
}
