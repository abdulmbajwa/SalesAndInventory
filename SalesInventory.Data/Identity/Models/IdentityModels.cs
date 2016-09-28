using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SalesInventory.Core.DomainModels;

namespace SalesInventory.Data.Identity.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationIdentityUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationIdentityUser :BaseEntity, IUser<int> 
    {
        public ApplicationIdentityUser()
        {
            Claims = new List<ApplicationIdentityUserClaim>();
            Roles = new List<ApplicationIdentityUserRole>();
            Logins = new List<ApplicationIdentityUserLogin>();
        }
        public int AccessFailedCount { get; set; }
        public ICollection<ApplicationIdentityUserClaim> Claims { get; private set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public ICollection<ApplicationIdentityUserLogin> Logins { get; private set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public ICollection<ApplicationIdentityUserRole> Roles { get; private set; }
        public string SecurityStamp { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string UserName { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime LastLoginTime { get; set; }
        public string LastLoginIp { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        public string ProfilePic { get; set; }

    }


    public class ApplicationIdentityRole : BaseEntity,IRole<int>
    {
        public ApplicationIdentityRole()
        {
        }

        public ApplicationIdentityRole(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }

    public class ApplicationIdentityUserRole : IdentityUserRole<int>
    {
    }

    public class ApplicationIdentityUserClaim : IdentityUserClaim<int>
    {
    }

    public class ApplicationIdentityUserLogin : IdentityUserLogin<int>
    {
    }

}