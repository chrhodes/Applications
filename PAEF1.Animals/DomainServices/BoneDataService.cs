using System;
using System.Data.Entity;
using System.Threading.Tasks;

using PAEF1.Animals.Domain;
using PAEF1.Animals.Persistence.Data;

using VNC;
using VNC.Core.DomainServices;

namespace PAEF1.Animals.DomainServices
{
    public class BoneDataService : GenericEFRepository<Bone, PAEF1DbContext>, IBoneDataService
    {

        #region Constructors, Initialization, and Load

        public BoneDataService(PAEF1DbContext context)
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

        public async Task<bool> IsReferencedByDogAsync(int id)
        {
            Int64 startTicks = Log.DOMAINSERVICES("(BoneDataService) Enter", Common.LOG_APPNAME);

            var result = await Context.DogsSet.AsNoTracking()
                .AnyAsync(f => f.FavoriteBoneId == id);

            Log.DOMAINSERVICES("(BoneDataService) Exit", Common.LOG_APPNAME, startTicks);

            return result;
        }

        #endregion

        #region Protected Methods


        #endregion

        #region Private Methods


        #endregion


    }
}
