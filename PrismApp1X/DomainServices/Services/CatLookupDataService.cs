using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using PrismApp1.Persistence.Data;

using VNC.Core.DomainServices;
using VNC;

namespace PrismApp1.DomainServices
{
    public class CatLookupDataService : ICatLookupDataService
    {
        private Func<PrismApp1DbContext> _contextCreator;

        public CatLookupDataService(Func<PrismApp1DbContext> context)
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            _contextCreator = context;

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }

        public async Task<IEnumerable<LookupItem>> GetCatsLookupAsync()
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            using (var ctx = _contextCreator())
            {
                Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);

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
