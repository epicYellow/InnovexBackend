using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InnovexBackend;
using InnovexBackend.Models;

namespace InnovexBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTypesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AccountTypesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/AccountTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountTypes>>> GetAccountTypes()
        {
          if (_context.AccountTypes == null)
          {
              return NotFound();
          }
            return await _context.AccountTypes.ToListAsync();
        }

        // GET: api/AccountTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountTypes>> GetAccountTypes(int id)
        {
          if (_context.AccountTypes == null)
          {
              return NotFound();
          }
            var accountTypes = await _context.AccountTypes.FindAsync(id);

            if (accountTypes == null)
            {
                return NotFound();
            }

            return accountTypes;
        }

        // PUT: api/AccountTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountTypes(int id, AccountTypes accountTypes)
        {
            if (id != accountTypes.Id)
            {
                return BadRequest();
            }

            _context.Entry(accountTypes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountTypesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AccountTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AccountTypes>> PostAccountTypes(AccountTypes accountTypes)
        {
          if (_context.AccountTypes == null)
          {
              return Problem("Entity set 'AppDbContext.AccountTypes'  is null.");
          }
            _context.AccountTypes.Add(accountTypes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccountTypes", new { id = accountTypes.Id }, accountTypes);
        }

        // DELETE: api/AccountTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccountTypes(int id)
        {
            if (_context.AccountTypes == null)
            {
                return NotFound();
            }
            var accountTypes = await _context.AccountTypes.FindAsync(id);
            if (accountTypes == null)
            {
                return NotFound();
            }

            _context.AccountTypes.Remove(accountTypes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccountTypesExists(int id)
        {
            return (_context.AccountTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
