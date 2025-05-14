using Lab08_RQuispe.Data;
using Lab08_RQuispe.Data.UnitOfWork;
using Lab08_RQuispe.Services.Implements;
using Lab08_RQuispe.Services.interfaces;
using Lab08_RQuispe.Services.Interfaces;
using Lab08_RQuispe.Services.Productos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//Add Services
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IClienteBusquedaService, ClienteBusquedaService>();
builder.Services.AddScoped<IProductoFiltroService, ProductoFiltroService>();
builder.Services.AddScoped<IOrdenDetalleConsultaService, OrdenDetalleConsultaService>();
builder.Services.AddScoped<IOrdenCantidadTotalService, OrdenCantidadTotalService>();
builder.Services.AddScoped<IProductoMasCaroService, ProductoMasCaroService>();
builder.Services.AddScoped<IPedidosPorFechaService, PedidosPorFechaService>();
builder.Services.AddScoped<IPrecioPromedioProductoService, PrecioPromedioProductoService>();
builder.Services.AddScoped<IProductosSinDescripcionService, ProductosSinDescripcionService>();
builder.Services.AddScoped<IClienteMayorPedidosService, ClienteMayorPedidosService>();
builder.Services.AddScoped<IPedidosConDetallesService, PedidosConDetallesService>();
builder.Services.AddScoped<IProductosPorClienteService, ProductosPorClienteService>();
builder.Services.AddScoped<IClientesPorProductoService, ClientesPorProductoService>();




// 🔌 Obtener la cadena de conexión desde appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 💾 Configurar EF Core con Pomelo
builder.Services.AddDbContext<Lab08Context>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// 🔧 Agregar soporte para controladores
builder.Services.AddControllers();

// 📘 Configurar Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 🚀 Middleware de Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// 🔀 Mapear controladores
app.MapControllers();

app.Run();