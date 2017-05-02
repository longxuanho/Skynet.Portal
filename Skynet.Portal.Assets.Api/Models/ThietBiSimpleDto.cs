using System;

namespace Skynet.Portal.Assets.Api.Models
{
    public class ThietBiSimpleDto
    {
        public Guid Id { get; set; }

        public string MaThietBi { get; set; }

        public string Loai { get; set; }

        public string HangSanXuat { get; set; }

        public int NamSanXuat { get; set; }
        public int NamSuDung { get; set; }

        public string DvQuanLy { get; set; }
        public string DvSoHuu { get; set; }

        public string TrangThai { get; set; }

        public string KhuVuc { get; set; }
    }
}
