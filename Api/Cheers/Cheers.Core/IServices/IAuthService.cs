using Cheers.Core.DTOs;
using Cheers.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheers.Core.IServices
{
   public interface IAuthService
    {
        //public Task<string> LoginAsync(string username, string password);
        //public Task<string> RegisterAsync(string username, string password);
        //string GenerateJwtToken(User user);
        //string HashPassword(string password);
        //bool VerifyPassword(string password, string storedHash);



        string GenerateToken(User user);
        Task<User> AuthenticateUser(LoginDTOs loginDto);
        Task<User> RegisterUser(RegisterDTOs registerDto);
        Task<User> GetUserById(int id);
        Task DeleteUser(int id);
    }
}
