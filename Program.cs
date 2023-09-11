using BlogDapper.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


/* Por cada uno de los repositorio  se a�ade como inyecci�n de dependencias los repositorios*/
builder.Services.AddScoped<ICategoria, CategoriaImple>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{area=Front}/{controller=Inicio}/{action=Index}/{id?}"); // ac� indicamos por donde inciara la aplicaion

app.Run();
