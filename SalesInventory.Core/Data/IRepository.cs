using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SalesInventory.Core.DomainModels;

namespace SalesInventory.Core.Data
{
    public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        List<TEntity> GetAll();
        Page<TEntity> GetAll(int pageIndex, int pageSize, OrderBy orderBy = OrderBy.Descending);
        TEntity GetSingle(int id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<List<TEntity>> GetAllAsync();
        Task<Page<TEntity>> GetAllAsync(int pageIndex, int pageSize, OrderBy orderBy = OrderBy.Descending);
        Task<TEntity> GetSingleAsync(int id);
    }
}
