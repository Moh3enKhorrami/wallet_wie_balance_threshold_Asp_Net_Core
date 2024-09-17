using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheckWallet.API.V1.Models
{
    public class AccountWatcher
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string ChainId { get; set; }
        public string ChainName { get; set; }
        public Guid WatchSettingsId { get; set; }
        public WatcherSettings WatcherSettings { get; set; }
        public DateTime CreateTs { get; set; }
        public DateTime LastUpdateTs { get; set; }
    }
}