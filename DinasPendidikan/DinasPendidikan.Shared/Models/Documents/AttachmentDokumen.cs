using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinasPendidikan.Shared.Models.Shared;

namespace DinasPendidikan.Shared.Models.Documents
{
    public class AttachmentDokumen : BaseModel
    {
        public int DokumenId { get; set; }
        public Dokumen Dokumen { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string FileName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string FileType { get; set; } = string.Empty;

        [Required]
        public long FileSize { get; set; }

        [Required]
        public string FilePath { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? Deskripsi { get; set; }
    }
}
