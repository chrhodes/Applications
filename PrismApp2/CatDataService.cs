using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;


using PrismApp2.Domain;
using PrismApp2.Persistence.Data;


using VNC;
using VNC.Core.DomainServices;

namespace PrismApp2.DomainServices
{
    // NOTE(crhodes)
    // This creates a new context each time.  How would HasChanges work?

    public class CatDataService : ICatDataService
    {
        private Func<PrismApp2DbContext> _contextCreator;

        private ConnectedRepository<Cat> _repository;

        #region Constructors

        public CatDataService(Func<PrismApp2DbContext> context)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            _contextCreator = context;

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        #endregion Constructors

        #region Public Methods

        #region All

        public IEnumerable<Cat> All()
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);
                return _repository.All();
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public async Task<List<Cat>> AllAsync()
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);
                return await _repository.AllAsync();
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public IEnumerable<Cat> AllInclude(
            params Expression<Func<Cat, object>>[] includeProperties)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);
                return _repository.AllInclude(includeProperties);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public async Task<IEnumerable<Cat>> AllIncludeAsync(
            params Expression<Func<Cat, object>>[] includeProperties)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);
                return await _repository.AllIncludeAsync(includeProperties);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        #endregion All

        #region Find

        public Cat FindById(int entityId)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);
                return _repository.FindById(entityId);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public async Task<Cat> FindByIdAsync(int entityId)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);
                return await _repository.FindByIdAsync(entityId);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public IEnumerable<Cat> FindBy(
            Expression<Func<Cat, bool>> predicate)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);
                return _repository.FindBy(predicate);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public async Task<IEnumerable<Cat>> FindByAsync(
            Expression<Func<Cat, bool>> predicate)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);
                return await _repository.FindByAsync(predicate);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public IEnumerable<Cat> FindByInclude(
            Expression<Func<Cat, bool>> predicate,
            params Expression<Func<Cat, object>>[] includeProperties)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);
                return _repository.FindByInclude(predicate, includeProperties);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public async Task<IEnumerable<Cat>> FindByIncludeAsync(
            Expression<Func<Cat, bool>> predicate,
            params Expression<Func<Cat, object>>[] includeProperties)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);
                return await _repository.FindByIncludeAsync(predicate, includeProperties);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        // TODO(crhodes)
        // Decide if we need FindByKey

        #endregion Find

        #region Insert

        public void Insert(Cat entity)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);
                _repository.Insert(entity);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public async Task InsertAsync(Cat entity)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);
                await _repository.InsertAsync(entity);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        #endregion Insert

        #region Update

        public void Update(Cat entity)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);
                _repository.Update(entity);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public async Task UpdateAsync()
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);
                await _repository.UpdateAsync();
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public async Task UpdateAsync(Cat entity)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);

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
                _repository = new ConnectedRepository<Cat>(context);
                _repository.Delete(entityId);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public async Task DeleteAsync(int entityId)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);
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
                _repository = new ConnectedRepository<Cat>(context);
                var result = _repository.HasChanges();
                return result;
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);

        }


        #endregion Delete

        #endregion

    }
}
