namespace BooKeeper.Web.Helpers
{
	using System.Linq;
	using System.Threading.Tasks;
	using BooKeeper.Web.Data.Entities;
	using Microsoft.AspNetCore.Identity;

	public class UserHelper : IUserHelper
	{

		private readonly UserManager<User> userManager;

		public UserHelper(UserManager<User> userManager)
		{
			this.userManager = userManager;
		}

		public User FindUsers()
		{
			return this.userManager.Users.FirstOrDefault();
		}

		public async Task<IdentityResult> AddUserAsync(User user, string password)
		{
			return await this.userManager.CreateAsync(user, password);
		}

		public async Task<User> GetUserByEmailAsync(string email)
		{
			var user = await this.userManager.FindByEmailAsync(email);
			return user;
		}
	}

}
