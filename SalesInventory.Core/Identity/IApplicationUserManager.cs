using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using SalesInventory.Core.DomainModels.Identity;

namespace SalesInventory.Core.Identity
{
    public interface IApplicationUserManager : IDisposable
    {
        string ApplicationCookie { get; }
        string ExternalBearer { get; }
        string ExternalCookie { get; }
        string TwoFactorCookie { get; }
        string TwoFactorRememberBrowserCookie { get; }
        Task<ApplicationIdentityResult> AccessFailedAsync(int userId);
        Task<ApplicationIdentityResult> AddClaimAsync(int userId, Claim claim);
        Task<ApplicationIdentityResult> AddLoginAsync(int userId, ApplicationUserLoginInfo login);
        Task<ApplicationIdentityResult> AddToRoleAsync(int userId, string role);
        ApplicationIdentityResult AddToRole(int userId, string role);
        Task<ApplicationIdentityResult> AddPasswordAsync(int userId, string password);
        Task<ApplicationIdentityResult> AddUserToRolesAsync(int userId, IList<string> roles);
        Task<ApplicationIdentityResult> ChangePasswordAsync(int userId, string currentPassword, string newPassword);
        Task<ApplicationIdentityResult> ChangePhoneNumberAsync(int userId, string phoneNumber, string token);
        void Challenge(string redirectUri, string xsrfKey, int? userId, params string[] authenticationTypes);
        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
        Task<ApplicationIdentityResult> ConfirmEmailAsync(int userId, string token);
        Task<ApplicationIdentityResult> CreateAsync(ApplicationUser user);
        Task<ApplicationIdentityResult> CreateAsync(ApplicationUser user, string password);
        ClaimsIdentity CreateIdentity(ApplicationUser user, string authenticationType);
        Task<ClaimsIdentity> CreateIdentityAsync(ApplicationUser user, string authenticationType);
        ApplicationIdentityResult Create(ApplicationUser user);
        ApplicationIdentityResult Create(ApplicationUser user, string password);
        ClaimsIdentity CreateTwoFactorRememberBrowserIdentity(int userId);
        Task<ApplicationIdentityResult> DeleteAsync(int userId);
        Task<SignInStatus> ExternalSignInAsync(ApplicationExternalLoginInfo loginInfo, bool isPersistent);
        Task<ApplicationUser> FindAsync(ApplicationUserLoginInfo login);
        Task<ApplicationUser> FindAsync(string userName, string password);
        Task<ApplicationUser> FindByEmailAsync(string email);
        ApplicationUser FindById(int userId);
        Task<ApplicationUser> FindByIdAsync(int userId);
        Task<ApplicationUser> FindByNameAsync(string userName);
        ApplicationUser FindByName(string userName);
        Task<string> GenerateChangePhoneNumberTokenAsync(int userId, string phoneNumber);
        Task<string> GenerateEmailConfirmationTokenAsync(int userId);
        Task<string> GeneratePasswordResetTokenAsync(int userId);
        Task<string> GenerateTwoFactorTokenAsync(int userId, string twoFactorProvider);
        Task<string> GenerateUserTokenAsync(string purpose, int userId);
        Task<int> GetAccessFailedCountAsync(int userId);
        Task<IList<Claim>> GetClaimsAsync(int userId);
        Task<string> GetEmailAsync(int userId);
        IEnumerable<ApplicationAuthenticationDescription> GetExternalAuthenticationTypes();
        Task<ClaimsIdentity> GetExternalIdentityAsync(string externalAuthenticationType);
        ApplicationExternalLoginInfo GetExternalLoginInfo();
        ApplicationExternalLoginInfo GetExternalLoginInfo(string xsrfKey, string expectedValue);
        Task<ApplicationExternalLoginInfo> GetExternalLoginInfoAsync();
        Task<ApplicationExternalLoginInfo> GetExternalLoginInfoAsync(string xsrfKey, string expectedValue);
        Task<bool> GetLockoutEnabledAsync(int userId);
        Task<DateTimeOffset> GetLockoutEndDateAsync(int userId);
        IList<ApplicationUserLoginInfo> GetLogins(int userId);
        Task<IList<ApplicationUserLoginInfo>> GetLoginsAsync(int userId);
        Task<string> GetPhoneNumberAsync(int userId);
        Task<IList<string>> GetRolesAsync(int userId);
        IList<string> GetRoles(int userId);
        Task<string> GetSecurityStampAsync(int userId);
        Task<bool> GetTwoFactorEnabledAsync(int userId);
        Task<IList<string>> GetValidTwoFactorProvidersAsync(int userId);
        Task<int?> GetVerifiedUserIdAsync();
        Task<bool> HasBeenVerifiedAsync();
        Task<bool> HasPasswordAsync(int userId);
        Task<bool> IsEmailConfirmedAsync(int userId);
        Task<bool> IsInRoleAsync(int userId, string role);
        Task<bool> IsLockedOutAsync(int userId);
        Task<bool> IsPhoneNumberConfirmedAsync(int userId);
        Task<ApplicationIdentityResult> NotifyTwoFactorTokenAsync(int userId, string twoFactorProvider, string token);
        Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent, bool shouldLockout);
        Task<ApplicationIdentityResult> RemoveClaimAsync(int userId, Claim claim);
        Task<ApplicationIdentityResult> RemoveFromRoleAsync(int userId, string role);
        Task<ApplicationIdentityResult> RemoveLoginAsync(int userId, ApplicationUserLoginInfo login);
        Task<ApplicationIdentityResult> RemovePasswordAsync(int userId);
        Task<ApplicationIdentityResult> RemoveUserFromRolesAsync(int userId, IList<string> roles);
        Task<ApplicationIdentityResult> ResetAccessFailedCountAsync(int userId);
        Task<ApplicationIdentityResult> ResetPasswordAsync(int userId, string token, string newPassword);
        Task SendEmailAsync(int userId, string subject, string body);
        Task SendSmsAsync(int userId, string message);
        Task SendSmsAsync(ApplicationMessage message);
        Task<bool> SendTwoFactorCodeAsync(string provider);
        Task<ApplicationIdentityResult> SetEmailAsync(int userId, string email);
        Task<ApplicationIdentityResult> SetLockoutEnabledAsync(int userId, bool enabled);
        ApplicationIdentityResult SetLockoutEnabled(int userId, bool enabled);
        Task<ApplicationIdentityResult> SetLockoutEndDateAsync(int userId, DateTimeOffset lockoutEnd);
        Task<ApplicationIdentityResult> SetPhoneNumberAsync(int userId, string phoneNumber);
        Task<ApplicationIdentityResult> SetTwoFactorEnabledAsync(int userId, bool enabled);
        Task<SignInStatus> SignInOrTwoFactor(ApplicationUser user, bool isPersistent);
        void SignIn(params ClaimsIdentity[] identities);
        void SignIn(bool isPersistent, params ClaimsIdentity[] identities);
        void SignIn(ApplicationUser user, bool isPersistent, bool rememberBrowser);
        Task SignInAsync(ApplicationUser user, bool isPersistent, bool rememberBrowser);
        void SignOut(params string[] authenticationTypes);
        Task<bool> TwoFactorBrowserRememberedAsync(int userId);
        Task<SignInStatus> TwoFactorSignInAsync(string provider, string code, bool isPersistent, bool rememberBrowser);
        Task<ApplicationIdentityResult> UpdateAsync(int userId);
        Task<ApplicationIdentityResult> UpdateSecurityStampAsync(int userId);
        IEnumerable<ApplicationUser> GetUsers();
        Task<IEnumerable<ApplicationUser>> GetUsersAsync();
        Task<bool> VerifyChangePhoneNumberTokenAsync(int userId, string token, string phoneNumber);
        Task<bool> VerifyTwoFactorTokenAsync(int userId, string twoFactorProvider, string token);
        Task<bool> VerifyUserTokenAsync(int userId, string purpose, string token);
        
    }
}