using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinasPendidikan.Shared.Models.Shared;

namespace DinasPendidikan.Shared.Models.Documents
{
    public class DocumentType : BaseModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Code { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? Description { get; set; }

        // Navigation properties
        public ICollection<Document> Documents { get; set; } = new List<Document>();
    }
}
