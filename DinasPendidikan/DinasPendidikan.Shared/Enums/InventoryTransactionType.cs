using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
