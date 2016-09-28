using System;
using NPoco;

namespace SalesInventory.Data.UnitOfWork
{
    public interface ISession : IDisposable
    {
        IDatabase Database { get; }
        string SessionId { get; }

        void SaveChanges();
    }
}