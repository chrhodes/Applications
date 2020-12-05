using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using PrismApp1.Persistence.Data;
using PrismApp1.Domain;

using VNC.Core.Domain;

namespace PrismApp1.DomainServices
{
    public class CatLookupDataService : ICatLookupDataService
    {
        private Func<PrismApp1DbContext> _contextCreator;

        public CatLookupDataService(Func<PrismApp1DbContext> context)
        {
            _contextCreator = context;
        }

        public async Task<IEnumerable<LookupItem>> GetCatLookupAsync()
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.CatSet.AsNoTracking()
                  .Select(f =>
                  new LookupItem
                  {
                      Id = f.Id,
                      DisplayMember = f.FieldString
                  })
                  .ToListAsync();
            }
        }
    }
}
