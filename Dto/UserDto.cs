using Microsoft.EntityFrameworkCore;
using webreportes_backend.Context;
using webreportes_backend.Models;

namespace webreportes_backend.Dto
{
	public class UserDto
	{
		public async Task<List<MUser>> GetUsers(UserContext context)
		{
			List<MUser> users = new List<MUser>();
			users = await context.Users.ToListAsync();
			return users;
		}


		public async Task RegisterUser(MUser newUser, UserContext context)
		{
			context.Users.Add(newUser);
			await context.SaveChangesAsync();
		}


		public async Task<MUser> GetUserById(int id, UserContext context)
		{
			MUser userById = new MUser();
			if (await context.Users.FindAsync(id) is MUser user)
			{
				userById = user;
			}
			return userById;
		}

		public async Task<MUser> GetUserByCredentials(MUser user, UserContext context)
		{
			MUser userByCredentials = new MUser();
			var userAux = await context.Users.FirstOrDefaultAsync(x => x.User == user.User && x.Password == user.Password);
			if ( userAux is MUser userLogin && userAux != null)
			{
				userByCredentials = userAux;
			}
			else
			{
				userByCredentials = null;
			}
			return userByCredentials;
		}
	}
}
