using API_P1700;
using API_P1700.Interfaces;
using API_P1700.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicio del contenedor UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Creaci�n de una nueva instancia de la clase Startup, que se encarga de configurar la aplicaci�n
var startup = new Startup(builder.Configuration);

// Llamada al m�todo ConfigureServices de la clase Startup para configurar los servicios de la aplicaci�n
startup.ConfigureServices(builder.Services);

// Construcci�n de la aplicaci�n
var app = builder.Build();

// Llamada al m�todo Configure de la clase Startup para configurar la aplicaci�n y el entorno de ejecuci�n
startup.Configure(app, app.Environment);

// Ejecuci�n de la aplicaci�n
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
