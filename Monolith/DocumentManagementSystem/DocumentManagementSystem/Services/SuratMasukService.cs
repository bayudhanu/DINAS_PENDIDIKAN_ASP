using DocumentManagementSystem.Models;
using DocumentManagementSystem.Repositories;

namespace DocumentManagementSystem.Services
{
    public class SuratMasukService : ISuratMasukService
    {
        private readonly ISuratMasukRepository _repository;

        public SuratMasukService(ISuratMasukRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SuratMasuk>> GetAll()
        {
            return (await _repository.GetAll()).ToList();
        }

        public async Task<SuratMasuk> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task Create(SuratMasuk suratMasuk)
        {
            Console.WriteLine("Creating Surat Masuk...");
            await _repository.Add(suratMasuk);
        }

        public async Task Update(SuratMasuk suratMasuk)
        {
            await _repository.Update(suratMasuk);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<List<SuratMasuk>> GetByStatus(StatusSurat status)
        {
            return (await _repository.GetByStatus(status)).ToList();
        }

        public async Task<List<SuratMasuk>> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            return (await _repository.GetByDateRange(startDate, endDate)).ToList();
        }

        public async Task<List<SuratMasuk>> Search(string keyword)
        {
            return (await _repository.Search(keyword)).ToList();
        }
    }
}
