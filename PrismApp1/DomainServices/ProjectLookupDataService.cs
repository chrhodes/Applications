using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using PrismApp1.Persistence.Data;

using VNC;

using VNC.Core.DomainServices;

namespace PrismApp1.DomainServices
{
    public class ProjectLookupDataService : IProjectLookupDataService
    {
        private Func<PrismApp1DbContext> _contextCreator;

        public ProjectLookupDataService()
        {
        }

        public ProjectLookupDataService(Func<PrismApp1DbContext> context)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            _contextCreator = context;

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public async Task<IEnumerable<LookupItem>> GetProjectLookupAsync()
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var ctx = _contextCreator())
            {
                return await ctx.ProjectSet.AsNoTracking()
                  .Select(f =>
                  new LookupItem
                  {
                      Id = f.Id,
                      DisplayMember = f.FieldString
                  })
                  .ToListAsync();
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }
    }
}
