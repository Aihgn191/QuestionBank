using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestionBank.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clos",
                columns: table => new
                {
                    CloId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CloName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clos", x => x.CloId);
                });

            migrationBuilder.CreateTable(
                name: "Khoa",
                columns: table => new
                {
                    MaKhoa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenKhoa = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    XoaTamKhoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoa", x => x.MaKhoa);
                });

            migrationBuilder.CreateTable(
                name: "YeuCauRutTrich",
                columns: table => new
                {
                    MaYeuCauDe = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HoTenGiaoVien = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NoiDungRutTrich = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayLay = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YeuCauDe", x => x.MaYeuCauDe);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KhoaID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Khoa_KhoaID",
                        column: x => x.KhoaID,
                        principalTable: "Khoa",
                        principalColumn: "MaKhoa");
                });

            migrationBuilder.CreateTable(
                name: "MonHoc",
                columns: table => new
                {
                    MaMonHoc = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaKhoa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaSoMonHoc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenMonHoc = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    XoaTamMonHoc = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonHoc", x => x.MaMonHoc);
                    table.ForeignKey(
                        name: "FK_MonHoc_Khoa",
                        column: x => x.MaKhoa,
                        principalTable: "Khoa",
                        principalColumn: "MaKhoa");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeThi",
                columns: table => new
                {
                    MaDeThi = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaMonHoc = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenDeThi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DaDuyet = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeThi", x => x.MaDeThi);
                    table.ForeignKey(
                        name: "FK_DeThi_MonHoc",
                        column: x => x.MaMonHoc,
                        principalTable: "MonHoc",
                        principalColumn: "MaMonHoc");
                });

            migrationBuilder.CreateTable(
                name: "Phan",
                columns: table => new
                {
                    MaPhan = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaMonHoc = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenPhan = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuTu = table.Column<int>(type: "int", nullable: false),
                    SoLuongCauHoi = table.Column<int>(type: "int", nullable: false),
                    MaPhanCha = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MaSoPhan = table.Column<int>(type: "int", nullable: true),
                    XoaTamPhan = table.Column<bool>(type: "bit", nullable: true),
                    LaCauHoiNhom = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phan", x => x.MaPhan);
                    table.ForeignKey(
                        name: "FK_Phan_MonHoc",
                        column: x => x.MaMonHoc,
                        principalTable: "MonHoc",
                        principalColumn: "MaMonHoc");
                });

            migrationBuilder.CreateTable(
                name: "CauHoi",
                columns: table => new
                {
                    MaCauHoi = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaPhan = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaSoCauHoi = table.Column<int>(type: "int", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoanVi = table.Column<bool>(type: "bit", nullable: false),
                    CapDo = table.Column<short>(type: "smallint", nullable: false),
                    SoCauHoiCon = table.Column<int>(type: "int", nullable: false),
                    DoPhanCachCauHoi = table.Column<double>(type: "float", nullable: true),
                    MaCauHoiCha = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    XoaTamCauHoi = table.Column<bool>(type: "bit", nullable: true),
                    SoLanDuocThi = table.Column<int>(type: "int", nullable: true),
                    SoLanDung = table.Column<int>(type: "int", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: true),
                    NgaySua = table.Column<DateTime>(type: "datetime", nullable: true),
                    CloId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CauHoi", x => x.MaCauHoi);
                    table.ForeignKey(
                        name: "FK_CauHoi_Clos_CloId",
                        column: x => x.CloId,
                        principalTable: "Clos",
                        principalColumn: "CloId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CauHoi_Phan",
                        column: x => x.MaPhan,
                        principalTable: "Phan",
                        principalColumn: "MaPhan");
                });

            migrationBuilder.CreateTable(
                name: "CauTraLoi",
                columns: table => new
                {
                    MaCauTraLoi = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaCauHoi = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuTu = table.Column<int>(type: "int", nullable: false),
                    LaDapAn = table.Column<bool>(type: "bit", nullable: false),
                    HoanVi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CauTraLoi", x => x.MaCauTraLoi);
                    table.ForeignKey(
                        name: "FK_CauTraLoi_CauHoi",
                        column: x => x.MaCauHoi,
                        principalTable: "CauHoi",
                        principalColumn: "MaCauHoi");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDeThi",
                columns: table => new
                {
                    MaDeThi = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaPhan = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaCauHoi = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThuTu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDeThi", x => new { x.MaDeThi, x.MaPhan, x.MaCauHoi });
                    table.ForeignKey(
                        name: "FK_ChiTietDeThi_CauHoi1",
                        column: x => x.MaCauHoi,
                        principalTable: "CauHoi",
                        principalColumn: "MaCauHoi");
                    table.ForeignKey(
                        name: "FK_ChiTietDeThi_DeThi",
                        column: x => x.MaDeThi,
                        principalTable: "DeThi",
                        principalColumn: "MaDeThi");
                    table.ForeignKey(
                        name: "FK_ChiTietDeThi_Phan",
                        column: x => x.MaPhan,
                        principalTable: "Phan",
                        principalColumn: "MaPhan");
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    MaFile = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaCauHoi = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TenFile = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LoaiFile = table.Column<int>(type: "int", nullable: true),
                    MaCauTraLoi = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.MaFile);
                    table.ForeignKey(
                        name: "FK_File_CauHoi",
                        column: x => x.MaCauHoi,
                        principalTable: "CauHoi",
                        principalColumn: "MaCauHoi");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_KhoaID",
                table: "AspNetUsers",
                column: "KhoaID");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CauHoi_CloId",
                table: "CauHoi",
                column: "CloId");

            migrationBuilder.CreateIndex(
                name: "IX_CauHoi_MaPhan",
                table: "CauHoi",
                column: "MaPhan");

            migrationBuilder.CreateIndex(
                name: "IX_CauTraLoi_MaCauHoi",
                table: "CauTraLoi",
                column: "MaCauHoi");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDeThi_MaCauHoi",
                table: "ChiTietDeThi",
                column: "MaCauHoi");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDeThi_MaPhan",
                table: "ChiTietDeThi",
                column: "MaPhan");

            migrationBuilder.CreateIndex(
                name: "IX_DeThi_MaMonHoc",
                table: "DeThi",
                column: "MaMonHoc");

            migrationBuilder.CreateIndex(
                name: "IX_Files_MaCauHoi",
                table: "Files",
                column: "MaCauHoi");

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_MaKhoa",
                table: "MonHoc",
                column: "MaKhoa");

            migrationBuilder.CreateIndex(
                name: "IX_Phan_MaMonHoc",
                table: "Phan",
                column: "MaMonHoc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CauTraLoi");

            migrationBuilder.DropTable(
                name: "ChiTietDeThi");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "YeuCauRutTrich");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "DeThi");

            migrationBuilder.DropTable(
                name: "CauHoi");

            migrationBuilder.DropTable(
                name: "Clos");

            migrationBuilder.DropTable(
                name: "Phan");

            migrationBuilder.DropTable(
                name: "MonHoc");

            migrationBuilder.DropTable(
                name: "Khoa");
        }
    }
}
