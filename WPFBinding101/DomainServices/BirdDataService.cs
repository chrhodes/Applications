using System;
using System.Data.Entity;
using System.Threading.Tasks;

using VNC;
using VNC.Core.DomainServices;

using WPFBinding101.Domain;
using WPFBinding101.Persistence.Data;

namespace WPFBinding101.DomainServices
{
    public class BirdDataService : GenericEFRepository<Bird, WPFBinding101DbContext>, IBirdDataService
    {

        #region Constructors, Initialization, and Load

        public BirdDataService(WPFBinding101DbContext context)
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

        public override async Task<Bird> FindByIdAsync(int id)
        {
            Int64 startTicks = Log.DOMAINSERVICES("(BirdDataService) Enter", Common.LOG_APPNAME);

            var result = await Context.BirdsSet
                .Include(f => f.PhoneNumbers)
                .SingleAsync(f => f.Id == id);

            Log.DOMAINSERVICES("(BirdDataService) Exit", Common.LOG_APPNAME, startTicks);

            return result;
        }

        public void RemovePhoneNumber(BirdPhoneNumber model)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            Context.BirdPhoneNumbersSet.Remove(model);

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }


        #endregion

        #region Protected Methods


        #endregion

        #region Private Methods


        #endregion

    }
}
