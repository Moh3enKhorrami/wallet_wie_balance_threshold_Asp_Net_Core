using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckWallet.API.V1.Models;

namespace CheckWallet.API.V1.Interfaces
{
    public interface IWatcherSettingsService
    {
        Task CreateAsync (WatcherSettings settings);
        Task<WatcherSettings> GetByIdAsync(Guid id);
        Task<IEnumerable<WatcherSettings>> GetAllAsync();
        Task UpdateAsync(Guid id, WatcherSettings updates);
        Task DeleteAsync(Guid id); 
    }
}