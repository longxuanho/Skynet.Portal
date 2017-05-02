using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Skynet.Portal.Assets.Data.Entities;

namespace Skynet.Portal.Assets.Data.Migrations
{
    [DbContext(typeof(ThucLucContext))]
    [Migration("20170502101003_ThucLucDBInitial")]
    partial class ThucLucDBInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Skynet.Portal.Assets.Data.Entities.ThietBi", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BienSo")
                        .HasMaxLength(50);

                    b.Property<int>("CapChatLuong");

                    b.Property<string>("ChungLoai")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("DvQuanLy")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("DvQuanLyId")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("DvSoHuu")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("DvSoHuuId")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("GhiChu");

                    b.Property<string>("HangSanXuat")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("KhuVuc")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("KhuVucId")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("Loai")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("MaMaximo")
                        .HasMaxLength(50);

                    b.Property<string>("MaThietBi")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("MaTopX")
                        .HasMaxLength(50);

                    b.Property<string>("MoTa");

                    b.Property<string>("ModelThietBi")
                        .HasMaxLength(50);

                    b.Property<int>("NamSanXuat");

                    b.Property<int>("NamSuDung");

                    b.Property<string>("NhaPhanPhoi")
                        .HasMaxLength(50);

                    b.Property<string>("Nhom")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("SoDangKiem")
                        .HasMaxLength(50);

                    b.Property<string>("SoDangKy")
                        .HasMaxLength(50);

                    b.Property<string>("SoKhung")
                        .HasMaxLength(50);

                    b.Property<string>("SoMay")
                        .HasMaxLength(50);

                    b.Property<string>("TrangThai")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasAlternateKey("MaThietBi");

                    b.ToTable("ThietBis");
                });
        }
    }
}
