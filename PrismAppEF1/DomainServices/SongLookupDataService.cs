using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using PrismAppEF1.Persistence.Data;

using VNC;

using VNC.Core.DomainServices;

namespace PrismAppEF1.DomainServices
{
    public class SongLookupDataService : ISongLookupDataService
    {

        #region Constructors, Initialization, and Load

        public SongLookupDataService(Func<PrismAppEF1DbContext> context)
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

        private Func<PrismAppEF1DbContext> _contextCreator;

        #endregion

        #region Event Handlers


        #endregion

        #region Public Methods

        public async Task<IEnumerable<LookupItem>> GetSongLookupAsync()
        {
            Int64 startTicks = Log.DOMAINSERVICES("(SongLookupDataService) Enter", Common.LOG_APPNAME);

            IEnumerable<LookupItem> result;

            using (var ctx = _contextCreator())
            {
                result = await ctx.SongsSet.AsNoTracking()
                  .Select(f =>
                  new LookupItem
                  {
                      Id = f.Id,
                      DisplayMember = f.Name
                  })
                  .ToListAsync();
            }

            Log.DOMAINSERVICES("(SongLookupDataService) Exit", Common.LOG_APPNAME, startTicks);

            return result;
        }

        #endregion

        #region Protected Methods


        #endregion

        #region Private Methods


        #endregion

    }
}
