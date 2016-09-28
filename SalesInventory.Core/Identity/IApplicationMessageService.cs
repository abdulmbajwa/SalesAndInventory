using System.Threading.Tasks;
using SalesInventory.Core.DomainModels.Identity;

namespace SalesInventory.Core.Identity
{
    public interface IApplicationMessageService
    {
        Task SendAsync(ApplicationMessage message);
    }
}
