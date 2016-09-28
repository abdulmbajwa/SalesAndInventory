using NPoco.FluentMappings;
using SalesInventory.Core.DomainModels;
using SalesInventory.Core.DomainModels.Identity;

namespace SalesInventory.Data.DatabaseMappings
{
    public class NPocoMappings : Mappings
    {
        public NPocoMappings()
        {
            For<ApplicationUser>().TableName(nameof(ApplicationUser)+"s").Columns(c =>
            {
                c.Column(x => x.Claims).Ignore();
                c.Column(x => x.Logins).Ignore();
                c.Column(x => x.Roles).Ignore();
                c.Column(x => x.FullName).Ignore();
            });
            For<Customer>().TableName(nameof(Customer) + "s")
                .Columns(c =>
                {
                    c.Column(x => x.CustomerType).Ignore();
                    c.Column(x => x.City).Ignore();
                    c.Column(x => x.SmartCards).Ignore();
                });
            For<CustomerType>().TableName(nameof(CustomerType)+"s");
            For<Package>().TableName(nameof(Package) +"s");
            For<City>().TableName("Cities");
            //For<QueueStatus>().TableName(nameof(QueueStatus) +"es");
            //For<UserAuthorization>().TableName(nameof(UserAuthorization) +"s");
            //For<AccountStatus>().TableName(nameof(AccountStatus) +"es");
            //For<PaymentGateway>().TableName(nameof(PaymentGateway) +"s");
        }
    }
}
