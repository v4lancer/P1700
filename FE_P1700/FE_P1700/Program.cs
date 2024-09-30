using FE_P1700.DTOs;
using FE_P1700.Middleware;
using FE_P1700.RestAPIs;

var builder = WebApplication.CreateBuilder(args);

// Configura los valores de appsettings.json
builder.Services.Configure<P1700ApiSettingsDto>(builder.Configuration.GetSection("P1700API"));

// Registra como un servicio singleton
builder.Services.AddSingleton<UserAPI>();
builder.Services.AddSingleton<PerfilesAPI>();
builder.Services.AddSingleton<TiendasAPI>();
builder.Services.AddSingleton<EmpleadosAPI>();
builder.Services.AddSingleton<UsuariosAPI>();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(120);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseSession(); // Para variables de sesión

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Autenticar}/{id?}");

app.Run();
