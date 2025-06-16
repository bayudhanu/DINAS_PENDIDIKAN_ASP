using DinasPendidikan.Shared.Models.Shared;

namespace DinasPendidikan.Shared.Models.Documents
{
    public class SuratKeputusan : BaseModel
    {
        public string NomorSuratKeputusan { get; set; } = string.Empty;
        public DateTime TanggalSuratKeputusan { get; set; }
        public string Dari { get; set; } = string.Empty;
        public string Kepada { get; set; } = string.Empty;
        public string IsiSuratKeputusan { get; set; } = string.Empty;
        public string Catatan { get; set; } = string.Empty;
    }
}
