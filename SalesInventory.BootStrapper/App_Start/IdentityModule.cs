
using System.Web;
using Autofac;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using NPoco;
using NPoco.FluentMappings;
using SalesInventory.Core.Data;
using SalesInventory.Core.Identity;
using SalesInventory.Data.DatabaseMappings;
using SalesInventory.Data.Identity;
using SalesInventory.Data.Identity.Models;
using SalesInventory.Data.Repositories;
using SalesInventory.Web;

namespace SalesInventory.BootStrapper
{
    public class IdentityModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var fluentConfig = FluentMappingConfiguration.Configure(new NPocoMappings());
            var dbFactory = DatabaseFactory.Config(x =>
            {
                x.UsingDatabase(() => new Database("DefaultConnection"));
                x.WithFluentConfig(fluentConfig);
            });
            builder.Register(c => dbFactory.GetDatabase()).As<IDatabase>().InstancePerLifetimeScope();
            builder.RegisterType(typeof(Data.Identity.ApplicationUserManager)).As(typeof(IApplicationUserManager)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(ApplicationRoleManager)).As(typeof(IApplicationRoleManager)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(ApplicationIdentityUserRepository)).As(typeof(IUserRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(ApplicationIdentityUser)).As(typeof(IUser<int>)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(IdentityUserStore)).As<IUserStore<ApplicationIdentityUser, int>>().InstancePerLifetimeScope();
            builder.Register(b =>
            {
                var manager = IdentityFactory.CreateUserManager(b.Resolve<IUserStore<ApplicationIdentityUser, int>>());
                if (Startup.DataProtectionProvider != null)
                {
                    manager.UserTokenProvider =
                        new DataProtectorTokenProvider<ApplicationIdentityUser, int>(
                            Startup.DataProtectionProvider.Create("ASP.NET Identity"));
                }
                return manager;
            }).InstancePerLifetimeScope();
            //builder.Register(b => IdentityFactory.CreateRoleManager(b.Resolve<DbContext>())).InstancePerHttpRequest();
            builder.Register(b => HttpContext.Current.GetOwinContext().Authentication).InstancePerLifetimeScope();
        }
    }
}
