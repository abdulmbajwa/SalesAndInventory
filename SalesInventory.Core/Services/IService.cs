using System.Collections.Generic;
using System.Threading.Tasks;
using SalesInventory.Core.Data;
using SalesInventory.Core.DomainModels;

namespace SalesInventory.Core.Services
{
    public interface IService<TEntity> where TEntity : BaseEntity
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