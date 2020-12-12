using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using PrismApp2.Persistence.Data;
//using PrismApp2.Persistence.LookupData;

using VNC;

using VNC.Core.DomainServices;

namespace PrismApp2.DomainServices
{
    public class CatLookupDataService : ICatLookupDataService
    {
        private Func<PrismApp2DbContext> _contextCreator;

        public CatLookupDataService(Func<PrismApp2DbContext> context)
        {
            Int64 startTicks = Log.CONSTRUCTOR(String.Format("Enter"), Common.LOG_APPNAME);

            _contextCreator = context;

            Log.CONSTRUCTOR(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public async Task<IEnumerable<LookupItem>> GetCatLookupAsync()
        {
            Int64 startTicks = Log.DOMAINSERVICES(String.Format("Enter"), Common.LOG_APPNAME);

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

            Log.DOMAINSERVICES(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }
    }
}
