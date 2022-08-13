using System;
using System.Data.Entity;
using System.Threading.Tasks;

using PAEF2.Domain;
using PAEF2.Persistence.Data;

using VNC;
using VNC.Core.DomainServices;

namespace PAEF2.DomainServices
{
    public class DoorDataService : GenericEFRepository<Door, PAEF2DbContext>, IDoorDataService
    {

        #region Constructors, Initialization, and Load

        public DoorDataService(PAEF2DbContext context)
            : base(context)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
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

        public async Task<bool> IsReferencedByCarAsync(int id)
        {
            Int64 startTicks = Log.DOMAINSERVICES("(DoorDataService) Enter", Common.LOG_CATEGORY);

            var result = await Context.CarsSet.AsNoTracking()
                .AnyAsync(f => f.FavoriteDoorId == id);

            Log.DOMAINSERVICES("(DoorDataService) Exit", Common.LOG_CATEGORY, startTicks);

            return result;
        }

        #endregion

        #region Protected Methods


        #endregion

        #region Private Methods


        #endregion


    }
}
