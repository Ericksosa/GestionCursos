using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GestiondeCursos.Data;

// Inicializa el constructor de la aplicación web.
var builder = WebApplication.CreateBuilder(args);

// --- CONFIGURACIÓN DE BASE DE DATOS (EF CORE) ---
// Se registra el contexto de datos 'GestiondeCursosContext' en el contenedor de inyección de dependencias.
// Se configura para usar SQL Server obteniendo la cadena de conexión desde 'appsettings.json'.
// Si no se encuentra la cadena de conexión, se lanza una excepción para evitar errores silenciosos.
builder.Services.AddDbContext<GestiondeCursosContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GestiondeCursosContext")
    ?? throw new InvalidOperationException("Connection string 'GestiondeCursosContext' not found.")));

// --- SERVICIOS MVC ---
// Agrega los servicios necesarios para soportar controladores y vistas (Arquitectura Modelo-Vista-Controlador).
builder.Services.AddControllersWithViews();

// Construye la aplicación.
var app = builder.Build();

// --- CONFIGURACIÓN DEL PIPELINE DE SOLICITUDES HTTP ---

// Configuración para entornos que NO son de desarrollo (Producción).
if (!app.Environment.IsDevelopment())
{
    // Manejo global de excepciones: redirige a la vista de error.
    app.UseExceptionHandler("/Home/Error");
    // HSTS: Mejora la seguridad forzando conexiones HTTPS estrictas (recomendado para producción).
    app.UseHsts();
}

// Redirecciona automáticamente todas las solicitudes HTTP a HTTPS.
app.UseHttpsRedirection();

// Habilita el enrutamiento para mapear URLs a controladores.
app.UseRouting();

// Habilita la autorización (necesario si se agregan roles o login en el futuro).
app.UseAuthorization();

// Mapeo de archivos estáticos optimizados (CSS, JS, imágenes) en .NET 9.
app.MapStaticAssets();

// --- DEFINICIÓN DE RUTAS ---
// Define la ruta por defecto: Controlador "Home", Acción "Index".
// Ejemplo: Si entras a la raíz "/", te lleva a "HomeController.Index".
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// Ejecuta la aplicación.
app.Run();