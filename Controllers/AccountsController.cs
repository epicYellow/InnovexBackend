using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InnovexBackend;
using InnovexBackend.Models;
using System.Diagnostics;

namespace InnovexBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly Random _random = new Random();

        //public int GenerateUniqueAccountNumber(int id)
        //{
        //    int maxAttempts = 100;
        //    int attempts = 0;
        //    int randomAccountNumber;

        //    // Get all existing account numbers from your data source (replace this with your actual data retrieval method)
        //    List<int> existingAccountNumbers = GetAllAccountNumbersFromDatabase(id);

        //    do
        //    {
        //        // Generate a random 6-digit number
        //        randomAccountNumber = _random.Next(10000000, 100000000);

        //        // Check if the generated number is unique
        //        if (!existingAccountNumbers.Contains(randomAccountNumber))
        //        {
        //            // It's unique; you can use it
        //            return randomAccountNumber;
        //        }

        //        attempts++;

        //        // Add a maximum attempts limit to prevent infinite looping
        //        if (attempts >= maxAttempts)
        //        {
        //            throw new Exception("Unable to generate a unique account number after 100 attempts.");
        //        }
        //    } while (true);
        //}

        //private async Task<List<Accounts>> GetAllAccountNumbersFromDatabase(int id)
        //{
        //    // Simulate fetching existing account numbers from your database
        //    // You should implement this to retrieve data from your data source
        //    ActionResult<IEnumerable<Accounts>> accountsResult = await GetAccounts();
        //    Debug.WriteLine(accountsResult);
        //    return new Accounts;
        //    //List<Accounts> existingAccountNumbers = accountsResult;
        //    //return existingAccountNumbers;
        //}

        public AccountsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Accounts>>> GetAccounts()
        {
          if (_context.Accounts == null)
          {
              return NotFound();
          }
            return await _context.Accounts.ToListAsync();
        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Accounts>> GetAccounts(int id)
        {
          if (_context.Accounts == null)
          {
              return NotFound();
          }
            var accounts = await _context.Accounts.FindAsync(id);

            if (accounts == null)
            {
                return NotFound();
            }

            return accounts;
        }

        // PUT: api/Accounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccounts(int id, Accounts accounts)
        {
            if (id != accounts.Id)
            {
                Debug.WriteLine("Nope");
                return BadRequest();
            }

            _context.Entry(accounts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountsExists(id))
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

        // POST: api/Accounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Accounts>> PostAccounts(Accounts accounts)
        {
          if (_context.Accounts == null)
          {
              return Problem("Entity set 'AppDbContext.Accounts'  is null.");
          }
            _context.Accounts.Add(accounts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccounts", new { id = accounts.Id }, accounts);
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccounts(int id)
        {
            if (_context.Accounts == null)
            {
                return NotFound();
            }
            var accounts = await _context.Accounts.FindAsync(id);
            if (accounts == null)
            {
                return NotFound();
            }

            _context.Accounts.Remove(accounts);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccountsExists(int id)
        {
            return (_context.Accounts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
