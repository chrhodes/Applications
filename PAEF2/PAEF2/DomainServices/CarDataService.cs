using System;
using System.Data.Entity;
using System.Threading.Tasks;

using PAEF2.Domain;
using PAEF2.Persistence.Data;

using VNC;
using VNC.Core.DomainServices;

namespace PAEF2.DomainServices
{
    public class CarDataService : GenericEFRepository<Car, PAEF2DbContext>, ICarDataService
    {

        #region Constructors, Initialization, and Load

        public CarDataService(PAEF2DbContext context)
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

        public override async Task<Car> FindByIdAsync(int id)
        {
            Int64 startTicks = Log.DOMAINSERVICES("(CarDataService) Enter", Common.LOG_CATEGORY);

            var result = await Context.CarsSet
                .Include(f => f.PhoneNumbers)
                .SingleAsync(f => f.Id == id);

            Log.DOMAINSERVICES("(CarDataService) Exit", Common.LOG_CATEGORY, startTicks);

            return result;
        }

        public void RemovePhoneNumber(CarPhoneNumber model)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_CATEGORY);

            Context.CarPhoneNumbersSet.Remove(model);

            Log.DOMAINSERVICES("Exit", Common.LOG_CATEGORY, startTicks);
        }


        #endregion

        #region Protected Methods


        #endregion

        #region Private Methods


        #endregion

    }
}
