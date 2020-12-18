using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

using PrismEFI2.Domain;
using PrismEFI2.Persistence.Data;

using VNC;
using VNC.Core.DomainServices;

namespace PrismEFI2.DomainServices
{
    // NOTE(crhodes)
    // This creates a new context each time.  How would HasChanges work?

    public class FoodDataService : IFoodDataService
    {

        #region Constructors, Initialization, and Load

        public FoodDataService(Func<PrismEFI2DbContext> context)
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

        private Func<PrismEFI2DbContext> _contextCreator;

        private ConnectedRepository<Food> _repository;

        #endregion

        #region Event Handlers


        #endregion

        #region Public Methods

        #region All

        public IEnumerable<Food> All()
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Food>(context);

                Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);

                return _repository.All();
            }
        }

        public async Task<List<Food>> AllAsync()
        {
            Int64 startTicks = Log.DOMAINSERVICES("(FoodDataService) Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Food>(context);

                Log.DOMAINSERVICES("(FoodDataService)Exit", Common.LOG_APPNAME, startTicks);

                return await _repository.AllAsync();
            }
        }

        public IEnumerable<Food> AllInclude(
            params Expression<Func<Food, object>>[] includeProperties)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Food>(context);

                Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);

                return _repository.AllInclude(includeProperties);
            }
        }

        public async Task<IEnumerable<Food>> AllIncludeAsync(
            params Expression<Func<Food, object>>[] includeProperties)
        {
            Int64 startTicks = Log.DOMAINSERVICES("(FoodDataService) Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Food>(context);

                Log.DOMAINSERVICES("(FoodDataService) Exit", Common.LOG_APPNAME, startTicks);

                return await _repository.AllIncludeAsync(includeProperties);
            }
        }

        #endregion All

        #region Find

        public Food FindById(int entityId)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Food>(context);

                Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);

                return _repository.FindById(entityId);
            }
        }

        public async Task<Food> FindByIdAsync(int entityId)
        {
            Int64 startTicks = Log.DOMAINSERVICES($"((FoodDataService)) Enter entityId:({entityId})", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Food>(context);

                Log.DOMAINSERVICES("(FoodDataService) Exit", Common.LOG_APPNAME, startTicks);

                return await _repository.FindByIdAsync(entityId);
            }
        }

        public IEnumerable<Food> FindBy(
            Expression<Func<Food, bool>> predicate)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Food>(context);

                Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);

                return _repository.FindBy(predicate);
            }
        }

        public async Task<IEnumerable<Food>> FindByAsync(
            Expression<Func<Food, bool>> predicate)
        {
            Int64 startTicks = Log.DOMAINSERVICES("(FoodDataService) Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Food>(context);

                Log.DOMAINSERVICES("(FoodDataService) Exit", Common.LOG_APPNAME, startTicks);

                return await _repository.FindByAsync(predicate);
            }
        }

        public IEnumerable<Food> FindByInclude(
            Expression<Func<Food, bool>> predicate,
            params Expression<Func<Food, object>>[] includeProperties)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Food>(context);

                Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);

                return _repository.FindByInclude(predicate, includeProperties);
            }
        }

        public async Task<IEnumerable<Food>> FindByIncludeAsync(
            Expression<Func<Food, bool>> predicate,
            params Expression<Func<Food, object>>[] includeProperties)
        {
            Int64 startTicks = Log.DOMAINSERVICES("(FoodDataService) Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Food>(context);

                Log.DOMAINSERVICES("(FoodDataService) Exit", Common.LOG_APPNAME, startTicks);

                return await _repository.FindByIncludeAsync(predicate, includeProperties);
            }
        }

        // TODO(crhodes)
        // Decide if we need FindByKey

        #endregion Find

        #region Insert

        public void Insert(Food entity)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Food>(context);
                _repository.Insert(entity);
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public async Task InsertAsync(Food entity)
        {
            Int64 startTicks = Log.DOMAINSERVICES("(FoodDataService) Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Food>(context);
                await _repository.InsertAsync(entity);
            }

            Log.DOMAINSERVICES("(FoodDataService) Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion Insert

        #region Update

        public void Update(Food entity)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Food>(context);
                _repository.Update(entity);
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public async Task UpdateAsync()
        {
            Int64 startTicks = Log.DOMAINSERVICES("(FoodDataService) Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Food>(context);
                await _repository.UpdateAsync();
            }

            Log.DOMAINSERVICES("(FoodDataService) Exit", Common.LOG_APPNAME, startTicks);
        }

        public async Task UpdateAsync(Food entity)
        {
            Int64 startTicks = Log.DOMAINSERVICES("(FoodDataService) Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Food>(context);

                if (entity.Id <= 0)
                {
                    await _repository.InsertAsync(entity);
                }
                else
                {
                    await _repository.UpdateAsync(entity);
                }
            }

            Log.DOMAINSERVICES("(FoodDataService) Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion Update

        #region Delete

        public void Delete(int entityId)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Food>(context);
                _repository.Delete(entityId);
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public async Task DeleteAsync(int entityId)
        {
            Int64 startTicks = Log.DOMAINSERVICES("(FoodDataService) Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Food>(context);
                await _repository.DeleteAsync(entityId);
            }

            Log.DOMAINSERVICES("(FoodDataService) Exit", Common.LOG_APPNAME, startTicks);
        }

        public bool HasChanges()
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            // TODO(crhodes)
            // Hum.  How to determine if something has changed that can drive the UI logic.
            // This wont' work as we are creating a brand new context.

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Food>(context);
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
