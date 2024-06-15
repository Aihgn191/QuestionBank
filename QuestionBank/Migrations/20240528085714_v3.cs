using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestionBank.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CauHoi_Clos_CloId",
                table: "CauHoi");

            migrationBuilder.AlterColumn<int>(
                name: "CloId",
                table: "CauHoi",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "MaTran",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaMonHoc = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaPhan = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Clo1 = table.Column<int>(type: "int", nullable: false),
                    Clo2 = table.Column<int>(type: "int", nullable: false),
                    Clo3 = table.Column<int>(type: "int", nullable: false),
                    SoCauHoi = table.Column<int>(type: "int", nullable: false),
                    TenPhan = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaTran", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CauHoi_Clos_CloId",
                table: "CauHoi",
                column: "CloId",
                principalTable: "Clos",
                principalColumn: "CloId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CauHoi_Clos_CloId",
                table: "CauHoi");

            migrationBuilder.DropTable(
                name: "MaTran");

            migrationBuilder.AlterColumn<int>(
                name: "CloId",
                table: "CauHoi",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CauHoi_Clos_CloId",
                table: "CauHoi",
                column: "CloId",
                principalTable: "Clos",
                principalColumn: "CloId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
