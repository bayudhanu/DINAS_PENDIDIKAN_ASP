using DocumentManagementSystem.Models;
using DocumentManagementSystem.Repositories;

namespace DocumentManagementSystem.Services
{
    public class SuratMasukService : ISuratMasukService
    {
        private readonly ISuratMasukRepository _suratMasukRepository;
        private readonly IFileUploadService _fileUploadService;

        public SuratMasukService(
            ISuratMasukRepository suratMasukRepository,
            IFileUploadService fileUploadService)
        {
            _suratMasukRepository = suratMasukRepository;
            _fileUploadService = fileUploadService;
        }

        public async Task<IEnumerable<SuratMasuk>> GetAllSuratMasuk()
        {
            return await _suratMasukRepository.GetAll();
        }

        public async Task<SuratMasuk> GetSuratMasukById(int id)
        {
            return await _suratMasukRepository.GetById(id);
        }
        public async Task<List<SuratMasuk>> GetByStatus(StatusSurat status)
        {
            return (await _suratMasukRepository.GetByStatus(status)).ToList();
        }
        public async Task CreateSuratMasuk(SuratMasuk suratMasuk)
        {
            if (suratMasuk.FileSurat != null)
            {
                using var stream = suratMasuk.FileSurat.OpenReadStream();
                suratMasuk.FilePath = await _fileUploadService.UploadFileAsync(stream, suratMasuk.FileSurat.FileName);
            }

            await _suratMasukRepository.Add(suratMasuk);
        }

        public async Task UpdateSuratMasuk(SuratMasuk suratMasuk)
        {
            if (suratMasuk.FileSurat != null)
            {
                // Hapus file lama jika ada
                if (!string.IsNullOrEmpty(suratMasuk.FilePath))
                {
                    await _fileUploadService.DeleteFileAsync(suratMasuk.FilePath);
                }

                // Upload file baru
                using var stream = suratMasuk.FileSurat.OpenReadStream();
                suratMasuk.FilePath = await _fileUploadService.UploadFileAsync(stream, suratMasuk.FileSurat.FileName);
            }

            await _suratMasukRepository.Update(suratMasuk);
        }

        public async Task DeleteSuratMasuk(int id)
        {
            var surat = await _suratMasukRepository.GetById(id);
            if (surat != null && !string.IsNullOrEmpty(surat.FilePath))
            {
                await _fileUploadService.DeleteFileAsync(surat.FilePath);
            }

            await _suratMasukRepository.Delete(id);
        }

        public async Task<IEnumerable<SuratMasuk>> SearchSuratMasuk(string keyword)
        {
            return await _suratMasukRepository.Search(keyword);
        }

        public async Task<int> GetTotalSuratMasuk()
        {
            return await _suratMasukRepository.GetTotalCount();
        }

        public async Task<IEnumerable<SuratMasuk>> GetSuratMasukByDateRange(DateTime startDate, DateTime endDate)
        {
            return await _suratMasukRepository.GetByDateRange(startDate, endDate);
        }

    }
}
