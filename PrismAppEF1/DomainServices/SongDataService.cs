using System;
using System.Data.Entity;
using System.Threading.Tasks;

using PrismAppEF1.Domain;
using PrismAppEF1.Persistence.Data;

using VNC;
using VNC.Core.DomainServices;

namespace PrismAppEF1.DomainServices
{
    public class SongDataService : GenericEFRepository<Song, PrismAppEF1DbContext>, ISongDataService
    {

        #region Constructors, Initialization, and Load

        public SongDataService(PrismAppEF1DbContext context)
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
            Int64 startTicks = Log.DOMAINSERVICES("(SongDataService) Enter", Common.LOG_APPNAME);

            var result = await Context.BirdsSet.AsNoTracking()
                .AnyAsync(f => f.FavoriteSongId == id);

            Log.DOMAINSERVICES("(SongDataService) Exit", Common.LOG_APPNAME, startTicks);

            return result;
        }

        #endregion

        #region Protected Methods


        #endregion

        #region Private Methods


        #endregion


    }
}
