using MaxonEventManagement.Models;

namespace MaxonEventManagement.Services.IService
{
    public interface IUser
    {
        public User GetUserByEmail(string email);
        public string RegisterUser(User user);

    }
}
