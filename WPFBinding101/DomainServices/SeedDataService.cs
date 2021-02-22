using System;
using System.Data.Entity;
using System.Threading.Tasks;

using VNC;
using VNC.Core.DomainServices;

using WPFBinding101.Domain;
using WPFBinding101.Persistence.Data;

namespace WPFBinding101.DomainServices
{
    public class SeedDataService : GenericEFRepository<Seed, WPFBinding101DbContext>, ISeedDataService
    {

        #region Constructors, Initialization, and Load

        public SeedDataService(WPFBinding101DbContext context)
            : base(context)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion

        #region Enums


        #endregion

        #region Structures


        #endregion

        #region Fields and Properties


        #endregion

        #region Event Handlers


        #endregion

        #region Public Methods

        public async Task<bool> IsReferencedByBirdAsync(int id)
        {
            Int64 startTicks = Log.DOMAINSERVICES("(SeedDataService) Enter", Common.LOG_APPNAME);

            var result = await Context.BirdsSet.AsNoTracking()
                .AnyAsync(f => f.FavoriteSeedId == id);

            Log.DOMAINSERVICES("(SeedDataService) Exit", Common.LOG_APPNAME, startTicks);

            return result;
        }

        #endregion

        #region Protected Methods


        #endregion

        #region Private Methods


        #endregion


    }
}
