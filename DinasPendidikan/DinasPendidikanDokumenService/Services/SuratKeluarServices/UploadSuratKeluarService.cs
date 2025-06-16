using DinasPendidikan.Database;

namespace DinasPendidikanDokumenService.Services.SuratKeluarServices
{
    public interface IUploadSuratKeluarService
    {

    }
    public class UploadSuratKeluarService : IUploadSuratKeluarService
    {
        private readonly DinasPendidikanDbContext _context;

        public UploadSuratKeluarService(DinasPendidikanDbContext context)
        {
            _context = context;
        }
    }
}
