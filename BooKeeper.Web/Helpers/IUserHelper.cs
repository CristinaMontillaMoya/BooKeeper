using BooKeeper.Web.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BooKeeper.Web.Helpers
{
    public interface IUserHelper
    {
        User FindUsers();

        Task<User> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);
    }

}
