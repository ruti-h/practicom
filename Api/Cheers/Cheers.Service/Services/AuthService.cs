using Cheers.Core.Entities;
using Cheers.Data;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Cheers.Service.Services
{
    public class AuthService
    {
        private readonly DataContext _context;
        private readonly string _secretKey; // מפתח סודי
        private readonly string _issuer; // המנפיק
        private readonly string _audience; // הקהל
        public AuthService(DataContext context)
        {
            _context = context;
            _secretKey = "YourSuperSecretKey"; // יש להחליף למפתח סודי אמיתי
            _issuer = "YourIssuer"; // המנפיק
            _audience = "YourAudience"; // הקהל
        }

        public void RegisterUser(User user)
        {
            // בדוק אם המשתמש כבר קיים
            if (_context.Users.Any(u => u.Email == user.Email))
            {
                throw new Exception("User already exists.");
            }

            // הוסף את המשתמש לבסיס הנתונים
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public string GenerateJwtToken(User user)
        {
            var claims = new[]
       {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            // יצירת מפתח סודי
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // יצירת טוקן
            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30), // תוקף הטוקן
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token); // החזרת הטוקן
        }
    }
}
