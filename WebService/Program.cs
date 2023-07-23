using MySql.Data.MySqlClient;
using WebServiceData1;
using WebServiceData1.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var MYSQLConfiguration = new MYSQLConfiguration(builder.Configuration.GetConnectionString("MySqlConnection"));
builder.Services.AddSingleton(MYSQLConfiguration);

builder.Services.AddSingleton(new MySqlConnection(builder.Configuration.GetConnectionString("MySqlConnection")));

//Web Service de Tasa
builder.Services.AddScoped<ITasaRepository, TasaRepository>();

//Web Service de Inflacion
builder.Services.AddScoped<IInflacionRepository, InflacionRepository>();

//Web service de Salud Financiera
builder.Services.AddScoped<ISaludRepository, SaludRepository>();

//Web service de Historial Crediticio
builder.Services.AddScoped<IHistorialRepository, HistorialRepository>();

//Web service de Registro
builder.Services.AddScoped<IRegistroRepository, RegistroRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
