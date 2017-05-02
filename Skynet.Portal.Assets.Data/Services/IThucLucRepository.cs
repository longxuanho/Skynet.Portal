using Skynet.Portal.Assets.Data.Entities;
using System;
using System.Collections.Generic;

namespace Skynet.Portal.Assets.Data.Services
{
    public interface IThucLucRepository
    {
        IEnumerable<ThietBi> GetThietBis();
        ThietBi GetThietBi(Guid thietBiId);
        void AddThietBi(ThietBi thietBi);
        void DeleteThietBi(ThietBi thietBi);
        void UpdateThietBi(ThietBi thietBi);
        bool Save();
    }
}
