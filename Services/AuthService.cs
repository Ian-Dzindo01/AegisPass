using AegisPass.Models;
using System.Linq;

namespace AegisPass.Services
{
    public class AuthService
    {
        private readonly AppDbContext _db = new();

        public bool Register(string email, string password)
        {
            if (_db.Users.Any(u => u.Email == email))
                return false;

            var hash = BCrypt.Net.BCrypt.HashPassword(password);

            _db.Users.Add(new User
            {
                Email = email,
                PasswordHash = hash
            });

            _db.SaveChanges();
            return true;
        }

        public bool Login(string email, string password)
        {
            var user = _db.Users.FirstOrDefault(u => u.Email == email);
            if (user == null) return false;

            return BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
        }
    }
}
