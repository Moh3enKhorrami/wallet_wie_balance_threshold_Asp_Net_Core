using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckWallet.API.V1.Interfaces;

namespace CheckWallet.BalanceCheck
{ 
    public class BalanceCheckerBackgroundService : BackgroundService
    {
        private readonly IAccountWatcherService _accountWatcherService;
        private readonly ILogger<BalanceCheckerBackgroundService> _logger;
        private readonly TimeSpan _checkInterval = TimeSpan.FromMinutes(1);

        public BalanceCheckerBackgroundService(IAccountWatcherService accountWatcherService, ILogger<BalanceCheckerBackgroundService> logger)
        {
            _accountWatcherService = accountWatcherService;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Checking balances...");
                // Implement the balance checking logic here
                await Task.Delay(_checkInterval, stoppingToken);
            }
        }
    }
}