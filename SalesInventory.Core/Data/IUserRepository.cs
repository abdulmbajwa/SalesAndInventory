using SalesInventory.Core.DomainModels;

namespace SalesInventory.Core.Data
{
    public interface IUserRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity FindByName(string username);
    }
}