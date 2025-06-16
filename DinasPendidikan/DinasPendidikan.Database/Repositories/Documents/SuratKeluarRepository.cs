
using DinasPendidikan.Shared.Models.Documents;
using Microsoft.EntityFrameworkCore;

namespace DinasPendidikan.Database.Repositories.Documents{
    
    public interface ISuratKeluarRepository
    {
        Task<List<SuratKeluar>> GetAllAsync();
        Task AddAsync(SuratKeluar surat);
        Task<SuratKeluar> GetByIdAsync(int id);
        Task UpdateAsync(SuratKeluar surat);
        Task DeleteAsync(int id);
    }

    public class SuratKeluarRepository : ISuratKeluarRepository
    {
        private readonly DinasPendidikanDbContext _context;

        public SuratKeluarRepository(DinasPendidikanDbContext context)
        {
            _context = context;
        }

        public async Task<List<SuratKeluar>> GetAllAsync()
        {
            return await _context.Set<SuratKeluar>().ToListAsync();
        }

        public async Task AddAsync(SuratKeluar surat)
        {
            await _context.Set<SuratKeluar>().AddAsync(surat);
            await _context.SaveChangesAsync();
        }

        public async Task<SuratKeluar> GetByIdAsync(int id)
        {
            return await _context.Set<SuratKeluar>().FindAsync(id);
        }

        public async Task UpdateAsync(SuratKeluar surat)
        {
            _context.Set<SuratKeluar>().Update(surat);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var surat = await _context.Set<SuratKeluar>().FindAsync(id);
            if (surat != null)
            {
                _context.Set<SuratKeluar>().Remove(surat);
                await _context.SaveChangesAsync();
            }
        }
    }
}