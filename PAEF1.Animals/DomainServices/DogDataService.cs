using System;
using System.Data.Entity;
using System.Threading.Tasks;

using PAEF1.Animals.Domain;
using PAEF1.Animals.Persistence.Data;

using VNC;
using VNC.Core.DomainServices;

namespace PAEF1.Animals.DomainServices
{
    public class DogDataService : GenericEFRepository<Dog, PAEF1DbContext>, IDogDataService
    {

        #region Constructors, Initialization, and Load

        public DogDataService(PAEF1DbContext context)
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

        public override async Task<Dog> FindByIdAsync(int id)
        {
            Int64 startTicks = Log.DOMAINSERVICES("(DogDataService) Enter", Common.LOG_APPNAME);

            var result = await Context.DogsSet
                .Include(f => f.PhoneNumbers)
                .SingleAsync(f => f.Id == id);

            Log.DOMAINSERVICES("(DogDataService) Exit", Common.LOG_APPNAME, startTicks);

            return result;
        }

        public void RemovePhoneNumber(DogPhoneNumber model)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            Context.DogPhoneNumbersSet.Remove(model);

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }


        #endregion

        #region Protected Methods


        #endregion

        #region Private Methods


        #endregion

    }
}
