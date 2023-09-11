using BlogDapper.Models;
using Dapper;
using MySqlConnector;

namespace BlogDapper.Interfaces
{
	public class CategoriaImple : ICategoria
	{
		private readonly MySqlConnection _bd ;

		public CategoriaImple(IConfiguration configuracion)
		{
			try
			{
				//_bd = new MySqlConnection(configuracion.GetConnectionString("ConnectionString", "ConexionMySQL"));
				_bd = new MySqlConnection("Server=localhost;Port=3306;Database=blogdapper; Uid=root;Pwd=;");
			}
			catch (MySqlException err)
			{
				Console.WriteLine(err.ToString());	
		    }


			
		}

		public Categoria ActualizarCategori(Categoria categoria)
		{
			string sql = "UPDATE categoria SET nombre=@nombre_ WHERE idCategoria = @id_categoria_";
			_bd.Execute(sql, new
			{
				nombre_ = categoria.nombre,
				id_categoria_ = categoria.idCategoria
			});
			return categoria;
		}

		public void BorrarCategoria(int id)
		{
			string sql = "DELETE FROM categoria WHERE idCategoria=@id_categoria;";
			_bd.Execute(sql, new { id_categoria = id});
		}

		public Categoria CrearCAtegroria(Categoria categoria)
		{
			string sql = "INSERT INTO categoria(nombre,fechaCreacion) VALUES (@nombre_,@fechaCreacion_);";
			_bd.Execute(sql, new {
				nombre_=categoria.nombre,
				fechaCreacion_ = DateTime.Now
			});
			return categoria;
		}

		public Categoria GetCategoria(int id)
		{
			string sql = "SELECT * FROM categoria WHERE idCategoria=@id_categoria;";
			return (_bd.Query<Categoria>(sql, new { id_categoria = id }).Single());
		}

		public List<Categoria> GetCategorias()
		{
			string sql = "SELECT * FROM categoria;";
			return (_bd.Query<Categoria>(sql).ToList());
		}
	}
}
