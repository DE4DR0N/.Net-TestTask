using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;

namespace TestTask.Services.Interfaces
{
    public interface IUserService
    {
        public Task<User> GetUser();

        public Task<List<User>> GetUsers();
    }

    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<User> GetUser()
        {
            return _context.Users.OrderByDescending(x => x.Orders.Count).FirstOrDefaultAsync();
        }

        public Task<List<User>> GetUsers()
        {
            return _context.Users.Where(x => x.Status == Enums.UserStatus.Inactive).ToListAsync();
        }
    }
}
