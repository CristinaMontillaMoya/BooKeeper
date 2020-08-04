namespace BooKeeper.Web.Helpers
{
    using BooKeeper.Web.Data.Entities;
    using BooKeeper.Web.Models;
    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;

    public interface IUserHelper
    {
        User FindUsers();
 
        Task<User> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();

        Task<IdentityResult> UpdateUserAsync(User user);

        Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword);


    }

}
