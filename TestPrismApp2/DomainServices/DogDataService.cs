using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

using TestPrismApp2.Domain;
using TestPrismApp2.Persistence.Data;

using VNC;
using VNC.Core.DomainServices;

namespace TestPrismApp2.DomainServices
{
    // TODO(crhodes)
    // Think we are almost to making this Generic.  But then what is difference 
    // between this and Generic Repository in VNC.Core.
    // Carefully trace through the code path.


    // NOTE(crhodes)
    // This creates a new context each time.  How would HasChanges work?

    public class DogDataService : IDogDataService
    {
        private Func<TestPrismApp2DbContext> _contextCreator;

        private ConnectedRepository<Dog> _repository;

        #region Constructors

        public DogDataService(Func<TestPrismApp2DbContext> context)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            _contextCreator = context;

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        #endregion Constructors

        #region Public Methods

        #region All

        public IEnumerable<Dog> All()
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Dog>(context);
                return _repository.All();
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public async Task<List<Dog>> AllAsync()
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Dog>(context);
                return await _repository.AllAsync();
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public IEnumerable<Dog> AllInclude(
            params Expression<Func<Dog, object>>[] includeProperties)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Dog>(context);
                return _repository.AllInclude(includeProperties);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public async Task<IEnumerable<Dog>> AllIncludeAsync(
            params Expression<Func<Dog, object>>[] includeProperties)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Dog>(context);
                return await _repository.AllIncludeAsync(includeProperties);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        #endregion All

        #region Find

        public Dog FindById(int entityId)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Dog>(context);
                return _repository.FindById(entityId);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public async Task<Dog> FindByIdAsync(int entityId)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Dog>(context);
                return await _repository.FindByIdAsync(entityId);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public IEnumerable<Dog> FindBy(
            Expression<Func<Dog, bool>> predicate)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Dog>(context);
                return _repository.FindBy(predicate);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public async Task<IEnumerable<Dog>> FindByAsync(
            Expression<Func<Dog, bool>> predicate)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Dog>(context);
                return await _repository.FindByAsync(predicate);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public IEnumerable<Dog> FindByInclude(
            Expression<Func<Dog, bool>> predicate,
            params Expression<Func<Dog, object>>[] includeProperties)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Dog>(context);
                return _repository.FindByInclude(predicate, includeProperties);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public async Task<IEnumerable<Dog>> FindByIncludeAsync(
            Expression<Func<Dog, bool>> predicate,
            params Expression<Func<Dog, object>>[] includeProperties)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Dog>(context);
                return await _repository.FindByIncludeAsync(predicate, includeProperties);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        // TODO(crhodes)
        // Decide if we need FindByKey

        #endregion Find

        #region Insert

        public void Insert(Dog entity)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Dog>(context);
                _repository.Insert(entity);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public async Task InsertAsync(Dog entity)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Dog>(context);
                await _repository.InsertAsync(entity);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        #endregion Insert

        #region Update

        public void Update(Dog entity)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Dog>(context);
                _repository.Update(entity);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public async Task UpdateAsync()
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Dog>(context);
                await _repository.UpdateAsync();
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public async Task UpdateAsync(Dog entity)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Dog>(context);

                if (entity.Id <= 0)
                {
                    await _repository.InsertAsync(entity);
                }
                else
                {
                    await _repository.UpdateAsync(entity);
                }
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        #endregion Update

        #region Delete

        public void Delete(int entityId)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Dog>(context);
                _repository.Delete(entityId);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public async Task DeleteAsync(int entityId)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Dog>(context);
                await _repository.DeleteAsync(entityId);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public bool HasChanges()
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            // TODO(crhodes)
            // Hum.  How to determine if something has changed that can drive the UI logic.
            // This wont' work as we are creating a brand new context.

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Dog>(context);
                var result = _repository.HasChanges();
                return result;
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);

        }

        #endregion Delete

        #endregion

    }
}
