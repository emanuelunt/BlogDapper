using System.ComponentModel.DataAnnotations;

namespace BlogDapper.Models
{
	public class Categoria
	{
		[Key]
		public int idCategoria { get; set;}

		[Required(ErrorMessage ="El nombre para la categoria es obligatorio")]
		public string nombre { get; set;}	
		public DateTime fechaCreacion { get; set;}	


	}
}
