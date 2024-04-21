using MaxonEventManagement.Data;
using MaxonEventManagement.Models;
using MaxonEventManagement.Services.IService;

namespace MaxonEventManagement.Services
{
    public class UserService : IUser
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public User GetUserByEmail(string email)
        {
           return _context.Users.Where(x=>x.Email.ToLower() == email.ToLower()).FirstOrDefault();
        }

        public string RegisterUser(User user)
        {
           _context.Users.Add(user);
            _context.SaveChanges();
            return "User registered Successifully";
        }
    }
}
