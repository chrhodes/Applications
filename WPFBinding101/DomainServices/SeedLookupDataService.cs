using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using VNC;
using VNC.Core.DomainServices;

using WPFBinding101.Persistence.Data;

namespace WPFBinding101.DomainServices
{
    public class SeedLookupDataService : ISeedLookupDataService
    {

        #region Constructors, Initialization, and Load

        public SeedLookupDataService(Func<WPFBinding101DbContext> context)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            _contextCreator = context;

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion

        #region Enums


        #endregion

        #region Structures


        #endregion

        #region Fields and Properties

        private Func<WPFBinding101DbContext> _contextCreator;

        #endregion

        #region Event Handlers


        #endregion

        #region Public Methods

        public async Task<IEnumerable<LookupItem>> GetSeedLookupAsync()
        {
            Int64 startTicks = Log.DOMAINSERVICES("(SeedLookupDataService) Enter", Common.LOG_APPNAME);

            IEnumerable<LookupItem> result;

            using (var ctx = _contextCreator())
            {
                result = await ctx.SeedsSet.AsNoTracking()
                  .Select(f =>
                  new LookupItem
                  {
                      Id = f.Id,
                      DisplayMember = f.Name
                  })
                  .ToListAsync();
            }

            Log.DOMAINSERVICES("(SeedLookupDataService) Exit", Common.LOG_APPNAME, startTicks);

            return result;
        }

        #endregion

        #region Protected Methods


        #endregion

        #region Private Methods


        #endregion

    }
}
