using Lab08_RQuispe.Application.Services.Interfaces;
using Lab08_RQuispe.Data;
using Lab08_RQuispe.Data.UnitOfWork;
using Lab08_RQuispe.Services.Implements;
using Lab08_RQuispe.Services.interfaces;
using Lab08_RQuispe.Services.Interfaces;
using Lab08_RQuispe.Services.Productos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 🔌 Inyectar servicios
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
builder.Services.AddScoped<IClientOrderService, ClientOrderService>();
builder.Services.AddScoped<IOrderDetailsService, OrderDetailsService>();
builder.Services.AddScoped<IClientProductCountService, ClientProductCountService>();
builder.Services.AddScoped<ISalesByClientService, SalesByClientService>();


// ✅ Usar solo UNA instancia de AddDbContext
builder.Services.AddDbContext<Lab08Context>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));


// 📘 Configurar servicios básicos de la API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Console.WriteLine($"Cadena de conexión: {builder.Configuration.GetConnectionString("DefaultConnection")}");

var app = builder.Build();

// 🚀 Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
