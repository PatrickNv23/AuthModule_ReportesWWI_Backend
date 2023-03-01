using System.ComponentModel.DataAnnotations;

namespace webreportes_backend.ViewModels
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "El usuario es requerido")]
		[MaxLength(100, ErrorMessage = "El usuario debe tener una longitud máxima de 100 caracteres")]
		[MinLength(5, ErrorMessage = "El usuario tiene una longitud mínima de 5 caracteres")]
		[StringLength(100)]
		public string? User { get; set; }

		[Required(ErrorMessage = "La contraseña es requerida")]
		[MaxLength(100, ErrorMessage = "El nombre debe tener una longitud máxima de 100 caracteres")]
		[MinLength(6, ErrorMessage = "El nombre tiene una longitud mínima de 6 caracteres")]
		[StringLength(100)]
		public string? Password { get; set; }
	}
}
