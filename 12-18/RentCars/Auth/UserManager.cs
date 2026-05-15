using System.Threading.Tasks;

namespace RentCars
{
    public class UserManager    // передает вызовы в DatabaseHelper
    {
        public async Task<bool> RegisterAsync(string username, string password, string role)
        {
            return await DatabaseHelper.RegisterUserAsync(username, password, role);
        }

        public async Task<UserModel> AuthenticateAsync(string username, string password)
        {
            return await DatabaseHelper.AuthenticateUserAsync(username, password);
        }
    }
}