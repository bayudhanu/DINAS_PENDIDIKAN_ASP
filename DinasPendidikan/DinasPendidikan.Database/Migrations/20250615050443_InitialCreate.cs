using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DinasPendidikan.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Disposisi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SuratMasukId = table.Column<int>(type: "integer", nullable: false),
                    NomorDisposisi = table.Column<string>(type: "text", nullable: false),
                    TanggalDisposisi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Dari = table.Column<string>(type: "text", nullable: false),
                    Kepada = table.Column<string>(type: "text", nullable: false),
                    IsiDisposisi = table.Column<string>(type: "text", nullable: false),
                    Catatan = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disposisi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KategoriBarang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nama = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Deskripsi = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KategoriBarang", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuratKeluar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomorSurat = table.Column<string>(type: "text", nullable: false),
                    TanggalSurat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Tujuan = table.Column<string>(type: "text", nullable: false),
                    Perihal = table.Column<string>(type: "text", nullable: false),
                    IsiRingkas = table.Column<string>(type: "text", nullable: false),
                    FilePath = table.Column<string>(type: "text", nullable: false),
                    Penandatangan = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuratKeluar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuratKeputusan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomorSuratKeputusan = table.Column<string>(type: "text", nullable: false),
                    TanggalSuratKeputusan = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Dari = table.Column<string>(type: "text", nullable: false),
                    Kepada = table.Column<string>(type: "text", nullable: false),
                    IsiSuratKeputusan = table.Column<string>(type: "text", nullable: false),
                    Catatan = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuratKeputusan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuratMasuk",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomorSurat = table.Column<string>(type: "text", nullable: false),
                    TanggalSurat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Pengirim = table.Column<string>(type: "text", nullable: false),
                    Perihal = table.Column<string>(type: "text", nullable: false),
                    IsiRingkas = table.Column<string>(type: "text", nullable: false),
                    FilePath = table.Column<string>(type: "text", nullable: false),
                    TanggalDiterima = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Penerima = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuratMasuk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipeDokumen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nama = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Kode = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Deskripsi = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipeDokumen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    FullName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    PasswordSalt = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DaftarBarang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KodeBarang = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    NamaBarang = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    KategoriBarangId = table.Column<int>(type: "integer", nullable: false),
                    Deskripsi = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Jumlah = table.Column<int>(type: "integer", nullable: false),
                    Kondisi = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    TanggalPembelian = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    HargaPembelian = table.Column<decimal>(type: "numeric", nullable: true),
                    Lokasi = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaftarBarang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DaftarBarang_KategoriBarang_KategoriBarangId",
                        column: x => x.KategoriBarangId,
                        principalTable: "KategoriBarang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dokumen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomorDokumen = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TipeDokumenId = table.Column<int>(type: "integer", nullable: false),
                    Judul = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Konten = table.Column<string>(type: "text", nullable: false),
                    TanggalDokumen = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TanggalTerima = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Catatan = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    UpdatedById = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dokumen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dokumen_TipeDokumen_TipeDokumenId",
                        column: x => x.TipeDokumenId,
                        principalTable: "TipeDokumen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dokumen_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dokumen_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransaksiBarang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DaftarBarangId = table.Column<int>(type: "integer", nullable: false),
                    Jumlah = table.Column<int>(type: "integer", nullable: false),
                    JenisTransaksi = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Catatan = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    UpdatedById = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransaksiBarang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransaksiBarang_DaftarBarang_DaftarBarangId",
                        column: x => x.DaftarBarangId,
                        principalTable: "DaftarBarang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransaksiBarang_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransaksiBarang_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AttachmentDokumen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DokumenId = table.Column<int>(type: "integer", nullable: false),
                    FileName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    FileType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "text", nullable: false),
                    Deskripsi = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentDokumen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttachmentDokumen_Dokumen_DokumenId",
                        column: x => x.DokumenId,
                        principalTable: "Dokumen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentDokumen_DokumenId",
                table: "AttachmentDokumen",
                column: "DokumenId");

            migrationBuilder.CreateIndex(
                name: "IX_DaftarBarang_KategoriBarangId",
                table: "DaftarBarang",
                column: "KategoriBarangId");

            migrationBuilder.CreateIndex(
                name: "IX_Dokumen_CreatedById",
                table: "Dokumen",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Dokumen_TipeDokumenId",
                table: "Dokumen",
                column: "TipeDokumenId");

            migrationBuilder.CreateIndex(
                name: "IX_Dokumen_UpdatedById",
                table: "Dokumen",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TransaksiBarang_CreatedById",
                table: "TransaksiBarang",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TransaksiBarang_DaftarBarangId",
                table: "TransaksiBarang",
                column: "DaftarBarangId");

            migrationBuilder.CreateIndex(
                name: "IX_TransaksiBarang_UpdatedById",
                table: "TransaksiBarang",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttachmentDokumen");

            migrationBuilder.DropTable(
                name: "Disposisi");

            migrationBuilder.DropTable(
                name: "SuratKeluar");

            migrationBuilder.DropTable(
                name: "SuratKeputusan");

            migrationBuilder.DropTable(
                name: "SuratMasuk");

            migrationBuilder.DropTable(
                name: "TransaksiBarang");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Dokumen");

            migrationBuilder.DropTable(
                name: "DaftarBarang");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "TipeDokumen");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "KategoriBarang");
        }
    }
}
