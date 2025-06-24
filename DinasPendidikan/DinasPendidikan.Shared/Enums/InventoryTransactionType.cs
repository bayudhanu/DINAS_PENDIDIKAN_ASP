using System.ComponentModel.DataAnnotations;

namespace DinasPendidikan.Shared.Enums
{
    public enum InventoryTransactionType
    {
        [Display(Name = "Penambahan Stok")]
        StockIn,

        [Display(Name = "Pengurangan Stok")]
        StockOut,

        [Display(Name = "Penyesuaian Stok")]
        Adjustment,

        [Display(Name = "Pemindahan Barang")]
        Transfer,

        [Display(Name = "Barang Rusak")]
        Damage,

        [Display(Name = "Barang Hilang")]
        Loss
    }
}
