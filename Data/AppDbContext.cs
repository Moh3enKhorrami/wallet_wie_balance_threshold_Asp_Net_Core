using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckWallet.API.V1.Models;
using Microsoft.EntityFrameworkCore;

namespace CheckWallet.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){

        }
        public DbSet<AccountWatcher> AccountWatchers { get; set; }
        public DbSet<WatcherSettings> WatcherSettings{ get; set; }
    }
}