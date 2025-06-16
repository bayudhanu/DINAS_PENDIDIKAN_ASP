using DinasPendidikan.Shared.Models.Documents;
using Microsoft.EntityFrameworkCore;

namespace DinasPendidikan.Database.Repositories.Documents
{

    public interface IDisposisiRepository
    {
        Task<List<Disposisi>> GetAllAsync();
        Task AddAsync(Disposisi disposisi);
        Task<Disposisi> GetByIdAsync(int id);
        Task UpdateAsync(Disposisi disposisi);
        Task DeleteAsync(int id);
    }
    public class DisposisiRepository : IDisposisiRepository
    {
        private readonly DinasPendidikanDbContext _context;

        public DisposisiRepository(DinasPendidikanDbContext context)
        {
            _context = context;
        }

        public async Task<List<Disposisi>> GetAllAsync()
        {
            return await _context.Set<Disposisi>().ToListAsync();
        }

        public async Task AddAsync(Disposisi disposisi)
        {
            await _context.Set<Disposisi>().AddAsync(disposisi);
            await _context.SaveChangesAsync();
        }

        public async Task<Disposisi> GetByIdAsync(int id)
        {
            var disposisi = await _context.Set<Disposisi>().FindAsync(id);
            if (disposisi == null)
            {
                throw new InvalidOperationException($"Disposisi with id {id} not found.");
            }
            return disposisi;
        }

        public async Task UpdateAsync(Disposisi disposisi)
        {
            _context.Set<Disposisi>().Update(disposisi);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var disposisi = await _context.Set<Disposisi>().FindAsync(id);
            if (disposisi != null)
            {
                _context.Set<Disposisi>().Remove(disposisi);
                await _context.SaveChangesAsync();
            }
        }
    }
}