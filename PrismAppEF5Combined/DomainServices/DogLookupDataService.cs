using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using PrismAppEF5.Persistence.Data;

using VNC;

using VNC.Core.DomainServices;

namespace PrismAppEF5.DomainServices
{
    public class DogLookupDataService : IDogLookupDataService
    {

        #region Constructors, Initialization, and Load

        public DogLookupDataService(Func<PrismAppEF5DbContext> context)
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

        private Func<PrismAppEF5DbContext> _contextCreator;

        #endregion

        #region Event Handlers


        #endregion

        #region Public Methods

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

        #endregion

        #region Protected Methods


        #endregion

        #region Private Methods


        #endregion

    }
}
