using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NPoco;
using SalesInventory.Core.Data;
using SalesInventory.Core.DomainModels;
using SalesInventory.Data.UnitOfWork;

namespace SalesInventory.Data.Repositories
{
    public class EntityRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        public EntityRepository(IDatabase database)
        {
            _database = database;
        }
        protected IDatabase _database;
        public void Delete(TEntity entity)
        {
            var context = new Context(_database);
            using (var session = context.OpenSession())
            {
                entity.IsDeleted = true;
                session.Database.Update(entity);
            }
        }

        public void Dispose()
        {
            _database.Dispose();
        }

        public List<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            var context = new Context(_database);
            using (var session = context.OpenSession())
            {
                return session.Database.Query<TEntity>().Where(predicate).ToList();
            }
        }

        public List<TEntity> GetAll()
        {
            var context = new Context(_database);
            using (var session = context.OpenSession())
            {
                return session.Database.Fetch<TEntity>("WHERE [IsDeleted] = 0");
            }
        }

        public Core.DomainModels.Page<TEntity> GetAll(int pageIndex, int pageSize,OrderBy orderBy = OrderBy.Descending)
        {
            var context = new Context(_database);
            using (var session = context.OpenSession())
            {
                var data =  session.Database.Page<TEntity>(pageIndex,pageSize,"WHERE [IsDeleted] = 0");
                return new Core.DomainModels.Page<TEntity>
                {
                    CurrentPage = data.CurrentPage,
                    Items = data.Items,
                    ItemsPerPage = data.ItemsPerPage,
                    TotalItems = data.TotalItems,
                    TotalPages = data.TotalPages
                };
            }
        }

        public Core.DomainModels.Page<TEntity> GetAll(int pageIndex, int pageSize, Expression<Func<TEntity, int>> keySelector, OrderBy orderBy = OrderBy.Ascending)
        {
            throw new NotImplementedException();
        }

        public Core.DomainModels.Page<TEntity> GetAll(int pageIndex, int pageSize, Expression<Func<TEntity, int>> keySelector, Expression<Func<TEntity, bool>> predicate, OrderBy orderBy, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            var context = new Context(_database);
            using (var session = context.OpenSession())
            {
                return session.Database.FetchAsync<TEntity>("WHERE [IsDeleted] = 0");
            }
        }

        public Task<Core.DomainModels.Page<TEntity>> GetAllAsync(int pageIndex, int pageSize, OrderBy orderBy = OrderBy.Descending)
        {
            throw new NotImplementedException();
        }
        public TEntity GetSingle(int id)
        {
            var context = new Context(_database);
            using (var session = context.OpenSession())
            {
                return session.Database.SingleOrDefaultById<TEntity>(id);
            }
        }

        public Task<TEntity> GetSingleAsync(int id)
        {
            var context = new Context(_database);
            using (var session = context.OpenSession())
            {
                return session.Database.SingleOrDefaultByIdAsync<TEntity>(id);
            }
        }

        public void Insert(TEntity entity)
        {
            var context = new Context(_database);
            using (var session = context.OpenSession())
            {
                session.Database.Insert(entity);
                session.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            var context = new Context(_database);
            using (var session = context.OpenSession())
            {
                session.Database.Update(entity);
                session.SaveChanges();
            }
        }
    }
}
