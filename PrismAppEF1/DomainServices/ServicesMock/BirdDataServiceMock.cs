using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

using PrismAppEF1.Domain;

using VNC;
using VNC.Core.DomainServices;

namespace PrismAppEF1.DomainServices
{
    public class BirdDataServiceMock : IBirdDataService
    {
        public IEnumerable<Bird> All()
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            // TODO(crhodes)
            // Load data from real database.
            // For now just return hard coded list.

            yield return new Bird
            {
                Id = 1,
                FieldString = "FieldString",
                FieldDouble = 2.0,
                FieldInt = 23

            };

            yield return new Bird
            {
                Id = 2,
                FieldString = null,
                FieldDouble = Double.MaxValue,
                FieldInt = int.MaxValue
            };

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public Task<List<Bird>> AllAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bird> AllInclude(params Expression<Func<Bird, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Bird>> AllIncludeAsync(params Expression<Func<Bird, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bird> FindBy(Expression<Func<Bird, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Bird>> FindByAsync(Expression<Func<Bird, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Bird FindById(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Bird> FindByIdAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bird> FindByInclude(Expression<Func<Bird, bool>> predicate, params Expression<Func<Bird, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Bird>> FindByIncludeAsync(Expression<Func<Bird, bool>> predicate, params Expression<Func<Bird, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public bool HasChanges()
        {
            throw new NotImplementedException();
        }

        public void Add(Bird entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Bird entity)
        {
            throw new NotImplementedException();
        }

        public void RemovePhoneNumber(BirdPhoneNumber model)
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
