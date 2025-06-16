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
    public class Dokumen : BaseUserTrackedModel
    {

        [MaxLength(50)]
        public string NomorDokumen { get; set; } = string.Empty;

        public int TipeDokumenId { get; set; }
        public TipeDokumen TipeDokumen { get; set; } = null;
        [Required]
        [MaxLength(200)]
        public string Judul { get; set; } = string.Empty;
        [Required]
        public string Konten { get; set; } = string.Empty;
        public DateTime TanggalDokumen { get; set; } = DateTime.UtcNow;
        public DateTime? TanggalTerima { get; set; }
        public string? Catatan { get; set; }

        // Navigation properties
        public ICollection<AttachmentDokumen> Attachments { get; set; } = new List<AttachmentDokumen>();
    }
}
