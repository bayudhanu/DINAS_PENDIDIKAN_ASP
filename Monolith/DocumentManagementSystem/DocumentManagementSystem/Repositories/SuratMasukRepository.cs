using DocumentManagementSystem.Data;
using DocumentManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DocumentManagementSystem.Repositories
{
    public class SuratMasukRepository : ISuratMasukRepository
    {
        private readonly AppDbContext _context;

        public SuratMasukRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SuratMasuk>> GetAll()
        {
            return await _context.SuratMasuk.OrderByDescending(s => s.TanggalSurat).ToListAsync();
        }

        public async Task<SuratMasuk> GetById(int id)
        {
            return await _context.SuratMasuk.FindAsync(id);
        }

        public async Task Add(SuratMasuk suratMasuk)
        {
            suratMasuk.TanggalDiterima = DateTime.Now;
            _context.SuratMasuk.Add(suratMasuk);
            await _context.SaveChangesAsync();
        }

        public async Task Update(SuratMasuk suratMasuk)
        {
            _context.Entry(suratMasuk).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var suratMasuk = await _context.SuratMasuk.FindAsync(id);
            if (suratMasuk != null)
            {
                _context.SuratMasuk.Remove(suratMasuk);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<SuratMasuk>> GetByStatus(StatusSurat status)
        {
            return await _context.SuratMasuk
                .Where(s => s.Status == status)
                .OrderByDescending(s => s.TanggalSurat)
                .ToListAsync();
        }

        public async Task<IEnumerable<SuratMasuk>> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            return await _context.SuratMasuk
                .Where(s => s.TanggalSurat >= startDate && s.TanggalSurat <= endDate)
                .OrderByDescending(s => s.TanggalSurat)
                .ToListAsync();
        }

        public async Task<IEnumerable<SuratMasuk>> Search(string keyword)
        {
            return await _context.SuratMasuk
                .Where(s => s.NomorSurat.Contains(keyword) ||
                           s.Perihal.Contains(keyword) ||
                           s.AsalSurat.Contains(keyword) ||
                           s.TujuanSurat.Contains(keyword))
                .OrderByDescending(s => s.TanggalSurat)
                .ToListAsync();
        }
    }
}
