using System;
using System.Data.Entity;
using System.Threading.Tasks;

using PAI1.Domain;
using PAI1.Persistence.Data;

using VNC;
using VNC.Core.DomainServices;

namespace PAI1.DomainServices
{
    public class FoodDataService : GenericEFRepository<Food, PAI1DbContext>, IFoodDataService
    {

        #region Constructors, Initialization, and Load

        public FoodDataService(PAI1DbContext context)
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
            Int64 startTicks = Log.DOMAINSERVICES("(FoodDataService) Enter", Common.LOG_APPNAME);

            var result = await Context.DogsSet.AsNoTracking()
                .AnyAsync(f => f.FavoriteFoodId == id);

            Log.DOMAINSERVICES("(FoodDataService) Exit", Common.LOG_APPNAME, startTicks);

            return result;
        }

        #endregion

        #region Protected Methods


        #endregion

        #region Private Methods


        #endregion


    }
}
