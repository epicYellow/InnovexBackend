using InnovexBackend.Models;
using Isopoh.Cryptography.Argon2;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnovexBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        // Post request to check if user is authenticated
        [HttpPost("login")]
        public IActionResult Login(StaffModel staff)
        {
            var IsAuthenticated = ValidateUserCredentials(staff.Email, staff.Password);

            if (IsAuthenticated)
            {
                // Generate a Valid Token
                return Ok(new { Token = "Good Job" });
            } 
            
            return Unauthorized();
            
        }

        private bool ValidateUserCredentials(string email, string password)
        {
            // TODO: Check Validation
            // First: Check if the user is valid
            var staff = _context.Staff.FirstOrDefault(s =>s.Email == email);

            if (staff != null) {
                // Verify if password is correct
                if (Argon2.Verify(staff.Password, password))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
