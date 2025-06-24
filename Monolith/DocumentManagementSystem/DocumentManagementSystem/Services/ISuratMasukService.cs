using DocumentManagementSystem.Models;

namespace DocumentManagementSystem.Services
{
    public interface ISuratMasukService
    {
        Task<IEnumerable<SuratMasuk>> GetAllSuratMasuk();
        Task<SuratMasuk> GetSuratMasukById(int id);
        Task CreateSuratMasuk(SuratMasuk suratMasuk);
        Task UpdateSuratMasuk(SuratMasuk suratMasuk);
        Task DeleteSuratMasuk(int id);
        Task<IEnumerable<SuratMasuk>> SearchSuratMasuk(string keyword);
        Task<int> GetTotalSuratMasuk();
        Task<IEnumerable<SuratMasuk>> GetSuratMasukByDateRange(DateTime startDate, DateTime endDate);
    }
}
