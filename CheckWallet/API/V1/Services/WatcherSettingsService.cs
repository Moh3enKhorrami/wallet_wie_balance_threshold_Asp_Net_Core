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
    public class WatcherSettingsService : IWatcherSettingsService
    {
        private readonly AppDbContext _dbContext;

        public WatcherSettingsService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(WatcherSettings settings)
        {
            await _dbContext.WatcherSettings.AddAsync(settings);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var setting = await _dbContext.WatcherSettings.FindAsync(id);
            if (setting != null)
            {
                _dbContext.WatcherSettings.Remove(setting);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<WatcherSettings>> GetAllAsync()
        {
            return await _dbContext.WatcherSettings.ToListAsync();
        }

        public async Task<WatcherSettings> GetByIdAsync(Guid id)
        {
            return await _dbContext.WatcherSettings.FindAsync(id);
        }

        public async Task UpdateAsync(Guid id, WatcherSettings updates)
        {
            var existingSetting = await _dbContext.WatcherSettings.FindAsync(id);
            if (existingSetting != null)
            {
                _dbContext.Entry(existingSetting).CurrentValues.SetValues(updates);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}