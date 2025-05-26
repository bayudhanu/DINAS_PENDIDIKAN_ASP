using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinasPendidikan.Shared.DTOs
{
    public class DocumentAttachmentDto
    {
        [Required(ErrorMessage = "Nama file wajib diisi")]
        [StringLength(100, ErrorMessage = "Nama file maksimal 100 karakter")]
        public string FileName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tipe file wajib diisi")]
        [StringLength(50, ErrorMessage = "Tipe file maksimal 50 karakter")]
        public string FileType { get; set; } = string.Empty;

        [Required(ErrorMessage = "File content wajib diisi")]
        public byte[] FileContent { get; set; } = Array.Empty<byte>();

        [StringLength(200, ErrorMessage = "Deskripsi maksimal 200 karakter")]
        public string? Description { get; set; }
    }
}
