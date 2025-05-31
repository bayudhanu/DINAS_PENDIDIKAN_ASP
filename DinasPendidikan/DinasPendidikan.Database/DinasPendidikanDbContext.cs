using DinasPendidikan.Shared.Models.Documents;
using DinasPendidikan.Shared.Models.Inventory;
using DinasPendidikan.Shared.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace DinasPendidikan.Database;

public class DinasPendidikanDbContext : DbContext
{
    public DinasPendidikanDbContext(DbContextOptions<DinasPendidikanDbContext> options) : base(options) { }

    // Tabel-tabel utama
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<DocumentType> DocumentTypes { get; set; }
    public DbSet<DocumentAttachment> DocumentAttachments { get; set; }
    public DbSet<InventoryItem> InventoryItems { get; set; }
    public DbSet<InventoryCategory> InventoryCategories { get; set; }
    public DbSet<InventoryTransaction> InventoryTransactions { get; set; }

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

        modelBuilder.Entity<DocumentType>(entity =>
        {
            entity.HasKey(e => e.Id); // Set Id sebagai primary key
            entity.Property(e => e.Id)
                  .ValueGeneratedOnAdd(); // Config as identity column

            entity.Property(e => e.Name)
                  .IsRequired()
                  .HasMaxLength(100);

            // Seed document types
            modelBuilder.Entity<DocumentType>().HasData(
                new DocumentType { Name = "Surat Masuk", Code = "SM", Description = "Dokumen surat masuk" },
                new DocumentType { Name = "Surat Keluar", Code = "SK", Description = "Dokumen surat keluar" },
                new DocumentType { Name = "Surat Keputusan", Code = "SKEP", Description = "Dokumen surat keputusan" }
            );
        });

        // Seed inventory categories
        modelBuilder.Entity<InventoryCategory>().HasData(
        new InventoryCategory { Name = "Elektronik", Description = "Perangkat elektronik" },
        new InventoryCategory { Name = "Furniture", Description = "Perabot kantor" },
        new InventoryCategory { Name = "Kendaraan", Description = "Kendaraan dinas" }
    );
    }
}
