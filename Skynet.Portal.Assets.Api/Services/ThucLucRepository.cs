using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Skynet.Portal.Assets.Data.Entities;
using Skynet.Portal.Assets.Api.Helpers;

namespace Skynet.Portal.Assets.Api.Services
{
    public class ThucLucRepository : IThucLucRepository
    {
        private ThucLucContext _context;

        public ThucLucRepository(ThucLucContext context)
        {
            _context = context;
        }

        public void AddThietBi(ThietBi thietBi)
        {
            thietBi.Id = Guid.NewGuid();
            _context.ThietBis.Add(thietBi);
        }

        public void DeleteThietBi(ThietBi thietBi)
        {
            _context.ThietBis.Remove(thietBi);
        }

        public ThietBi GetThietBi(Guid thietBiId)
        {
            return _context.ThietBis.FirstOrDefault(a => a.Id == thietBiId);
        }

        public PagedList<ThietBi> GetThietBis(ThietBisResourceParameters thietBisResourceParameters)
        {
            var collectionBeforePaging = _context.ThietBis
                .OrderBy(a => a.MaThietBi)
                .AsQueryable();

            if (!string.IsNullOrEmpty(thietBisResourceParameters.Nhom))
            {
                var nhomForWhereClause = thietBisResourceParameters.Nhom.Trim().ToLowerInvariant();
                collectionBeforePaging = collectionBeforePaging.Where(a => a.Nhom.ToLowerInvariant() == nhomForWhereClause);
            }

            if (!string.IsNullOrEmpty(thietBisResourceParameters.ChungLoai))
            {
                var chungLoaiForWhereClause = thietBisResourceParameters.ChungLoai.Trim().ToLowerInvariant();
                collectionBeforePaging = collectionBeforePaging.Where(a => a.ChungLoai.ToLowerInvariant() == chungLoaiForWhereClause);
            }

            if (!string.IsNullOrEmpty(thietBisResourceParameters.Loai))
            {
                var loaiForWhereClause = thietBisResourceParameters.Loai.Trim().ToLowerInvariant();
                collectionBeforePaging = collectionBeforePaging.Where(a => a.Loai.ToLowerInvariant() == loaiForWhereClause);
            }

            if (!string.IsNullOrEmpty(thietBisResourceParameters.HangSanXuat))
            {
                var hangSanXuatForWhereClause = thietBisResourceParameters.HangSanXuat.Trim().ToLowerInvariant();
                collectionBeforePaging = collectionBeforePaging.Where(a => a.HangSanXuat.ToLowerInvariant() == hangSanXuatForWhereClause);
            }

            if (!string.IsNullOrEmpty(thietBisResourceParameters.KhuVuc))
            {
                var khuVucForWhereClause = thietBisResourceParameters.KhuVuc.Trim().ToLowerInvariant();
                collectionBeforePaging = collectionBeforePaging.Where(a => a.KhuVuc.ToLowerInvariant() == khuVucForWhereClause);
            }

            if (!string.IsNullOrEmpty(thietBisResourceParameters.DvQuanLy))
            {
                var dvQuanLyForWhereClause = thietBisResourceParameters.DvQuanLy.Trim().ToLowerInvariant();
                collectionBeforePaging = collectionBeforePaging.Where(a => a.DvQuanLy.ToLowerInvariant() == dvQuanLyForWhereClause);
            }

            if (!string.IsNullOrEmpty(thietBisResourceParameters.DvSoHuu))
            {
                var dvSoHuuForWhereClause = thietBisResourceParameters.DvSoHuu.Trim().ToLowerInvariant();
                collectionBeforePaging = collectionBeforePaging.Where(a => a.DvSoHuu.ToLowerInvariant() == dvSoHuuForWhereClause);
            }

            if (!string.IsNullOrEmpty(thietBisResourceParameters.Search))
            {
                var searchForWhereClause = thietBisResourceParameters.Search.Trim().ToLowerInvariant();
                collectionBeforePaging = collectionBeforePaging
                    .Where(a => a.MaThietBi.ToLowerInvariant().Contains(searchForWhereClause));
            }

            return PagedList<ThietBi>.Create(collectionBeforePaging, thietBisResourceParameters.PageNumber, thietBisResourceParameters.PageSize);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateThietBi(ThietBi thietBi)
        {
            // no code for implementation
        }
    }
}
