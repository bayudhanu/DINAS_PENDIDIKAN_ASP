using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinasPendidikan.Shared.DTOs
{
    public class DocumentCreateDto
    {
        [Required(ErrorMessage = "Nomor surat wajib diisi")]
        [StringLength(50, ErrorMessage = "Nomor surat maksimal 50 karakter")]
        public string DocumentNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Jenis surat wajib dipilih")]
        [Range(1, int.MaxValue, ErrorMessage = "Jenis surat tidak valid")]
        public int DocumentTypeId { get; set; }

        [Required(ErrorMessage = "Perihal surat wajib diisi")]
        [StringLength(200, ErrorMessage = "Perihal maksimal 200 karakter")]
        public string Subject { get; set; } = string.Empty;

        [Required(ErrorMessage = "Isi surat wajib diisi")]
        public string Content { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tanggal surat wajib diisi")]
        [DataType(DataType.Date)]
        public DateTime DocumentDate { get; set; } = DateTime.Today;

        [DataType(DataType.Date)]
        public DateTime? ReceivedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }

        [StringLength(500, ErrorMessage = "Catatan maksimal 500 karakter")]
        public string? Notes { get; set; }

        // Untuk lampiran (akan dihandle secara terpisah)
        public List<DocumentAttachmentDto>? Attachments { get; set; }
    }
}
