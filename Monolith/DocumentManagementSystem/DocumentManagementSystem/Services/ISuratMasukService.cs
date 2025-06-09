using DocumentManagementSystem.Models;

namespace DocumentManagementSystem.Services
{
    public interface ISuratMasukService
    {
        Task<List<SuratMasuk>> GetAll();
        Task<SuratMasuk> GetById(int id);
        Task Create(SuratMasuk suratMasuk);
        Task Update(SuratMasuk suratMasuk);
        Task Delete(int id);
        Task<List<SuratMasuk>> GetByStatus(StatusSurat status);
        Task<List<SuratMasuk>> GetByDateRange(DateTime startDate, DateTime endDate);
        Task<List<SuratMasuk>> Search(string keyword);
    }
}
