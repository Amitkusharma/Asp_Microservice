using CommonLogging;
using Product.API.Data;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDatacontext, DataContext>();
builder.Services.AddScoped<IRepository, Repository>();
builder.Host.UseSerilog(Serilogger.Configure)
    .ConfigureLogging(logging => {
        logging.ClearProviders();
        logging.AddConsole();
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
