using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

using VNC;
using VNC.Core.DomainServices;

using WPFBinding101.Domain;

namespace WPFBinding101.DomainServices
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
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public IEnumerable<Bird> FindBy(Expression<Func<Bird, bool>> predicate)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public Task<IEnumerable<Bird>> FindByAsync(Expression<Func<Bird, bool>> predicate)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public Bird FindById(int entityId)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public Task<Bird> FindByIdAsync(int entityId)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public IEnumerable<Bird> FindByInclude(Expression<Func<Bird, bool>> predicate, params Expression<Func<Bird, object>>[] includeProperties)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public Task<IEnumerable<Bird>> FindByIncludeAsync(Expression<Func<Bird, bool>> predicate, params Expression<Func<Bird, object>>[] includeProperties)
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

        public void Add(Bird entity)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public void Remove(Bird entity)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public void RemovePhoneNumber(BirdPhoneNumber model)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public void Update()
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            throw new NotImplementedException();

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public Task<Bird> UpdateAsync(Bird entity)
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
    }
}
