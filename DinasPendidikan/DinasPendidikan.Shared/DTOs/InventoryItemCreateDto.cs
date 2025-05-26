using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinasPendidikan.Shared.Enums;

namespace DinasPendidikan.Shared.DTOs
{
    public class InventoryItemCreateDto
    {
        [Required(ErrorMessage = "Kode barang wajib diisi")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Kode barang harus 3-20 karakter")]
        [RegularExpression(@"^[A-Z0-9-]+$",
            ErrorMessage = "Hanya boleh huruf kapital, angka, dan strip (-)")]
        [Display(Name = "Kode Barang")]
        public string ItemCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Nama barang wajib diisi")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Nama barang harus 3-100 karakter")]
        [Display(Name = "Nama Barang")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Kategori wajib dipilih")]
        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }

        [StringLength(500, ErrorMessage = "Deskripsi maksimal 500 karakter")]
        [Display(Name = "Deskripsi")]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Jumlah wajib diisi")]
        [Range(1, 1000, ErrorMessage = "Jumlah harus antara 1-1000")]
        [Display(Name = "Jumlah")]
        public int Quantity { get; set; } = 1;

        [Required(ErrorMessage = "Kondisi wajib dipilih")]
        [Display(Name = "Kondisi")]
        public InventoryCondition Condition { get; set; } = InventoryCondition.Baik;

        [Display(Name = "Tanggal Pembelian")]
        [DataType(DataType.Date)]
        public DateTime? PurchaseDate { get; set; }

        [Display(Name = "Harga Pembelian")]
        [Range(0, 1000000000, ErrorMessage = "Harga tidak valid")]
        [DataType(DataType.Currency)]
        public decimal? PurchasePrice { get; set; }

        [StringLength(50, ErrorMessage = "Lokasi maksimal 50 karakter")]
        [Display(Name = "Lokasi")]
        public string? Location { get; set; }

        [Required(ErrorMessage = "Pemilik wajib dipilih")]
        [Display(Name = "Pemilik")]
        public int DepartmentId { get; set; }

        [Display(Name = "Gambar Barang")]
        public byte[]? ImageData { get; set; }

        [StringLength(50, ErrorMessage = "Tipe gambar maksimal 50 karakter")]
        public string? ImageContentType { get; set; }

        [StringLength(100, ErrorMessage = "Nama file maksimal 100 karakter")]
        public string? OriginalImageName { get; set; }

        // Audit fields
        [Required]
        public int CreatedById { get; set; }
    }
}
