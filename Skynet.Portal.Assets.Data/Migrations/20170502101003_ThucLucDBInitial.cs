using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Skynet.Portal.Assets.Data.Migrations
{
    public partial class ThucLucDBInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ThietBis",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BienSo = table.Column<string>(maxLength: 50, nullable: true),
                    CapChatLuong = table.Column<int>(nullable: false),
                    ChungLoai = table.Column<string>(maxLength: 50, nullable: false),
                    DvQuanLy = table.Column<string>(maxLength: 100, nullable: false),
                    DvQuanLyId = table.Column<string>(maxLength: 10, nullable: false),
                    DvSoHuu = table.Column<string>(maxLength: 100, nullable: false),
                    DvSoHuuId = table.Column<string>(maxLength: 10, nullable: false),
                    GhiChu = table.Column<string>(nullable: true),
                    HangSanXuat = table.Column<string>(maxLength: 50, nullable: false),
                    KhuVuc = table.Column<string>(maxLength: 50, nullable: false),
                    KhuVucId = table.Column<string>(maxLength: 10, nullable: false),
                    Loai = table.Column<string>(maxLength: 50, nullable: false),
                    MaMaximo = table.Column<string>(maxLength: 50, nullable: true),
                    MaThietBi = table.Column<string>(maxLength: 50, nullable: false),
                    MaTopX = table.Column<string>(maxLength: 50, nullable: true),
                    MoTa = table.Column<string>(nullable: true),
                    ModelThietBi = table.Column<string>(maxLength: 50, nullable: true),
                    NamSanXuat = table.Column<int>(nullable: false),
                    NamSuDung = table.Column<int>(nullable: false),
                    NhaPhanPhoi = table.Column<string>(maxLength: 50, nullable: true),
                    Nhom = table.Column<string>(maxLength: 50, nullable: false),
                    SoDangKiem = table.Column<string>(maxLength: 50, nullable: true),
                    SoDangKy = table.Column<string>(maxLength: 50, nullable: true),
                    SoKhung = table.Column<string>(maxLength: 50, nullable: true),
                    SoMay = table.Column<string>(maxLength: 50, nullable: true),
                    TrangThai = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThietBis", x => x.Id);
                    table.UniqueConstraint("AK_ThietBis_MaThietBi", x => x.MaThietBi);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThietBis");
        }
    }
}
