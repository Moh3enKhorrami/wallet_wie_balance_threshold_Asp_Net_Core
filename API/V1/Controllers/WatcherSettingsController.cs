using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CheckWallet.API.V1.Interfaces;
using CheckWallet.API.V1.Models;
using Microsoft.AspNetCore.Mvc;

namespace CheckWallet.API.V1.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class WatcherSettingsController : ControllerBase
    {
        private readonly IWatcherSettingsService _watcherSettingsService;

        public WatcherSettingsController(IWatcherSettingsService watcherSettingsService)
        {
            _watcherSettingsService = watcherSettingsService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] WatcherSettings settings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _watcherSettingsService.CreateAsync(settings);
            return CreatedAtAction(nameof(GetById), new { id = settings.Id }, settings);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WatcherSettings>>> GetAll()
        {
            var settings = await _watcherSettingsService.GetAllAsync();
            return Ok(settings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WatcherSettings>> GetById(Guid id)
        {
            var setting = await _watcherSettingsService.GetByIdAsync(id);
            if (setting == null)
            {
                return NotFound();
            }

            return Ok(setting);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] WatcherSettings updates)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingSetting = await _watcherSettingsService.GetByIdAsync(id);
            if (existingSetting == null)
            {
                return NotFound();
            }

            await _watcherSettingsService.UpdateAsync(id, updates);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var setting = await _watcherSettingsService.GetByIdAsync(id);
            if (setting == null)
            {
                return NotFound();
            }

            await _watcherSettingsService.DeleteAsync(id);
            return NoContent();
        }
    }
}