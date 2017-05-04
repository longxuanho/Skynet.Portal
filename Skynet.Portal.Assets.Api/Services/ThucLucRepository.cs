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
                .OrderBy(a => a.MaThietBi);

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
