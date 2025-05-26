using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinasPendidikan.Shared.DTOs
{
    public class DocumentDto
    {
        public int Id { get; set; }
        public string DocumentNumber { get; set; } = string.Empty;
        public string DocumentType { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime DocumentDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
