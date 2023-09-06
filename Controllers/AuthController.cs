using InnovexBackend.Models;
using Isopoh.Cryptography.Argon2;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
        public IActionResult Login(Staff staff)
        {
            var IsAuthenticated = ValidateUserCredentials(staff.Email, staff.Password);

            if (IsAuthenticated.IsAuthenticated)
            {
                var UserId = IsAuthenticated.UserId.ToString();
                // Return the UserId along with the Token
                return Ok(new { Token = "Good Job",UserId });
            }

            return Unauthorized();
        }

        private (bool IsAuthenticated, int UserId) ValidateUserCredentials(string email, string password)
        {
            // TODO: Check Validation
            // First: Check if the user is valid
            var staff = _context.Staff.FirstOrDefault(s => s.Email == email);
            Debug.WriteLine(staff.Email);

            if (staff != null)
            {
                // Verify if password is correct
                if (Argon2.Verify(staff.Password, password))
                {
                    Debug.WriteLine("This is a user");
                    // Authentication is successful, return the user ID
                    return (true, staff.Id);
                }
            }

            // Authentication failed, return -1 as the user ID
            return (false, -1);
        }

    }
}
