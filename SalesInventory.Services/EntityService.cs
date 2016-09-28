using System.Collections.Generic;
using System.Threading.Tasks;
using SubscriberManagementSystem.Core.Data;
using SubscriberManagementSystem.Core.DomainModels;
using SubscriberManagementSystem.Core.Services;

namespace SubscriberManagementSystem.Services
{
    public class EntityService<TEntity> : IService<TEntity> where TEntity : BaseEntity
    {
        private readonly IRepository<TEntity> _repository; 
        public EntityService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }
        public List<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public Page<TEntity> GetAll(int pageIndex, int pageSize, OrderBy orderBy = OrderBy.Descending)
        {
            return _repository.GetAll(pageIndex,pageSize, orderBy);
        }

        public TEntity GetSingle(int id)
        {
            return _repository.GetSingle(id);
        }

        public void Insert(TEntity entity)
        {
            _repository.Insert(entity);
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<Page<TEntity>> GetAllAsync(int pageIndex, int pageSize, OrderBy orderBy = OrderBy.Descending)
        {
            return _repository.GetAllAsync(pageIndex, pageSize, orderBy);
        }

        public Task<TEntity> GetSingleAsync(int id)
        {
            return _repository.GetSingleAsync(id);
        }
    }
}
