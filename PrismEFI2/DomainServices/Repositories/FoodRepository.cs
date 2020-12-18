using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PrismEFI2.Domain;
using PrismEFI2.DomainServices.Interfaces;

using VNC;
using VNC.Core.DomainServices;

namespace PrismEFI2.DomainServices.Repositories
{
    public class FoodRepository : ConnectedRepository<Food>, IFoodRepository
    {

        public FoodRepository(DbContext context) : base(context)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            //_contextCreator = context;

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

        public Food FindByKey(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsReferencedByDogAsync(int foodId)
        {
            throw new NotImplementedException();
        }
    }
}
