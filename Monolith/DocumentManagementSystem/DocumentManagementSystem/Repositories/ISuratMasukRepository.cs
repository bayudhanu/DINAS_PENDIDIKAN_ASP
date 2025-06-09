using DocumentManagementSystem.Models;

namespace DocumentManagementSystem.Repositories
{
    public interface ISuratMasukRepository
    {
        Task<IEnumerable<SuratMasuk>> GetAll();
        Task<SuratMasuk> GetById(int id);
        Task Add(SuratMasuk suratMasuk);
        Task Update(SuratMasuk suratMasuk);
        Task Delete(int id);
        Task<IEnumerable<SuratMasuk>> GetByStatus(StatusSurat status);
        Task<IEnumerable<SuratMasuk>> GetByDateRange(DateTime startDate, DateTime endDate);
        Task<IEnumerable<SuratMasuk>> Search(string keyword);
    }
}
