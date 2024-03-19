using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using CrudApiProject.Data;
using CrudApiProject.Models;

namespace CrudApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly api_demo_db_class _context;

        public AuthController(api_demo_db_class context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(users user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _context.users.AnyAsync(u => u.username == user.username))
            {
                ModelState.AddModelError("Username", "Username is already taken");
                return BadRequest(ModelState);
            }

            // Hash the password before saving
            user.password = HashPassword(user.password);

            _context.users.Add(user);
            await _context.SaveChangesAsync();

            return Ok("User registered successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(user_login_model model)
        {
            var user = await _context.users.FirstOrDefaultAsync(u => u.username == model.username);

            if (user == null || !VerifyPassword(model.password, user.password))
            {
                ModelState.AddModelError("InvalidCredentials", "Invalid username or password");
                return BadRequest(ModelState);
            }

            
            var role = user.role;

          
            var token = GenerateJwtToken(user.id, role);

            return Ok(new { Token = token });
        }

        private string GenerateJwtToken(int userId, string role)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Role, role),
               
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-secret-key-with-at-least-256-bits"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddHours(1); 

            var token = new JwtSecurityToken(
                issuer: "http://localhost",
                audience: "http://localhost:7120",
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private bool VerifyPassword(string inputPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(inputPassword, hashedPassword);
        }
    }
}
