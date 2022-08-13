using System;
using System.Data.Entity;
using System.Threading.Tasks;

using PAEF3.Domain;
using PAEF3.Persistence.Data;

using VNC;
using VNC.Core.DomainServices;

namespace PAEF3.DomainServices
{
    public class CatDataService : GenericEFRepository<Cat, PAEF3DbContext>, ICatDataService
    {

        #region Constructors, Initialization, and Load

        public CatDataService(PAEF3DbContext context)
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

        public override async Task<Cat> FindByIdAsync(int id)
        {
            Int64 startTicks = Log.DOMAINSERVICES("(CatDataService) Enter", Common.LOG_CATEGORY);

            var result = await Context.CatsSet
                .Include(f => f.PhoneNumbers)
                .SingleAsync(f => f.Id == id);

            Log.DOMAINSERVICES("(CatDataService) Exit", Common.LOG_CATEGORY, startTicks);

            return result;
        }

        public void RemovePhoneNumber(CatPhoneNumber model)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_CATEGORY);

            Context.CatPhoneNumbersSet.Remove(model);

            Log.DOMAINSERVICES("Exit", Common.LOG_CATEGORY, startTicks);
        }


        #endregion

        #region Protected Methods


        #endregion

        #region Private Methods


        #endregion

    }
}
