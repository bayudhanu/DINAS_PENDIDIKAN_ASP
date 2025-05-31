using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinasPendidikan.Shared.Models.Shared;
using System.Xml.Linq;

namespace DinasPendidikan.Shared.Models.Documents
{
    public class Document : BaseUserTrackedModel
    {

        [MaxLength(50)]
        public string DocumentNumber { get; set; } = string.Empty;

        public int DocumentTypeId { get; set; }
        public DocumentType DocumentType { get; set; } = null;
        [Required]
        [MaxLength(200)]
        public string Subject { get; set; } = string.Empty;
        [Required]
        public string Content { get; set; } = string.Empty;
        public DateTime DocumentDate { get; set; } = DateTime.UtcNow;
        public DateTime? ReceivedDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string? Notes { get; set; }

        // Navigation properties
        public ICollection<DocumentAttachment> Attachments { get; set; } = new List<DocumentAttachment>();
    }
}
