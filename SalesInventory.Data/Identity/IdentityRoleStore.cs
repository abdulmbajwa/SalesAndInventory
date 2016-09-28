using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using SalesInventory.Data.Identity.Models;

namespace SalesInventory.Data.Identity
{
    class IdentityRoleStore : IRoleStore<ApplicationIdentityRole, int>
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(ApplicationIdentityRole role)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ApplicationIdentityRole role)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ApplicationIdentityRole role)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationIdentityRole> FindByIdAsync(int roleId)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationIdentityRole> FindByNameAsync(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
