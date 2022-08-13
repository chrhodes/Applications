using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using PAEF2.Persistence.Data;

using VNC;

using VNC.Core.DomainServices;

namespace PAEF2.DomainServices
{
    public class DoorLookupDataService : IDoorLookupDataService
    {

        #region Constructors, Initialization, and Load

        public DoorLookupDataService(Func<PAEF2DbContext> context)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            _contextCreator = context;

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Enums


        #endregion

        #region Structures


        #endregion

        #region Fields and Properties

        private Func<PAEF2DbContext> _contextCreator;

        #endregion

        #region Event Handlers


        #endregion

        #region Public Methods

        public async Task<IEnumerable<LookupItem>> GetDoorLookupAsync()
        {
            Int64 startTicks = Log.DOMAINSERVICES("(DoorLookupDataService) Enter", Common.LOG_CATEGORY);

            IEnumerable<LookupItem> result;

            using (var ctx = _contextCreator())
            {
                result = await ctx.DoorsSet.AsNoTracking()
                  .Select(f =>
                  new LookupItem
                  {
                      Id = f.Id,
                      DisplayMember = f.Name
                  })
                  .ToListAsync();
            }

            Log.DOMAINSERVICES("(DoorLookupDataService) Exit", Common.LOG_CATEGORY, startTicks);

            return result;
        }

        #endregion

        #region Protected Methods


        #endregion

        #region Private Methods


        #endregion

    }
}
