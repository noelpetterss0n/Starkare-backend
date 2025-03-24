using System.Threading.Tasks;
using starkare_backend.Models;

namespace starkare_backend.Services
{
    public interface IUserService
    {
        Task<AuthResponse> RegisterAsync(RegisterDto registerDto);
        //Task<AuthResponse> LoginAsync(LoginDto loginDto); // Update login similarly if needed
    }
}
