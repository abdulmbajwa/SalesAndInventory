using System;
using NPoco;

namespace SalesInventory.Data.UnitOfWork
{
    public sealed class Session : ISession
    {
        private readonly IDatabase _database;
        private readonly ITransaction _transaction;

        public Session(IDatabase db)
        {
            _database = db;
            _transaction = _database.GetTransaction();
        }

        public IDatabase Database
        {
            get
            {
                return _database;
            }
        }

        public string SessionId
        {
            get
            {
                return Guid.NewGuid().ToString();
            }
        }

        public void SaveChanges()
        {
            _transaction.Complete();
        }

        public void Dispose()
        {
            _transaction.Dispose();
        }
    }
}
