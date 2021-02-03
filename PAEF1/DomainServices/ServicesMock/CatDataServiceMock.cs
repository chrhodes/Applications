using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

using PAEF1.Domain;

using VNC;
using VNC.Core.DomainServices;

namespace PAEF1.DomainServices
{
    public class CatDataServiceMock : ICatDataService
    {
        public IEnumerable<Cat> All()
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            // TODO(crhodes)
            // Load data from real database.
            // For now just return hard coded list.

            yield return new Cat
            {
                Id = 1,
                FieldString = "FieldString",
                FieldDouble = 2.0,
                FieldInt = 23

            };

            yield return new Cat
            {
                Id = 2,
                FieldString = null,
                FieldDouble = Double.MaxValue,
                FieldInt = int.MaxValue
            };

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public Task<List<Cat>> AllAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cat> AllInclude(params Expression<Func<Cat, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cat>> AllIncludeAsync(params Expression<Func<Cat, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cat> FindBy(Expression<Func<Cat, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cat>> FindByAsync(Expression<Func<Cat, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Cat FindById(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Cat> FindByIdAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cat> FindByInclude(Expression<Func<Cat, bool>> predicate, params Expression<Func<Cat, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cat>> FindByIncludeAsync(Expression<Func<Cat, bool>> predicate, params Expression<Func<Cat, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public bool HasChanges()
        {
            throw new NotImplementedException();
        }

        public void Add(Cat entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Cat entity)
        {
            throw new NotImplementedException();
        }

        public void RemovePhoneNumber(CatPhoneNumber model)
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
