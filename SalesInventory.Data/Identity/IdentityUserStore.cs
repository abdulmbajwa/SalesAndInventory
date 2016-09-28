using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using SalesInventory.Core.Data;
using SalesInventory.Core.DomainModels.Identity;
using SalesInventory.Data.Extensions;
using SalesInventory.Data.Identity.Models;

namespace SalesInventory.Data.Identity
{
    public class IdentityUserStore : IUserStore<ApplicationIdentityUser, int>, IUserPasswordStore<ApplicationIdentityUser, int>, IUserEmailStore<ApplicationIdentityUser, int>, IUserSecurityStampStore<ApplicationIdentityUser, int>, IUserLockoutStore<ApplicationIdentityUser, int>, IUserTwoFactorStore<ApplicationIdentityUser, int>
    {
        private readonly IUserRepository<ApplicationUser> _repository;
        public IdentityUserStore(IUserRepository<ApplicationUser> repository)
        {
            _repository = repository;
        }
        public void Dispose()
        {
            _repository.Dispose();
        }

        public Task CreateAsync(ApplicationIdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            return Task.Factory.StartNew(() => _repository.Insert(user.ToAppUser()));
        }

        public Task UpdateAsync(ApplicationIdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            return Task.Factory.StartNew(() => _repository.Update(user.ToAppUser()));
        }

        public Task DeleteAsync(ApplicationIdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            return Task.Factory.StartNew(() => _repository.Delete(user.ToAppUser()));
        }

        public Task<ApplicationIdentityUser> FindByIdAsync(int userId)
        {
            if (userId == 0)
                throw new ArgumentOutOfRangeException(nameof(userId));
            return Task.Factory.StartNew(() => _repository.GetSingle(userId).ToApplicationUser());
        }

        public Task<ApplicationIdentityUser> FindByNameAsync(string userName)
        {
            if (userName == null)
                throw new ArgumentNullException(nameof(userName));
            return Task.Factory.StartNew(() => _repository.FindByName(userName).ToApplicationUser());
        }

        public Task SetPasswordHashAsync(ApplicationIdentityUser user, string passwordHash)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new ArgumentNullException(nameof(passwordHash));
            user.PasswordHash = passwordHash;
            return Task.FromResult(0);
        }

        public Task<string> GetPasswordHashAsync(ApplicationIdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            return Task.Factory.StartNew(()=>user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(ApplicationIdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            return Task.Factory.StartNew(()=>user.PasswordHash != null);
        }

        public Task SetEmailAsync(ApplicationIdentityUser user, string email)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            user.Email = email;
            return Task.FromResult(0);
        }

        public Task<string> GetEmailAsync(ApplicationIdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            return Task.Factory.StartNew(() => user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(ApplicationIdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            return Task.Factory.StartNew(() => user.EmailConfirmed);
        }

        public Task SetEmailConfirmedAsync(ApplicationIdentityUser user, bool confirmed)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            user.EmailConfirmed = confirmed;
            return Task.FromResult(0);
        }

        public Task<ApplicationIdentityUser> FindByEmailAsync(string email)
        {
            if (email == null)
                throw new ArgumentNullException(nameof(email));
            return Task.Factory.StartNew(() => _repository.FindByName(email).ToApplicationUser());
        }

        public Task SetSecurityStampAsync(ApplicationIdentityUser user, string stamp)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            user.SecurityStamp = stamp;
            return Task.FromResult(0);
        }

        public Task<string> GetSecurityStampAsync(ApplicationIdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            return Task.Factory.StartNew(() => user.SecurityStamp);
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(ApplicationIdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            DateTimeOffset dateTimeOffset = DateTime.SpecifyKind(user.LockoutEndDateUtc.GetValueOrDefault(),
                DateTimeKind.Utc);
            return Task.Factory.StartNew(() => dateTimeOffset);
        }

        public Task SetLockoutEndDateAsync(ApplicationIdentityUser user, DateTimeOffset lockoutEnd)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            user.LockoutEndDateUtc = lockoutEnd.DateTime;
            return Task.FromResult(0);
        }

        public Task<int> IncrementAccessFailedCountAsync(ApplicationIdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            return Task.Factory.StartNew(() => user.AccessFailedCount++);
        }

        public Task ResetAccessFailedCountAsync(ApplicationIdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            user.AccessFailedCount = 0;
            return Task.FromResult(0);
        }

        public Task<int> GetAccessFailedCountAsync(ApplicationIdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            return Task.Factory.StartNew(() => user.AccessFailedCount);
        }

        public Task<bool> GetLockoutEnabledAsync(ApplicationIdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            return Task.Factory.StartNew(() => user.LockoutEnabled);
        }

        public Task SetLockoutEnabledAsync(ApplicationIdentityUser user, bool enabled)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            user.LockoutEnabled = enabled;
            return Task.FromResult(0);
        }

        public Task SetTwoFactorEnabledAsync(ApplicationIdentityUser user, bool enabled)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            user.TwoFactorEnabled = enabled;
            return Task.FromResult(0);
        }

        public Task<bool> GetTwoFactorEnabledAsync(ApplicationIdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            return Task.Factory.StartNew(() => user.TwoFactorEnabled);
        }
    }
}
