using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

using PAEF2.Domain;

using VNC;
using VNC.Core.DomainServices;

namespace PAEF2.DomainServices
{
    public class CarDataServiceMock : ICarDataService
    {
        public IEnumerable<Car> All()
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_CATEGORY);

            // TODO(crhodes)
            // Load data from real database.
            // For now just return hard coded list.

            yield return new Car
            {
                Id = 1,
                FieldString = "FieldString",
                FieldDouble = 2.0,
                FieldInt = 23

            };

            yield return new Car
            {
                Id = 2,
                FieldString = null,
                FieldDouble = Double.MaxValue,
                FieldInt = int.MaxValue
            };

            Log.DOMAINSERVICES("Exit", Common.LOG_CATEGORY, startTicks);
        }

        public Task<List<Car>> AllAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Car> AllInclude(params Expression<Func<Car, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Car>> AllIncludeAsync(params Expression<Func<Car, object>>[] includeProperties)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_CATEGORY);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_CATEGORY, startTicks);
        }

        public IEnumerable<Car> FindBy(Expression<Func<Car, bool>> predicate)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_CATEGORY);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_CATEGORY, startTicks);
        }

        public Task<IEnumerable<Car>> FindByAsync(Expression<Func<Car, bool>> predicate)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_CATEGORY);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_CATEGORY, startTicks);
        }

        public Car FindById(int entityId)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_CATEGORY);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_CATEGORY, startTicks);
        }

        public Task<Car> FindByIdAsync(int entityId)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_CATEGORY);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_CATEGORY, startTicks);
        }

        public IEnumerable<Car> FindByInclude(Expression<Func<Car, bool>> predicate, params Expression<Func<Car, object>>[] includeProperties)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_CATEGORY);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_CATEGORY, startTicks);
        }

        public Task<IEnumerable<Car>> FindByIncludeAsync(Expression<Func<Car, bool>> predicate, params Expression<Func<Car, object>>[] includeProperties)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_CATEGORY);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_CATEGORY, startTicks);
        }

        public bool HasChanges()
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_CATEGORY);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_CATEGORY, startTicks);
        }

        public void Add(Car entity)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_CATEGORY);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_CATEGORY, startTicks);
        }

        public void Remove(Car entity)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_CATEGORY);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_CATEGORY, startTicks);
        }

        public void RemovePhoneNumber(CarPhoneNumber model)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_CATEGORY);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_CATEGORY, startTicks);
        }

        public void Update()
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_CATEGORY);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_CATEGORY, startTicks);
        }

        public Task<Car> UpdateAsync(Car entity)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_CATEGORY);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_CATEGORY, startTicks);
        }

        public Task UpdateAsync()
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_CATEGORY);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_CATEGORY, startTicks);
        }
    }
}
