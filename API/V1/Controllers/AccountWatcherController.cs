using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckWallet.API.V1.Interfaces;
using CheckWallet.API.V1.Models;
using Microsoft.AspNetCore.Mvc;

namespace CheckWallet.API.V1.Controllers
{
    
    [Route("api/v1/account-watcher")]
    [ApiController]
    public class AccountWatcherController : ControllerBase
    {
        private readonly IAccountWatcherService _service;

        public AccountWatcherController(IAccountWatcherService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccountWatcher([FromBody] AccountWatcher watcher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ErrorResponse { Error = "Invalid model state" });
            }

            await _service.CreateAsync(watcher);
            return Ok(watcher);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountWatcherById(Guid id)
        {
            var watcher = await _service.GetByIdAsync(id);
            if (watcher == null)
            {
                return NotFound(new ErrorResponse { Error = "AccountWatcher not found" });
            }
            return Ok(watcher);
        }

        [HttpGet]
        public async Task<IActionResult> GetAccountWatchers()
        {
            var watchers = await _service.GetAllAsync();
            return Ok(watchers);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccountWatcher(Guid id, [FromBody] AccountWatcher updates)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ErrorResponse { Error = "Invalid JSON format" });
            }

            await _service.UpdateAsync(id, updates);
            return Ok(updates);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccountWatcherById(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}