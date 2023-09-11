using BlogDapper.Interfaces;
using BlogDapper.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogDapper.Areas.Admin.Controllers
{
	[Area("Admin")] // le indicamos al controlador a que area pertenese
	public class CategoriasController : Controller
	{

		private readonly ICategoria _repoCategoria;


		public CategoriasController(ICategoria repoCategoria)
		{
			_repoCategoria = repoCategoria;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}


		[HttpGet]
		public IActionResult Crear()
		{
			return View();
		}


		[HttpPost]
		[ValidateAntiForgeryToken] // colocar esta propiedad simpre para los post
		public IActionResult Crear(Categoria categoria)
		{
			if (ModelState.IsValid)
			{
				_repoCategoria.CrearCAtegroria(categoria);
				return RedirectToAction(nameof(Index));
			}

			return View(categoria);
		}		


		[HttpGet]
		public IActionResult Editar( int? id)
		{
			if (id == null)
			{
				return NotFound();	
			}

			var categoria = _repoCategoria.GetCategoria(id.GetValueOrDefault());
			if (categoria == null)
			{
				return NotFound();
			}

			return View(categoria);
		}

		[HttpPost]
		[ValidateAntiForgeryToken] // colocar esta propiedad simpre para los post
		public IActionResult Editar(int id,Categoria categoria)
		{
			if (id != categoria.idCategoria)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				_repoCategoria.ActualizarCategori(categoria);
				return RedirectToAction(nameof(Index));
			}

			return View(categoria);
		}






		#region
		[HttpGet]
		public IActionResult GetCategorias() 
		{ 
			return Json(new { data = _repoCategoria.GetCategorias() });	
		}

		[HttpDelete]
		public IActionResult BorrarCategoria(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			else
			{
				_repoCategoria.BorrarCategoria(id.GetValueOrDefault());
				return Json(new { success = true, message = "Categoría borrada correctamente" });
			}
		}

		#endregion




	}
}
