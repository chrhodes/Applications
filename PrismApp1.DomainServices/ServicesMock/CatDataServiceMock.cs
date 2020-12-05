
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

using PrismApp1.Domain;

using VNC.Core.Domain;

namespace PrismApp1.DomainServices
{
    public class CatDataServiceMock : ICatDataService
    {
        public IEnumerable<Cat> All()
        {
            //// TODO(crhodes)
            //// Load data from real database.
            //// For now just return hard coded list.
            ///
            yield return new Cat
            {
                Id = 1,
                FieldString = "FieldString",
                FieldDouble = 2.0,
                FieldInt = 23

            };
            yield return new Cat { Id = 2, FieldString = null, FieldDouble = Double.MaxValue, FieldInt = int.MaxValue };
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

        public void Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(int entityId)
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

        public void Insert(Cat entity)
        {
            throw new NotImplementedException();
        }

        public Task<Cat> InsertAsync(Cat entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Cat entity)
        {
            throw new NotImplementedException();
        }

        public Task<Cat> UpdateAsync(Cat entity)
        {
            throw new NotImplementedException();
        }

        Task IDataService<Cat>.DeleteAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        Task IDataService<Cat>.InsertAsync(Cat entity)
        {
            throw new NotImplementedException();
        }

        Task IDataService<Cat>.UpdateAsync(Cat entity)
        {
            throw new NotImplementedException();
        }
    }
}
