using API_P1700;
using API_P1700.Interfaces;
using API_P1700.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicio del contenedor UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Creación de una nueva instancia de la clase Startup, que se encarga de configurar la aplicación
var startup = new Startup(builder.Configuration);

// Llamada al método ConfigureServices de la clase Startup para configurar los servicios de la aplicación
startup.ConfigureServices(builder.Services);

// Construcción de la aplicación
var app = builder.Build();

// Llamada al método Configure de la clase Startup para configurar la aplicación y el entorno de ejecución
startup.Configure(app, app.Environment);

// Ejecución de la aplicación
app.Run();

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
