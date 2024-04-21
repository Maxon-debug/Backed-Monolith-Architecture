using MaxonEventManagement.Models;

namespace MaxonEventManagement.Services.IService
{
    public interface IJwt
    {
        string GenerateToken(User user);
    }
}
