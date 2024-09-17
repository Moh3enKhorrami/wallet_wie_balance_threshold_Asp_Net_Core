using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckWallet.API.V1.Interfaces;
using CheckWallet.API.V1.Models;
using CheckWallet.Data;
using Microsoft.EntityFrameworkCore;

namespace CheckWallet.API.V1.Services
{
    public class AccountWatcherService : IAccountWatcherService
    {
        private readonly AppDbContext _dbContext;

        public AccountWatcherService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(AccountWatcher watcher)
        {
            await _dbContext.AccountWatchers.AddAsync(watcher);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var watcher = await _dbContext.AccountWatchers.FindAsync(id);
            if (watcher != null)
            {
                _dbContext.AccountWatchers.Remove(watcher);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<AccountWatcher>> GetAllAsync()
        {
            return await _dbContext.AccountWatchers
            .Include( x => x.WatcherSettings)
            .ToListAsync();
        }

        public async Task<AccountWatcher> GetByIdAsync(Guid id)
        {
            return await _dbContext.AccountWatchers
            .Include( x => x.WatcherSettings)
            .FirstOrDefaultAsync( x => x.Id == id);
        }

        public async Task UpdateAsync(Guid id, AccountWatcher updates)
        {
            var watcher = await _dbContext.AccountWatchers.FindAsync(id);
            if (watcher != null)
            {
                _dbContext.Entry(watcher).CurrentValues.SetValues(updates);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}