namespace SalesInventory.Data.UnitOfWork
{
    public interface IContext
    {
        ISession OpenSession();
    }
}