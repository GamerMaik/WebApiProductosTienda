using DAL;
using DAL.Interfaces;
using DAL.Repositories;

using LN.Interfaces;
using LN.Services;

using Microsoft.EntityFrameworkCore;

// Crear el constructor de la aplicaci�n web.
var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor de dependencias.
builder.Services.AddControllers();

// Agregar configuraci�n de Swagger/OpenAPI para la documentaci�n de la API.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Obtener la cadena de conexi�n desde la configuraci�n.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configurar el contexto de base de datos con Entity Framework Core.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
	options.UseSqlServer(connectionString);
});

// Registrar los servicios necesarios en el contenedor de dependencias.
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Construir la aplicaci�n.
var app = builder.Build();

// Configurar la canalizaci�n de solicitudes HTTP.
if (app.Environment.IsDevelopment())
{
	// Habilitar Swagger en el entorno de desarrollo para la documentaci�n.
	app.UseSwagger();
	app.UseSwaggerUI();

	// Mostrar una p�gina de excepciones detalladas en desarrollo.
	app.UseDeveloperExceptionPage();
}

// Redireccionar las solicitudes HTTP a trav�s de HTTPS.
app.UseHttpsRedirection();

// Habilitar la autorizaci�n.
app.UseAuthorization();

// Mapear las rutas de controladores.
app.MapControllers();

// Iniciar la aplicaci�n.
app.Run();
