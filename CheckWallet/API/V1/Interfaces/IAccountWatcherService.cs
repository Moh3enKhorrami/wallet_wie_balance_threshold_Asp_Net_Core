using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckWallet.API.V1.Models;

namespace CheckWallet.API.V1.Interfaces
{
    public interface IAccountWatcherService
    {
        Task CreateAsync (AccountWatcher watcher);
        Task<AccountWatcher> GetByIdAsync(Guid id);
        Task<IEnumerable<AccountWatcher>> GetAllAsync();
        Task UpdateAsync(Guid id, AccountWatcher updates);
        Task DeleteAsync(Guid id); 
    }
}