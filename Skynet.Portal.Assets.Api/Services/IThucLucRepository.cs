using Skynet.Portal.Assets.Api.Helpers;
using Skynet.Portal.Assets.Data.Entities;
using System;
using System.Collections.Generic;

namespace Skynet.Portal.Assets.Api.Services
{
    public interface IThucLucRepository
    {
        PagedList<ThietBi> GetThietBis(ThietBisResourceParameters thietBisResourceParameters);
        ThietBi GetThietBi(Guid thietBiId);
        void AddThietBi(ThietBi thietBi);
        void DeleteThietBi(ThietBi thietBi);
        void UpdateThietBi(ThietBi thietBi);
        bool Save();
    }
}
