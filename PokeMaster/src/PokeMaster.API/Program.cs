using System.Reflection;
using PokeMaster.Application;
using PokeMaster.Application.Queries.Handlers;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

var services = builder.Services;
services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(typeof(Program).GetTypeInfo().Assembly);
    cfg.RegisterServicesFromAssemblies(typeof(GetPokemonByIdQueryHandler).Assembly);
});

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
var conn = builder.Configuration.GetConnectionString("DefaultConnection");
services.AddDataContext(conn);
services.AddRepositories();
services.AddServices();

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
