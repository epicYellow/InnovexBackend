using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InnovexBackend;
using InnovexBackend.Models;
using Isopoh.Cryptography.Argon2;

namespace InnovexBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    public class StaffModelsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StaffModelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/StaffModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staff>>> GetStaff()
        {
          if (_context.Staff == null)
          {
              return NotFound();
          }
            return await _context.Staff.ToListAsync();
        }

        // GET: api/StaffModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Staff>> GetStaffModel(int id)
        {
          if (_context.Staff == null)
          {
              return NotFound();
          }
            var staffModel = await _context.Staff.FindAsync(id);

            if (staffModel == null)
            {
                return NotFound();
            }

            return staffModel;
        }

        // PUT: api/StaffModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaffModel(int id, Staff staffModel)
        {
            if (id != staffModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(staffModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffModelExists(id))
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

        // POST: api/StaffModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Staff>> PostStaffModel(Staff staffModel)
        {
            if (_context.Staff == null)
            {
                return Problem("Entity set 'AppDbContext.Staff'  is null.");
            }

            // Hashes the user password
            staffModel.Password = Argon2.Hash(staffModel.Password);
            _context.Staff.Add(staffModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStaffModel", new { id = staffModel.Id }, staffModel);
        }

        // DELETE: api/StaffModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaffModel(int id)
        {
            if (_context.Staff == null)
            {
                return NotFound();
            }
            var staffModel = await _context.Staff.FindAsync(id);
            if (staffModel == null)
            {
                return NotFound();
            }

            _context.Staff.Remove(staffModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StaffModelExists(int id)
        {
            return (_context.Staff?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
