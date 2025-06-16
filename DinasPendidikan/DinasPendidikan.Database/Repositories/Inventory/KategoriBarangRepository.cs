
using DinasPendidikan.Shared.Models.Inventory;
using Microsoft.EntityFrameworkCore;

namespace DinasPendidikan.Database.Repositories.Inventory{
    public interface IKategoriBarangRepository
    {
        Task<List<KategoriBarang>> GetAllAsync();
        Task AddAsync(KategoriBarang kategoriBarang);
        Task<KategoriBarang> GetByIdAsync(int id);
        Task UpdateAsync(KategoriBarang kategoriBarang);
        Task DeleteAsync(int id);
    }
    public class KategoriBarangRepository : IKategoriBarangRepository
    {
        private readonly DinasPendidikanDbContext _context;

        public KategoriBarangRepository(DinasPendidikanDbContext context)
        {
            _context = context;
        }

        public async Task<List<KategoriBarang>> GetAllAsync()
        {
            return await _context.Set<KategoriBarang>().ToListAsync();
        }

        public async Task AddAsync(KategoriBarang kategoriBarang)
        {
            await _context.Set<KategoriBarang>().AddAsync(kategoriBarang);
            await _context.SaveChangesAsync();
        }

        public async Task<KategoriBarang> GetByIdAsync(int id)
        {
            return await _context.Set<KategoriBarang>().FindAsync(id);
        }

        public async Task UpdateAsync(KategoriBarang kategoriBarang)
        {
            _context.Set<KategoriBarang>().Update(kategoriBarang);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var kategoriBarang = await _context.Set<KategoriBarang>().FindAsync(id);
            if (kategoriBarang != null)
            {
                _context.Set<KategoriBarang>().Remove(kategoriBarang);
                await _context.SaveChangesAsync();
            }
        }
    }
}