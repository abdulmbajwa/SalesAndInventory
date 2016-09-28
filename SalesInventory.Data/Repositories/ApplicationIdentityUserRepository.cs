using NPoco;
using SalesInventory.Core.Data;
using SalesInventory.Core.DomainModels.Identity;
using SalesInventory.Data.UnitOfWork;

namespace SalesInventory.Data.Repositories
{
    public class ApplicationIdentityUserRepository : EntityRepository<ApplicationUser> , IUserRepository<ApplicationUser>
    {
        public ApplicationIdentityUserRepository(IDatabase database) : base(database)
        {
        }

        public ApplicationUser FindByName(string username)
        {
            var context = new Context(_database);
            using (var session = context.OpenSession())
            {
                return session.Database.SingleOrDefault<ApplicationUser>("WHERE UserName = @0", username);
            }
        }
    }
}
