
using DinasPendidikan.Shared.Models.Inventory;
using Microsoft.EntityFrameworkCore;

namespace DinasPendidikan.Database.Repositories.Inventory{
    public interface IDaftarBarangRepository
    {
        Task<List<DaftarBarang>> GetAllAsync();
        Task AddAsync(DaftarBarang daftarBarang);
        Task<DaftarBarang> GetByIdAsync(int id);
        Task UpdateAsync(DaftarBarang daftarBarang);
        Task DeleteAsync(int id);
    }
    public class DaftarBarangRepository : IDaftarBarangRepository
    {
        private readonly DinasPendidikanDbContext _context;

        public DaftarBarangRepository(DinasPendidikanDbContext context)
        {
            _context = context;
        }

        public async Task<List<DaftarBarang>> GetAllAsync()
        {
            return await _context.Set<DaftarBarang>().ToListAsync();
        }   

        public async Task AddAsync(DaftarBarang daftarBarang)
        {
            await _context.Set<DaftarBarang>().AddAsync(daftarBarang);
            await _context.SaveChangesAsync();
        }

        public async Task<DaftarBarang> GetByIdAsync(int id)
        {
            return await _context.Set<DaftarBarang>().FindAsync(id) ?? new DaftarBarang();
        }

        public async Task UpdateAsync(DaftarBarang daftarBarang)
        {
            _context.Set<DaftarBarang>().Update(daftarBarang);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var daftarBarang = await _context.Set<DaftarBarang>().FindAsync(id);
            if (daftarBarang != null)
            {
                _context.Set<DaftarBarang>().Remove(daftarBarang);
                await _context.SaveChangesAsync();
            }
        }
    }
}