using System;
using System.Data.Entity;
using System.Threading.Tasks;

using PAEF1.Domain;
using PAEF1.Persistence.Data;

using VNC;
using VNC.Core.DomainServices;

namespace PAEF1.DomainServices
{
    public class ToyDataService : GenericEFRepository<Toy, PAEF1DbContext>, IToyDataService
    {

        #region Constructors, Initialization, and Load

        public ToyDataService(PAEF1DbContext context)
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

        public async Task<bool> IsReferencedByCatAsync(int id)
        {
            Int64 startTicks = Log.DOMAINSERVICES("(ToyDataService) Enter", Common.LOG_APPNAME);

            var result = await Context.CatsSet.AsNoTracking()
                .AnyAsync(f => f.FavoriteToyId == id);

            Log.DOMAINSERVICES("(ToyDataService) Exit", Common.LOG_APPNAME, startTicks);

            return result;
        }

        #endregion

        #region Protected Methods


        #endregion

        #region Private Methods


        #endregion


    }
}
