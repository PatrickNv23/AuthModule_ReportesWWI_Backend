using Microsoft.AspNetCore.Mvc;
using webreportes_backend.Context;
using webreportes_backend.Dto;
using webreportes_backend.Filters;
using webreportes_backend.Models;
using webreportes_backend.ViewModels;

namespace webreportes_backend.Controllers
{
	[ApiController]
	[Route("api/users")]
	public class UserController : ControllerBase
	{
		private readonly UserContext _context;

		public UserController(UserContext context)
		{
			// inyección de dependencias, cuando agregamos el context a los services en Program.cs
			_context = context;
		}


		[HttpGet]
		public async Task<ActionResult<List<MUser>>> GetUsers()
		{
			UserDto dtoUser = new();
			List<MUser> users = await dtoUser.GetUsers(_context);
			return users;
		}


		[HttpPost("register")]
		[ServiceFilter(typeof(ValidationFilter))]
		public async Task<IActionResult> PostUser([FromBody] MUser user)
		{
			UserDto dtoUser = new();
			await dtoUser.RegisterUser(user, _context);
			return Ok(user);
		}


		[HttpGet("{Id}")]
		public async Task<IActionResult> GetUserById(int Id)
		{
			UserDto dtoUser = new();
			MUser user = new()
			{
				Id = Id
			};
			MUser userById = await dtoUser.GetUserById(user.Id, _context);
			if (userById == null)
			{
				NotFound();
			}
			return Ok(userById);
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginViewModel loginViewModel)
		{
			var userLogin = new MUser
			{
				User = loginViewModel.User,
				Password = loginViewModel.Password,
			};
			UserDto dtoUser = new();
			MUser user = await dtoUser.GetUserByCredentials(userLogin, _context);
			if (user == null)
			{
				return NotFound();
			}
			return Ok(user);
		}
	}
}
