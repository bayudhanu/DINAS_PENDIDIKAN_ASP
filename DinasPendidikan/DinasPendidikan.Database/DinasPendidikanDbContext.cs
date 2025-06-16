using DinasPendidikan.Shared.Models.Documents;
using DinasPendidikan.Shared.Models.Inventory;
using DinasPendidikan.Shared.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace DinasPendidikan.Database;

public class DinasPendidikanDbContext : DbContext
{
    public DinasPendidikanDbContext(DbContextOptions<DinasPendidikanDbContext> options) : base(options) { }

    // Tabel-tabel utama
    public DbSet<User> User { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<UserRole> UserRole { get; set; }
    public DbSet<Dokumen> Dokumen { get; set; }
    public DbSet<TipeDokumen> TipeDokumen { get; set; }
    public DbSet<AttachmentDokumen> AttachmentDokumen { get; set; }
    public DbSet<Disposisi> Disposisi { get; set; }
    public DbSet<SuratMasuk> SuratMasuk { get; set; }
    public DbSet<SuratKeluar> SuratKeluar { get; set; }
    public DbSet<SuratKeputusan> SuratKeputusan { get; set; }   
    public DbSet<DaftarBarang> DaftarBarang { get; set; }
    public DbSet<KategoriBarang> KategoriBarang { get; set; }
    public DbSet<TransaksiBarang> TransaksiBarang { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //base.OnModelCreating(modelBuilder);

        // User-Role many-to-many
        modelBuilder.Entity<UserRole>()
            .HasKey(ur => new { ur.UserId, ur.RoleId });

        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.User)
            .WithMany()
            .HasForeignKey(ur => ur.UserId);

        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.Role)
            .WithMany()
            .HasForeignKey(ur => ur.RoleId);

        // Seed data awal
        //SeedInitialData(modelBuilder);
    }

    private void SeedInitialData(ModelBuilder modelBuilder)
    {
        // Seed roles
        modelBuilder.Entity<Role>().HasData(
            new Role { Name = "Administrator", Description = "Full access" },
            new Role { Name = "Staff", Description = "Staff access" },
            new Role { Name = "Viewer", Description = "Read-only access" }
        );

        // Seed admin user (password akan di-hash saat runtime)
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Username = "admin",
                Email = "admin@dindik.boyolali.go.id",
                FullName = "Administrator",
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            }
        );

        // Seed user role untuk admin
        modelBuilder.Entity<UserRole>().HasData(
            new UserRole { UserId = 1, RoleId = 1 }
        );

        modelBuilder.Entity<TipeDokumen>(entity =>
        {
            entity.HasKey(e => e.Id); // Set Id sebagai primary key
            entity.Property(e => e.Id)
                  .ValueGeneratedOnAdd(); // Config as identity column

            entity.Property(e => e.Nama)
                  .IsRequired()
                  .HasMaxLength(100);

            // Seed document types
            modelBuilder.Entity<TipeDokumen>().HasData(
                new TipeDokumen { Nama = "Surat Masuk", Kode = "SM", Deskripsi = "Dokumen surat masuk" },
                new TipeDokumen { Nama = "Surat Keluar", Kode = "SK", Deskripsi = "Dokumen surat keluar" },
                new TipeDokumen { Nama = "Surat Keputusan", Kode = "SKEP", Deskripsi = "Dokumen surat keputusan" }
            );
        });

        // Seed inventory categories
        modelBuilder.Entity<KategoriBarang>().HasData(
        new KategoriBarang { Nama = "Elektronik", Deskripsi = "Perangkat elektronik" },
        new KategoriBarang { Nama = "Furniture", Deskripsi = "Perabot kantor" },
        new KategoriBarang { Nama = "Kendaraan", Deskripsi = "Kendaraan dinas" }
    );
    }
}
