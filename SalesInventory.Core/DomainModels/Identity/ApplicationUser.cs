using System;
using System.Collections.Generic;

namespace SalesInventory.Core.DomainModels.Identity
{
    public class ApplicationUser : BaseEntity
    {
        public ApplicationUser()
        {
            Claims = new List<ApplicationUserClaim>();
            Logins = new List<ApplicationUserLogin>();
            Roles = new List<ApplicationUserRole>();
        }
        public int AccessFailedCount { get; set; }
        public ICollection<ApplicationUserClaim> Claims { get; private set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public ICollection<ApplicationUserLogin> Logins { get; private set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public ICollection<ApplicationUserRole> Roles { get; private set; }
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
}
