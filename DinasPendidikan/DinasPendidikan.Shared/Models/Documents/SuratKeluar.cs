
using DinasPendidikan.Shared.Models.Shared;

namespace DinasPendidikan.Shared.Models.Documents
{
public class SuratKeluar: BaseModel
{
    public string NomorSurat { get; set; } = string.Empty;
    public DateTime TanggalSurat { get; set; }
    public string Tujuan { get; set; } = string.Empty;
    public string Perihal { get; set; } = string.Empty;
    public string IsiRingkas { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public string Penandatangan { get; set; } = string.Empty;
}
}