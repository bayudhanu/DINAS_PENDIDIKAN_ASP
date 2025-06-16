
using DinasPendidikan.Shared.Models.Inventory;
using Microsoft.EntityFrameworkCore;

namespace DinasPendidikan.Database.Repositories.Inventory{
    public interface ITransaksiBarangRepository
    {
        Task<List<TransaksiBarang>> GetAllAsync();
        Task AddAsync(TransaksiBarang transaksiBarang);
        Task<TransaksiBarang> GetByIdAsync(int id);
        Task UpdateAsync(TransaksiBarang transaksiBarang);
        Task DeleteAsync(int id);
    }
    public class TransaksiBarangRepository : ITransaksiBarangRepository
    {
        private readonly DinasPendidikanDbContext _context;

        public TransaksiBarangRepository(DinasPendidikanDbContext context)
        {
            _context = context;
        }

        public async Task<List<TransaksiBarang>> GetAllAsync()
        {
            return await _context.Set<TransaksiBarang>().ToListAsync();
        }

        public async Task AddAsync(TransaksiBarang transaksiBarang)
        {
            await _context.Set<TransaksiBarang>().AddAsync(transaksiBarang);
            await _context.SaveChangesAsync();
        }

        public async Task<TransaksiBarang> GetByIdAsync(int id)
        {
            return await _context.Set<TransaksiBarang>().FindAsync(id) ?? new TransaksiBarang();
        }

        public async Task UpdateAsync(TransaksiBarang transaksiBarang)
        {
            _context.Set<TransaksiBarang>().Update(transaksiBarang);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var transaksiBarang = await _context.Set<TransaksiBarang>().FindAsync(id);
            if (transaksiBarang != null)
            {
                _context.Set<TransaksiBarang>().Remove(transaksiBarang);
                await _context.SaveChangesAsync();
            }
        }
    }
}