using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;


using PrismApp1.Domain;
using PrismApp1.Persistence.Data;


using VNC;
using VNC.Core.DomainServices;

namespace PrismApp1.DomainServices
{
    // NOTE(crhodes)
    // This creates a new context each time.  How would HasChanges work?

    public class ProjectDataService : IProjectDataService
    {
        private Func<PrismApp1DbContext> _contextCreator;

        private ConnectedRepository<Project> _repository;

        #region Constructors

        public ProjectDataService(Func<PrismApp1DbContext> context)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            _contextCreator = context;

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        #endregion Constructors

        #region Public Methods

        #region All

        public IEnumerable<Project> All()
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Project>(context);
                return _repository.All();
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public async Task<List<Project>> AllAsync()
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Project>(context);
                return await _repository.AllAsync();
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public IEnumerable<Project> AllInclude(
            params Expression<Func<Project, object>>[] includeProperties)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Project>(context);
                return _repository.AllInclude(includeProperties);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public async Task<IEnumerable<Project>> AllIncludeAsync(
            params Expression<Func<Project, object>>[] includeProperties)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Project>(context);
                return await _repository.AllIncludeAsync(includeProperties);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        #endregion All

        #region Find

        public Project FindById(int entityId)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Project>(context);
                return _repository.FindById(entityId);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public async Task<Project> FindByIdAsync(int entityId)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Project>(context);
                return await _repository.FindByIdAsync(entityId);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public IEnumerable<Project> FindBy(
            Expression<Func<Project, bool>> predicate)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Project>(context);
                return _repository.FindBy(predicate);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public async Task<IEnumerable<Project>> FindByAsync(
            Expression<Func<Project, bool>> predicate)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Project>(context);
                return await _repository.FindByAsync(predicate);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public IEnumerable<Project> FindByInclude(
            Expression<Func<Project, bool>> predicate,
            params Expression<Func<Project, object>>[] includeProperties)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Project>(context);
                return _repository.FindByInclude(predicate, includeProperties);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public async Task<IEnumerable<Project>> FindByIncludeAsync(
            Expression<Func<Project, bool>> predicate,
            params Expression<Func<Project, object>>[] includeProperties)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Project>(context);
                return await _repository.FindByIncludeAsync(predicate, includeProperties);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        // TODO(crhodes)
        // Decide if we need FindByKey

        #endregion Find

        #region Insert

        public void Insert(Project entity)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Project>(context);
                _repository.Insert(entity);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public async Task InsertAsync(Project entity)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Project>(context);
                await _repository.InsertAsync(entity);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        #endregion Insert

        #region Update

        public void Update(Project entity)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Project>(context);
                _repository.Update(entity);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public async Task UpdateAsync()
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Project>(context);
                await _repository.UpdateAsync();
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public async Task UpdateAsync(Project entity)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Project>(context);

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
                _repository = new ConnectedRepository<Project>(context);
                _repository.Delete(entityId);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public async Task DeleteAsync(int entityId)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Project>(context);
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
                _repository = new ConnectedRepository<Project>(context);
                var result = _repository.HasChanges();
                return result;
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);

        }


        #endregion Delete

        #endregion

    }
}
