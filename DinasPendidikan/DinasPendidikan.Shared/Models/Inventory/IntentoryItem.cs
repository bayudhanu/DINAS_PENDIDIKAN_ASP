using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinasPendidikan.Shared.Models.Shared;

namespace DinasPendidikan.Shared.Models.Inventory
{
    public class InventoryItem : BaseModel
    {

        [MaxLength(20)]
        public string ItemCode { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int CategoryId { get; set; }
        public InventoryCategory Category { get; set; } = null!;

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [MaxLength(20)]
        public string Condition { get; set; } = "Baik"; // Baik, Rusak Ringan, Rusak Berat

        public DateTime? PurchaseDate { get; set; }
        public decimal? PurchasePrice { get; set; }

        [MaxLength(100)]
        public string? Location { get; set; }

        // Navigation properties
        public ICollection<InventoryTransaction> Transactions { get; set; } = new List<InventoryTransaction>();
    }
}
