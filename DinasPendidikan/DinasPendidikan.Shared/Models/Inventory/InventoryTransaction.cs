using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinasPendidikan.Shared.Models.Shared;

namespace DinasPendidikan.Shared.Models.Inventory
{
    public class InventoryTransaction : BaseUserTrackedModel
    {
        [Required]
        public int ItemId { get; set; }
        public InventoryItem Item { get; set; } = null!;

        [Required]
        public int QuantityChange { get; set; } // Positive for addition, negative for subtraction

        [Required]
        [MaxLength(20)]
        public string TransactionType { get; set; } = "Masuk"; // Masuk, Keluar, Penyesuaian

        [MaxLength(200)]
        public string? Notes { get; set; }
    }
}
