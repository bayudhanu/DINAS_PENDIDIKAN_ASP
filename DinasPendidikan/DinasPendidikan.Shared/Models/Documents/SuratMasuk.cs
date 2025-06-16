using DinasPendidikan.Shared.Models.Shared;

namespace DinasPendidikan.Shared.Models.Documents
{
    public class SuratMasuk : BaseModel
    {
        public string NomorSurat { get; set; } = string.Empty;
        public DateTime TanggalSurat { get; set; }
        public string Pengirim { get; set; } = string.Empty;
        public string Perihal { get; set; } = string.Empty;
        public string IsiRingkas { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public DateTime TanggalDiterima { get; set; }
        public string Penerima { get; set; } = string.Empty;
    }
}