
using DinasPendidikan.Shared.Models.Documents;
using Microsoft.EntityFrameworkCore;

namespace DinasPendidikan.Database.Repositories.Documents{
    public interface ISuratMasukRepository
    {
        Task<List<SuratMasuk>> GetAllAsync();
        Task AddAsync(SuratMasuk surat);
        Task<SuratMasuk> GetByIdAsync(int id);
        Task UpdateAsync(SuratMasuk surat);
        Task DeleteAsync(int id);
    }
    public class SuratMasukRepository : ISuratMasukRepository
    {
        private readonly DinasPendidikanDbContext _context;

        public SuratMasukRepository(DinasPendidikanDbContext context)
        {
            _context = context;
        }

        public async Task<List<SuratMasuk>> GetAllAsync()
        {
            return await _context.Set<SuratMasuk>().ToListAsync();
        }

        public async Task AddAsync(SuratMasuk surat)
        {
            await _context.Set<SuratMasuk>().AddAsync(surat);
            await _context.SaveChangesAsync();
        }

        public async Task<SuratMasuk> GetByIdAsync(int id)
        {
            return await _context.Set<SuratMasuk>().FindAsync(id);
        }

        public async Task UpdateAsync(SuratMasuk surat)
        {
            _context.Set<SuratMasuk>().Update(surat);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var surat = await _context.Set<SuratMasuk>().FindAsync(id);
            if (surat != null)
            {
                _context.Set<SuratMasuk>().Remove(surat);
                await _context.SaveChangesAsync();
            }
        }
    }
}
    