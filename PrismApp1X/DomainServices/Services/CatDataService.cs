using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

using PrismApp1.Persistence.Data;
using PrismApp1.Domain;

using VNC.Core.DomainServices;
using VNC;

namespace PrismApp1.DomainServices
{
    // TODO(crhodes)
    // Think we are almost to making this Generic.  But then what is difference 
    // between this and Generic Repository in VNC.Core.
    // Carefully trace through the code path.

    public class CatDataService : ICatDataService
    {
        private Func<PrismApp1DbContext> _contextCreator;

        private ConnectedRepository<Cat> _repository;

        #region Constructors

        public CatDataService(Func<PrismApp1DbContext> context)
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            _contextCreator = context;

            Log.Trace($"Exit", Common.PROJECT_NAME, startTicks);
        }

        #endregion Constructors

        #region Public Methods

        #region All

        public IEnumerable<Cat> All()
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);

                Log.Trace($"Exit", Common.PROJECT_NAME, startTicks);

                return _repository.All();
            }
        }

        public async Task<List<Cat>> AllAsync()
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);

                Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);

                return await _repository.AllAsync();
            }
        }

        public IEnumerable<Cat> AllInclude(
            params Expression<Func<Cat, object>>[] includeProperties)
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);

                Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);

                return _repository.AllInclude(includeProperties);
            }
        }

        public async Task<IEnumerable<Cat>> AllIncludeAsync(
            params Expression<Func<Cat, object>>[] includeProperties)
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);

                Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);

                return await _repository.AllIncludeAsync(includeProperties);
            }
        }

        #endregion All

        #region Find

        public Cat FindById(int entityId)
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);

                Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);

                return _repository.FindById(entityId);
            }
        }

        public async Task<Cat> FindByIdAsync(int entityId)
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);

                Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);

                return await _repository.FindByIdAsync(entityId);
            }
        }

        public IEnumerable<Cat> FindBy(
            Expression<Func<Cat, bool>> predicate)
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);

                Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);

                return _repository.FindBy(predicate);
            }
        }

        public async Task<IEnumerable<Cat>> FindByAsync(
            Expression<Func<Cat, bool>> predicate)
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);

                Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);

                return await _repository.FindByAsync(predicate);
            }
        }

        public IEnumerable<Cat> FindByInclude(
            Expression<Func<Cat, bool>> predicate,
            params Expression<Func<Cat, object>>[] includeProperties)
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);

                Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);

                return _repository.FindByInclude(predicate, includeProperties);
            }
        }

        public async Task<IEnumerable<Cat>> FindByIncludeAsync(
            Expression<Func<Cat, bool>> predicate,
            params Expression<Func<Cat, object>>[] includeProperties)
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);

                Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);

                return await _repository.FindByIncludeAsync(predicate, includeProperties);
            }
        }

        // TODO(crhodes)
        // Decide if we need FindByKey

        #endregion Find

        #region Insert

        public void Insert(Cat entity)
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);
                _repository.Insert(entity);
            }

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }

        public async Task InsertAsync(Cat entity)
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);
                await _repository.InsertAsync(entity);
            }

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion Insert

        #region Update

        public void Update(Cat entity)
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);
                _repository.Update(entity);
            }

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }

        public async Task UpdateAsync(Cat entity)
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);
                await _repository.UpdateAsync(entity);
            }

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion Update

        #region Delete

        public void Delete(int entityId)
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);
                _repository.Delete(entityId);
            }

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }

        public async Task DeleteAsync(int entityId)
        {
            long startTicks = Log.Trace($"Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);
                await _repository.DeleteAsync(entityId);
            }

            Log.Trace($"Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion Delete

        #endregion

    }
}
