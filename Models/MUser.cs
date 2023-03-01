using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webreportes_backend.Models
{
	public class MUser
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key, Column(Order = 0)]
		public int Id { get; set; }

		[Required(ErrorMessage = "El nombre es requerido")]
		[MaxLength(100, ErrorMessage = "El nombre debe tener una longitud máxima de 100 caracteres")]
		[MinLength(2, ErrorMessage = "El nombre tiene una longitud mínima de 2 caracteres")]
		[StringLength(100)]
		public string? Name { get; set; }

		[Required(ErrorMessage = "El apellido es requerido")]
		[MaxLength(100, ErrorMessage = "El apellido debe tener una longitud máxima de 100 caracteres")]
		[MinLength(2, ErrorMessage = "El apellido tiene una longitud mínima de 2 caracteres")]
		[StringLength(100)]
		public string? Surname { get; set; }

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

		[Required(ErrorMessage = "El email es requerido")]
		[DataType(DataType.EmailAddress)]
		[EmailAddress]
		public string? Email { get; set; }
	}
}
