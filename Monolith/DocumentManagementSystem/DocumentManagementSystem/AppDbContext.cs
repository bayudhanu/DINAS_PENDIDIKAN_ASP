using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DocumentManagementSystem.Models;

namespace DocumentManagementSystem
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions options) // Removed generic type parameter <AppDbContext>
            : base(options)
        {
        }

        public DbSet<SuratMasuk> SuratMasuk { get; set; } = null!; // Added null-forgiving operator to suppress CS8618
        public DbSet<SuratKeluar> SuratKeluar { get; set; } = null!;
        public DbSet<Disposisi> Disposisi { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Konfigurasi tambahan untuk model Surat
            builder.Entity<SuratMasuk>()
                .Property(s => s.SifatSurat)
                .HasConversion<string>();

            builder.Entity<SuratMasuk>()
                .Property(s => s.Status)
                .HasConversion<string>();
        }
    }
}
