using System;
using System.Collections.Generic;

namespace Skynet.Portal.Assets.Data.Entities
{
    public static class ThucLucContextExtensions
    {
        public static void EnsureSeedDataForContext(this ThucLucContext context)
        {
            context.ThietBis.RemoveRange(context.ThietBis);
            context.SaveChanges();

            var thietBis = new List<ThietBi>()
            {
                new ThietBi()
                {
                    Id = new Guid(),
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
                },
                new ThietBi()
                {
                    Id = new Guid(),
                    MaThietBi = "50Z-0002",
                    MaMaximo = "50Z-0002",
                    Nhom = "Xe - Máy",
                    ChungLoai = "Xe tải/bán tải",
                    Loai = "Xe bán tải",
                    HangSanXuat = "Mitsubishi",
                    ModelThietBi = "Pajero",
                    NamSanXuat = 2010,
                    NamSuDung = 2010,
                    DvQuanLy = "TNHH MTV Xây dựng công trình TC",
                    DvQuanLyId = "XDCT",
                    DvSoHuu = "TNHH MTV Xây dựng công trình TC",
                    DvSoHuuId = "XDCT",
                    TrangThai = "Đang hoạt động",
                    KhuVuc = "Cát Lái",
                    KhuVucId = "CLA",
                    BienSo = "50Z-0002",
                    SoDangKy = "0029846",
                    SoKhung = "33V61000207",
                    SoMay = "6G72-SN8548",
                    CapChatLuong = 2
                }
            };

            context.ThietBis.AddRange(thietBis);
            context.SaveChanges();
        }
    }
}
