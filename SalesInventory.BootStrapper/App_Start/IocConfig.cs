using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using SalesInventory.BootStrapper;
using SalesInventory.Core.Data;
using SalesInventory.Core.DomainModels.Identity;
using SalesInventory.Core.Services;
using SalesInventory.Data.Repositories;
using SalesInventory.Web;
using SubscriberManagementSystem.Services;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(IocConfig), "RegisterDependencies")]
namespace SalesInventory.BootStrapper
{
    public class IocConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            //const string nameOrConnectionString = "name=AppContext";
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModule<AutofacWebTypesModule>();
            builder.RegisterGeneric(typeof(EntityRepository<>)).As(typeof(IRepository<>)).InstancePerRequest();
            builder.RegisterGeneric(typeof(EntityService<>)).As(typeof(IService<>)).InstancePerRequest();
            builder.RegisterType(typeof(ApplicationIdentityUserRepository)).As(typeof(IUserRepository<ApplicationUser>)).InstancePerRequest();
            builder.RegisterType(typeof(CustomerRepository))
                .As(typeof(ICustomerRepository)).InstancePerRequest();
            builder.RegisterModule(new IdentityModule());
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


        }
    }
}
