using DinasPendidikan.Shared.Models.Shared;

namespace DinasPendidikan.Shared.Models.Documents
{
    public class Disposisi : BaseModel
    {
        public int SuratMasukId { get; set; }
        public string NomorDisposisi { get; set; } = string.Empty;
        public DateTime TanggalDisposisi { get; set; }
        public string Dari { get; set; } = string.Empty;
        public string Kepada { get; set; } = string.Empty;
        public string IsiDisposisi { get; set; } = string.Empty;
        public string Catatan { get; set; } = string.Empty;
    }
}
