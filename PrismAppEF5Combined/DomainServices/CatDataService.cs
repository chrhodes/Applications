using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

using PrismAppEF5.Domain;
using PrismAppEF5.Persistence.Data;

using VNC;
using VNC.Core.DomainServices;

namespace PrismAppEF5.DomainServices
{
    // NOTE(crhodes)
    // This creates a new context each time.  How would HasChanges work?

    public class CatDataService : ICatDataService
    {

        #region Constructors, Initialization, and Load

        public CatDataService(Func<PrismAppEF5DbContext> context)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            _contextCreator = context;

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion

        #region Enums


        #endregion

        #region Structures


        #endregion

        #region Fields and Properties

        private Func<PrismAppEF5DbContext> _contextCreator;

        private ConnectedRepository<Cat> _repository;

        #endregion

        #region Event Handlers


        #endregion

        #region Public Methods

        #region All

        public IEnumerable<Cat> All()
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);

                Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);

                return _repository.All();
            }
        }

        public async Task<List<Cat>> AllAsync()
        {
            Int64 startTicks = Log.DOMAINSERVICES("(CatDataService) Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);

                Log.DOMAINSERVICES("(CatDataService)Exit", Common.LOG_APPNAME, startTicks);

                return await _repository.AllAsync();
            }
        }

        public IEnumerable<Cat> AllInclude(
            params Expression<Func<Cat, object>>[] includeProperties)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);

                Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);

                return _repository.AllInclude(includeProperties);
            }
        }

        public async Task<IEnumerable<Cat>> AllIncludeAsync(
            params Expression<Func<Cat, object>>[] includeProperties)
        {
            Int64 startTicks = Log.DOMAINSERVICES("(CatDataService) Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);

                Log.DOMAINSERVICES("(CatDataService) Exit", Common.LOG_APPNAME, startTicks);

                return await _repository.AllIncludeAsync(includeProperties);
            }
        }

        #endregion All

        #region Find

        public Cat FindById(int entityId)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);

                Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);

                return _repository.FindById(entityId);
            }
        }

        public async Task<Cat> FindByIdAsync(int entityId)
        {
            Int64 startTicks = Log.DOMAINSERVICES($"((CatDataService)) Enter entityId:({entityId})", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);

                Log.DOMAINSERVICES("(CatDataService) Exit", Common.LOG_APPNAME, startTicks);

                return await _repository.FindByIdAsync(entityId);
            }
        }

        public IEnumerable<Cat> FindBy(
            Expression<Func<Cat, bool>> predicate)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);

                Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);

                return _repository.FindBy(predicate);
            }
        }

        public async Task<IEnumerable<Cat>> FindByAsync(
            Expression<Func<Cat, bool>> predicate)
        {
            Int64 startTicks = Log.DOMAINSERVICES("(CatDataService) Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);

                Log.DOMAINSERVICES("(CatDataService) Exit", Common.LOG_APPNAME, startTicks);

                return await _repository.FindByAsync(predicate);
            }
        }

        public IEnumerable<Cat> FindByInclude(
            Expression<Func<Cat, bool>> predicate,
            params Expression<Func<Cat, object>>[] includeProperties)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);

                Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);

                return _repository.FindByInclude(predicate, includeProperties);
            }
        }

        public async Task<IEnumerable<Cat>> FindByIncludeAsync(
            Expression<Func<Cat, bool>> predicate,
            params Expression<Func<Cat, object>>[] includeProperties)
        {
            Int64 startTicks = Log.DOMAINSERVICES("(CatDataService) Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);

                Log.DOMAINSERVICES("(CatDataService) Exit", Common.LOG_APPNAME, startTicks);

                return await _repository.FindByIncludeAsync(predicate, includeProperties);
            }
        }

        // TODO(crhodes)
        // Decide if we need FindByKey

        #endregion Find

        #region Insert

        public void Insert(Cat entity)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);
                _repository.Insert(entity);
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public async Task InsertAsync(Cat entity)
        {
            Int64 startTicks = Log.DOMAINSERVICES("(CatDataService) Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);
                await _repository.InsertAsync(entity);
            }

            Log.DOMAINSERVICES("(CatDataService) Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion Insert

        #region Update

        public void Update(Cat entity)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);
                _repository.Update(entity);
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public async Task UpdateAsync()
        {
            Int64 startTicks = Log.DOMAINSERVICES("(CatDataService) Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);
                await _repository.UpdateAsync();
            }

            Log.DOMAINSERVICES("(CatDataService) Exit", Common.LOG_APPNAME, startTicks);
        }

        public async Task UpdateAsync(Cat entity)
        {
            Int64 startTicks = Log.DOMAINSERVICES("(CatDataService) Enter", Common.LOG_APPNAME);

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

            Log.DOMAINSERVICES("(CatDataService) Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion Update

        #region Delete

        public void Delete(int entityId)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);
                _repository.Delete(entityId);
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public async Task DeleteAsync(int entityId)
        {
            Int64 startTicks = Log.DOMAINSERVICES("(CatDataService) Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);
                await _repository.DeleteAsync(entityId);
            }

            Log.DOMAINSERVICES("(CatDataService) Exit", Common.LOG_APPNAME, startTicks);
        }

        public bool HasChanges()
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            // TODO(crhodes)
            // Hum.  How to determine if something has changed that can drive the UI logic.
            // This wont' work as we are creating a brand new context.

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Cat>(context);
                var result = _repository.HasChanges();

                Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);

                return result;
            }
        }

        #endregion Delete

        #endregion

        #region Protected Methods


        #endregion

        #region Private Methods


        #endregion


    }
}
