using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using PAEF1a.Persistence.Data;

using VNC;

using VNC.Core.DomainServices;

namespace PAEF1a.DomainServices
{
    public class ToyLookupDataService : IToyLookupDataService
    {

        #region Constructors, Initialization, and Load

        public ToyLookupDataService(Func<PAEF1aDbContext> context)
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

        private Func<PAEF1aDbContext> _contextCreator;

        #endregion

        #region Event Handlers


        #endregion

        #region Public Methods

        public async Task<IEnumerable<LookupItem>> GetToyLookupAsync()
        {
            Int64 startTicks = Log.DOMAINSERVICES("(ToyLookupDataService) Enter", Common.LOG_CATEGORY);

            IEnumerable<LookupItem> result;

            using (var ctx = _contextCreator())
            {
                result = await ctx.ToysSet.AsNoTracking()
                  .Select(f =>
                  new LookupItem
                  {
                      Id = f.Id,
                      DisplayMember = f.Name
                  })
                  .ToListAsync();
            }

            Log.DOMAINSERVICES("(ToyLookupDataService) Exit", Common.LOG_CATEGORY, startTicks);

            return result;
        }

        #endregion

        #region Protected Methods


        #endregion

        #region Private Methods


        #endregion

    }
}
