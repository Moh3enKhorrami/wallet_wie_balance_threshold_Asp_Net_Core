using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheckWallet.API.V1.Models
{
    public class WatcherSettings
    {
        [Key]
        public Guid Id { get; set; }
        public string ChainId { get; set; }
        public string ChainName { get; set; }
        public string RpcUrl { get; set; }
        public int CheckIntervalMsecs { get; set; }
        public long WeiBalanceThreshold { get; set; }
        public bool Active { get; set; }
        public bool Default { get; set; }
        public DateTime CreateTs { get; set; }
        public DateTime LastUpdateTs { get; set; }
    }
}