using System;
using System.Collections.Generic;

namespace Skynet.Portal.Assets.Data.Entities
{
    public static class ThucLucContextExtensions
    {
        public static void EnsureSeedDataForContext(this ThucLucContext context)
        {
            context.ThietBis.RemoveRange();
            context.SaveChanges();

            var thietBis = new List<ThietBi>()
            {
                new ThietBi()
                {
                    Id = new Guid("25320c5e-f58a-4b1f-b63a-8ee07a840bdf"),
                    MaThietBi = "50KT-00007",
                    MaMaximo = "50KT-00007",
                    Nhom = "Xe - Máy",
                    ChungLoai = "Xe tải/bán tải",
                    Loai = "Xe bán tải",
                    HangSanXuat = "Isuzu",
                    NamSanXuat = 2010,
                    NamSuDung = 2010,
                    DvQuanLy = "CP Tiếp vận Cát Lái",
                    DvQuanLyId = "TVCL",
                    DvSoHuu = "CP Tiếp vận Cát Lái",
                    DvSoHuuId = "TVCL",
                    TrangThai = "Đang hoạt động",
                    KhuVuc = "Cát Lái",
                    KhuVucId = "CLA",
                    BienSo = "50KT-00007",
                    SoDangKy = "076286",
                    SoKhung = "RLETFR85HA7100177",
                    SoMay = "HC 4472",
                    CapChatLuong = 2
                }
            };
        }
    }
}
