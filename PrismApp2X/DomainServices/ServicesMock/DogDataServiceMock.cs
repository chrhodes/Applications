using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

using PrismApp2.Domain;

using VNC;
using VNC.Core.DomainServices;

namespace PrismApp2.DomainServices
{
    public class DogDataServiceMock : IDogDataService
    {
        public IEnumerable<Dog> All()
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            // TODO(crhodes)
            // Load data from real database.
            // For now just return hard coded list.

            yield return new Dog
            {
                Id = 1,
                FieldString = "FieldString",
                FieldDouble = 2.0,
                FieldInt = 23

            };

            yield return new Dog
            {
                Id = 2,
                FieldString = null,
                FieldDouble = Double.MaxValue,
                FieldInt = int.MaxValue
            };

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public Task<List<Dog>> AllAsync()
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public IEnumerable<Dog> AllInclude(params Expression<Func<Dog, object>>[] includeProperties)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public Task<IEnumerable<Dog>> AllIncludeAsync(params Expression<Func<Dog, object>>[] includeProperties)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public void Delete(int entityId)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public void DeleteAsync(int entityId)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public IEnumerable<Dog> FindBy(Expression<Func<Dog, bool>> predicate)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public Task<IEnumerable<Dog>> FindByAsync(Expression<Func<Dog, bool>> predicate)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public Dog FindById(int entityId)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public Task<Dog> FindByIdAsync(int entityId)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public IEnumerable<Dog> FindByInclude(Expression<Func<Dog, bool>> predicate, params Expression<Func<Dog, object>>[] includeProperties)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public Task<IEnumerable<Dog>> FindByIncludeAsync(Expression<Func<Dog, bool>> predicate, params Expression<Func<Dog, object>>[] includeProperties)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public bool HasChanges()
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public void Insert(Dog entity)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public Task<Dog> InsertAsync(Dog entity)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public void Update(Dog entity)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public Task<Dog> UpdateAsync(Dog entity)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public Task UpdateAsync()
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        Task IDataService<Dog>.DeleteAsync(int entityId)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        Task IDataService<Dog>.InsertAsync(Dog entity)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        Task IDataService<Dog>.UpdateAsync(Dog entity)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }
    }
}
