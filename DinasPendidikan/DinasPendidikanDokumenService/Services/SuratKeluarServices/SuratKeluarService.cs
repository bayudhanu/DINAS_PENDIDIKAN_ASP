using DinasPendidikan.Database;
using DinasPendidikan.Database.Repositories.Documents;
using DinasPendidikan.Shared.Models.Documents;


namespace DinasPendidikanDokumenService.Services.SuratKeluarServices
{

    public interface ISuratKeluarService
    {
        Task<List<SuratKeluar>> GetAllAsync();
        Task AddAsync(SuratKeluar surat);
        Task<SuratKeluar> GetByIdAsync(int id);
        Task UpdateAsync(SuratKeluar surat);
        Task DeleteAsync(int id);
    }
    public class SuratKeluarService : ISuratKeluarService
    {
        private readonly ISuratKeluarRepository _suratKeluarRepository;

        public SuratKeluarService(ISuratKeluarRepository suratKeluarRepository)
        {
            _suratKeluarRepository = suratKeluarRepository;
        }

        public async Task<List<SuratKeluar>> GetAllAsync()
        {
            return await _suratKeluarRepository.GetAllAsync();
        }
        public async Task AddAsync(SuratKeluar surat)
        {
            await _suratKeluarRepository.AddAsync(surat);
        }
        public async Task<SuratKeluar> GetByIdAsync(int id)
        {
            return await _suratKeluarRepository.GetByIdAsync(id);
        }
        public async Task UpdateAsync(SuratKeluar surat)
        {
            await _suratKeluarRepository.UpdateAsync(surat);
        }
        public async Task DeleteAsync(int id)
        {
            await _suratKeluarRepository.DeleteAsync(id);
        }
    }
}