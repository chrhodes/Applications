using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using App3.Persistence.Data;

using VNC;

using VNC.Core.DomainServices;

namespace App3.DomainServices
{
    public class DogLookupDataService : IDogLookupDataService
    {
        private Func<App3DbContext> _contextCreator;

        public DogLookupDataService(Func<App3DbContext> context)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            _contextCreator = context;

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

        public async Task<IEnumerable<LookupItem>> GetDogLookupAsync()
        {
            Int64 startTicks = Log.DOMAINSERVICES("(DogLookupDataService) Enter", Common.LOG_APPNAME);

            IEnumerable<LookupItem> result;

            using (var ctx = _contextCreator())
            {
                result = await ctx.DogSet.AsNoTracking()
                  .Select(f =>
                  new LookupItem
                  {
                      Id = f.Id,
                      DisplayMember = f.FieldString
                  })
                  .ToListAsync();
            }

            Log.DOMAINSERVICES("(DogLookupDataService) Exit", Common.LOG_APPNAME, startTicks);

            return result;
        }
    }
}
