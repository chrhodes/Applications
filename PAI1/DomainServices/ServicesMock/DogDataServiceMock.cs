using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

using PAI1.Domain;

using VNC;
using VNC.Core.DomainServices;

namespace PAI1.DomainServices
{
    public class DogDataServiceMock : IDogDataService
    {
        public void Add(Dog entity)
        {
            throw new NotImplementedException();
        }

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
            throw new NotImplementedException();
        }

        public IEnumerable<Dog> AllInclude(params Expression<Func<Dog, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Dog>> AllIncludeAsync(params Expression<Func<Dog, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dog> FindBy(Expression<Func<Dog, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Dog>> FindByAsync(Expression<Func<Dog, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Dog FindById(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Dog> FindByIdAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dog> FindByInclude(Expression<Func<Dog, bool>> predicate, params Expression<Func<Dog, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Dog>> FindByIncludeAsync(Expression<Func<Dog, bool>> predicate, params Expression<Func<Dog, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public bool HasChanges()
        {
            throw new NotImplementedException();
        }

        public void Remove(Dog entity)
        {
            throw new NotImplementedException();
        }

        public void RemovePhoneNumber(DogPhoneNumber model)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
