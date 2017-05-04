namespace Skynet.Portal.Assets.Api.Helpers
{
    public class ThietBisResourceParameters
    {
        const int maxPageSize = 20;
        private int _pageSize = 10;

        public int PageNumber { get; set; } = 1;

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }

        public string Nhom { get; set; }
        public string ChungLoai { get; set; }
        public string Loai { get; set; }
        public string HangSanXuat { get; set; }
        public string KhuVuc { get; set; }
        public string DvQuanLy { get; set; }
        public string DvSoHuu { get; set; }
        public string Search { get; set; }
    }
}
