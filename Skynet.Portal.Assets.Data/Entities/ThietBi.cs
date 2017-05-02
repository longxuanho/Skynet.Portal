using System;
using System.ComponentModel.DataAnnotations;

namespace Skynet.Portal.Assets.Data.Entities
{
    public class ThietBi
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string MaThietBi { get; set; }

        [MaxLength(50)]
        public string MaTopX { get; set; }

        [MaxLength(50)]
        public string MaMaximo { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nhom { get; set; }

        [Required]
        [MaxLength(50)]
        public string ChungLoai { get; set; }

        [Required]
        [MaxLength(50)]
        public string Loai { get; set; }

        [Required]
        [MaxLength(50)]
        public string HangSanXuat { get; set; }

        [MaxLength(50)]
        public string ModelThietBi { get; set; }

        [MaxLength(50)]
        public string NhaPhanPhoi { get; set; }

        [Range(1900, 2050)]
        public int NamSanXuat { get; set; }

        [Range(1900, 2050)]
        public int NamSuDung { get; set; }

        [Required]
        [MaxLength(100)]
        public string DvQuanLy { get; set; }

        [Required]
        [MaxLength(10)]
        public string DvQuanLyId { get; set; }

        [Required]
        [MaxLength(100)]
        public string DvSoHuu { get; set; }

        [Required]
        [MaxLength(10)]
        public string DvSoHuuId { get; set; }

        [Required]
        [MaxLength(50)]
        public string TrangThai { get; set; }

        [Required]
        [MaxLength(50)]
        public string KhuVuc { get; set; }

        [Required]
        [MaxLength(10)]
        public string KhuVucId { get; set; }

        [MaxLength(50)]
        public string BienSo { get; set; }

        [MaxLength(50)]
        public string SoDangKy { get; set; }

        [MaxLength(50)]
        public string SoKhung { get; set; }

        [MaxLength(50)]
        public string SoMay { get; set; }

        [MaxLength(50)]
        public string SoDangKiem { get; set; }

        [Range(1, 5)]
        public int CapChatLuong { get; set; }

        public string MoTa { get; set; }
        public string GhiChu { get; set; }

    }
}
