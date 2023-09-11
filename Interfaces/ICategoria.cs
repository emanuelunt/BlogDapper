using BlogDapper.Models;

namespace BlogDapper.Interfaces
{
	public interface ICategoria
	{
		Categoria GetCategoria(int id);
		List<Categoria> GetCategorias();
		Categoria CrearCAtegroria(Categoria categoria);
		Categoria ActualizarCategori(Categoria categoria);
		void BorrarCategoria(int id);
	}
}
