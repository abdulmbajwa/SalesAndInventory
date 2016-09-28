using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NPoco;
using SalesInventory.Core.Data;
using SalesInventory.Core.DomainModels;
using SalesInventory.Data.UnitOfWork;

namespace SalesInventory.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public CustomerRepository(IDatabase database)
        {
            Database = database;
        }

        private IDatabase Database { get; }

        public void Dispose()
        {
            Database.Dispose();
        }

        public List<Customer> GetAll()
        {
            var context = new Context(Database);
            using (var session = context.OpenSession())
            {
                var data = session.Database.Fetch<dynamic>(@"SELECT [s].[Id]
                          ,[s].[FirstName]
                          ,[s].[LastName]
                          ,[s].[CNIC]
                          ,[s].[MobileNo]
                          ,[s].[PhoneNo]
                          ,[s].[Address]
                          ,[s].[CityId]
                          ,[s].[SubscriberTypeId]
                          ,[c].[Id] as City_Id
                          ,[c].[Name] as City_Name
                          ,[c].[ProvinceId] as City_ProvinceId
                          ,[c].[IsDeleted] as City_IsDeleted
                          ,[st].[Id] as SubsriberType_Id
                          ,[st].[Type] as SubsriberType_Name
                          ,[st].[IsDeleted] as SubsriberType_IsDeleted
                      FROM[SubscriberManagementSystem].[dbo].[Subscribers] as s
                      JOIN[SubscriberManagementSystem].[dbo].[Cities] as c on c.Id = s.CityId
                      JOIN[SubscriberManagementSystem].[dbo].[SubscriberTypes] as st on st.Id = s.SubscriberTypeId
                      WHERE [s].[IsDeleted] = 0  AND[c].[IsDeleted] = 0");
                Slapper.AutoMapper.Configuration
                    .AddIdentifiers(typeof(City), new List<string> { "CityId" });
                Slapper.AutoMapper.Configuration
                    .AddIdentifiers(typeof(CustomerType), new List<string> { "SubscriberTypeId" });

                var subscribers = Slapper.AutoMapper.MapDynamic<Customer>(data).ToList();
                return subscribers;
            }
        }

        public Core.DomainModels.Page<Customer> GetAll(int pageIndex, int pageSize, OrderBy orderBy = OrderBy.Descending)
        {
            var context = new Context(Database);
            using (var session = context.OpenSession())
            {
                var data = session.Database.Page<dynamic>(pageIndex,pageSize, @"SELECT [s].[Id]
                          ,[s].[FirstName]
                          ,[s].[LastName]
                          ,[s].[CNIC]
                          ,[s].[MobileNo]
                          ,[s].[PhoneNo]
                          ,[s].[Address]
                          ,[s].[CityId]
                          ,[s].[SubscriberTypeId]
                          ,[c].[Id] as City_Id
                          ,[c].[Name] as City_Name
                          ,[c].[ProvinceId] as City_ProvinceId
                          ,[c].[IsDeleted] as City_IsDeleted
                          ,[st].[Id] as SubsriberType_Id
                          ,[st].[Type] as SubsriberType_Type
                          ,[st].[IsDeleted] as SubsriberType_IsDeleted
                      FROM[SubscriberManagementSystem].[dbo].[Subscribers] as s
                      JOIN[SubscriberManagementSystem].[dbo].[Cities] as c on c.Id = s.CityId
                      JOIN[SubscriberManagementSystem].[dbo].[SubscriberTypes] as st on st.Id = s.SubscriberTypeId
                      WHERE [s].[IsDeleted] = 0  AND[c].[IsDeleted] = 0");
                Slapper.AutoMapper.Configuration
                    .AddIdentifiers(typeof(City), new List<string> { "CityId" });
                Slapper.AutoMapper.Configuration
                    .AddIdentifiers(typeof(CustomerType), new List<string> { "SubscriberTypeId" });

                var subscribers = Slapper.AutoMapper.MapDynamic<Customer>(data.Items).ToList();
                return new Core.DomainModels.Page<Customer>
                {
                    Items = subscribers,
                    CurrentPage = data.CurrentPage,
                    ItemsPerPage = data.ItemsPerPage,
                    TotalItems = data.TotalItems,
                    TotalPages = data.TotalPages
                };
            }
        }

        public Customer GetSingle(int id)
        {
            var context = new Context(Database);
            using (var session = context.OpenSession())
            {
                var data = session.Database.SingleOrDefault<Customer>(@"SELECT [s].[Id]
                          ,[s].[FirstName]
                          ,[s].[LastName]
                          ,[s].[CNIC]
                          ,[s].[MobileNo]
                          ,[s].[PhoneNo]
                          ,[s].[Address]
                          ,[s].[CityId]
                          ,[s].[SubscriberTypeId]
                          ,[c].[Id] as City_Id
                          ,[c].[Name] as City_Name
                          ,[c].[ProvinceId] as City_ProvinceId
                          ,[c].[IsDeleted] as City_IsDeleted
                          ,[st].[Id] as SubsriberType_Id
                          ,[st].[Type] as SubsriberType_Name
                          ,[st].[IsDeleted] as SubsriberType_IsDeleted
                      FROM[SubscriberManagementSystem].[dbo].[Subscribers] as s
                      JOIN[SubscriberManagementSystem].[dbo].[Cities] as c on c.Id = s.CityId
                      JOIN[SubscriberManagementSystem].[dbo].[SubscriberTypes] as st on st.Id = s.SubscriberTypeId
                      WHERE [s].[Id] = @0 AND ([s].[IsDeleted] = 0  AND[c].[IsDeleted] = 0)",id);
                Slapper.AutoMapper.Configuration
                    .AddIdentifiers(typeof(Package), new List<string> { "PackageId" });
                Slapper.AutoMapper.Configuration
                    .AddIdentifiers(typeof(City), new List<string> { "CityId" });
                Slapper.AutoMapper.Configuration
                    .AddIdentifiers(typeof(CustomerType), new List<string> { "SubscriberTypeId" });
                var subscriber = Slapper.AutoMapper.MapDynamic<Customer>(data);
                return subscriber;
            }
        }

        public void Insert(Customer entity)
        {
            var context = new Context(Database);
            using (var session = context.OpenSession())
            {
                session.Database.Insert(entity);
                session.SaveChanges();
            }
        }

        public void Update(Customer entity)
        {
            var context = new Context(Database);
            using (var session = context.OpenSession())
            {
                var smartCard =
                    session.Database.SingleOrDefault<SmartCard>("WHERE [CardNumber] = @0 AND [IsDeleted] = 0", entity);
                session.Database.Update(entity);
                session.SaveChanges();
            }
        }

        public void Delete(Customer entity)
        {
            var context = new Context(Database);
            using (var session = context.OpenSession())
            {
                entity.IsDeleted = true;
                session.Database.Update(entity);
                session.SaveChanges();
            }
        }

        public Task<List<Customer>> GetAllAsync()
        {
            return Task.Run(() =>
            {
                var context = new Context(Database);
                using (var session = context.OpenSession())
                {
                    var data = session.Database.Fetch<dynamic>(@"SELECT [s].[Id]
                          ,[s].[FirstName]
                          ,[s].[LastName]
                          ,[s].[CNIC]
                          ,[s].[MobileNo]
                          ,[s].[PhoneNo]
                          ,[s].[Address]
                          ,[s].[CityId]
                          ,[s].[SubscriberTypeId]
                          ,[c].[Id] as City_Id
                          ,[c].[Name] as City_Name
                          ,[c].[ProvinceId] as City_ProvinceId
                          ,[c].[IsDeleted] as City_IsDeleted
                          ,[st].[Id] as SubsriberType_Id
                          ,[st].[Type] as SubsriberType_Name
                          ,[st].[IsDeleted] as SubsriberType_IsDeleted
                      FROM[SubscriberManagementSystem].[dbo].[Subscribers] as s
                      JOIN[SubscriberManagementSystem].[dbo].[Cities] as c on c.Id = s.CityId
                      JOIN[SubscriberManagementSystem].[dbo].[SubscriberTypes] as st on st.Id = s.SubscriberTypeId
                      WHERE [s].[IsDeleted] = 0  AND[c].[IsDeleted] = 0");
                    Slapper.AutoMapper.Configuration
                        .AddIdentifiers(typeof (Package), new List<string> {"PackageId"});
                    Slapper.AutoMapper.Configuration
                        .AddIdentifiers(typeof (City), new List<string> {"CityId"});
                    Slapper.AutoMapper.Configuration
                    .AddIdentifiers(typeof(CustomerType), new List<string> { "SubscriberTypeId" });

                    var subscribers = Slapper.AutoMapper.MapDynamic<Customer>(data).ToList();
                    return subscribers;
                }
            });
        }

        public Task<Core.DomainModels.Page<Customer>> GetAllAsync(int pageIndex, int pageSize, OrderBy orderBy = OrderBy.Descending)
            {
                return Task.Run(() =>
                {
                    var context = new Context(Database);
                    using (var session = context.OpenSession())
                    {
                        var data = session.Database.Page<dynamic>(pageIndex, pageSize, @"SELECT [s].[Id]
                          ,[s].[FirstName]
                          ,[s].[LastName]
                          ,[s].[CNIC]
                          ,[s].[MobileNo]
                          ,[s].[PhoneNo]
                          ,[s].[Address]
                          ,[s].[CityId]
                          ,[s].[SubscriberTypeId]
                          ,[c].[Id] as City_Id
                          ,[c].[Name] as City_Name
                          ,[c].[ProvinceId] as City_ProvinceId
                          ,[c].[IsDeleted] as City_IsDeleted
                          ,[st].[Id] as SubsriberType_Id
                          ,[st].[Type] as SubsriberType_Name
                          ,[st].[IsDeleted] as SubsriberType_IsDeleted
                      FROM[SubscriberManagementSystem].[dbo].[Subscribers] as s
                      JOIN[SubscriberManagementSystem].[dbo].[Cities] as c on c.Id = s.CityId
                      JOIN[SubscriberManagementSystem].[dbo].[SubscriberTypes] as st on st.Id = s.SubscriberTypeId
                      WHERE [s].[IsDeleted] = 0  AND[c].[IsDeleted] = 0");
                        Slapper.AutoMapper.Configuration
                            .AddIdentifiers(typeof(City), new List<string> { "CityId" });
                        Slapper.AutoMapper.Configuration
                            .AddIdentifiers(typeof(CustomerType), new List<string> { "SubscriberTypeId" });

                        var subscribers = Slapper.AutoMapper.MapDynamic<Customer>(data.Items).ToList();
                        return new Core.DomainModels.Page<Customer>
                        {
                            Items = subscribers,
                            CurrentPage = data.CurrentPage,
                            ItemsPerPage = data.ItemsPerPage,
                            TotalItems = data.TotalItems,
                            TotalPages = data.TotalPages
                        };
                    }
                });
        }

        public Task<Customer> GetSingleAsync(int id)
        {
            return Task.Run(() =>
            {
                var context = new Context(Database);
                using (var session = context.OpenSession())
                {
                    var data = session.Database.SingleOrDefault<Customer>(@"SELECT [s].[Id]
                          ,[s].[FirstName]
                          ,[s].[LastName]
                          ,[s].[CNIC]
                          ,[s].[MobileNo]
                          ,[s].[PhoneNo]
                          ,[s].[Address]
                          ,[s].[CityId]
                          ,[s].[SubscriberTypeId]
                          ,[c].[Id] as City_Id
                          ,[c].[Name] as City_Name
                          ,[c].[ProvinceId] as City_ProvinceId
                          ,[c].[IsDeleted] as City_IsDeleted
                          ,[st].[Id] as SubsriberType_Id
                          ,[st].[Type] as SubsriberType_Name
                          ,[st].[IsDeleted] as SubsriberType_IsDeleted
                      FROM[SubscriberManagementSystem].[dbo].[Subscribers] as s
                      JOIN[SubscriberManagementSystem].[dbo].[Packages] as p on p.Id = s.PackageId
                      JOIN[SubscriberManagementSystem].[dbo].[Cities] as c on c.Id = s.CityId
                      JOIN[SubscriberManagementSystem].[dbo].[SubscriberTypes] as st on st.Id = s.SubscriberTypeId
                      WHERE [s].[Id] = @0 AND ([s].[IsDeleted] = 0  AND[c].[IsDeleted] = 0)", id);
                    Slapper.AutoMapper.Configuration
                        .AddIdentifiers(typeof(City), new List<string> { "CityId" });
                    Slapper.AutoMapper.Configuration
                    .AddIdentifiers(typeof(CustomerType), new List<string> { "SubscriberTypeId" });
                    var subscriber = Slapper.AutoMapper.MapDynamic<Customer>(data);
                    return subscriber;
                }
            });
        }
    }
}
