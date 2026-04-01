using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task1.Contexts;
using task1.Models;

namespace task1.Services
{
    public class UserService(AppDpContext context)
    {
        private AppDpContext _context = context;

        public List<User>? GetUsers()
            => _context.Users.ToList();

        public async Task<User?> GetUserByIdAsync(int id)
        {
            var result = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return (result is null) ? null : result;
        }

        public async Task<User> InsertUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await GetUserByIdAsync(id);

            if (user is null)
                return;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
