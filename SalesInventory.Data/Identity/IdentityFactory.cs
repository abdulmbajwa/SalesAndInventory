using System;
using Microsoft.AspNet.Identity;
using SalesInventory.Data.Identity.Models;

namespace SalesInventory.Data.Identity
{
    public class IdentityFactory
    {
        public static UserManager<ApplicationIdentityUser, int> CreateUserManager(IUserStore<ApplicationIdentityUser,int> userStore)
        {
            var manager = new UserManager<ApplicationIdentityUser, int>(userStore);
            // Configure validation logic for usernames
            manager.UserValidator = new  UserValidator<ApplicationIdentityUser, int>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = false
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };
            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;
            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug in here.
            manager.RegisterTwoFactorProvider("PhoneCode", new PhoneNumberTokenProvider<ApplicationIdentityUser, int>
            {
                MessageFormat = "Your security code is: {0}"
            });
            manager.RegisterTwoFactorProvider("EmailCode", new EmailTokenProvider<ApplicationIdentityUser, int>
            {
                Subject = "SecurityCode",
                BodyFormat = "Your security code is {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            return manager;
        }

        public static RoleManager<ApplicationIdentityRole, int> CreateRoleManager(IRoleStore<ApplicationIdentityRole, int> roleStore)
        {
            return new RoleManager<ApplicationIdentityRole, int>(roleStore);
        }
    }
}
