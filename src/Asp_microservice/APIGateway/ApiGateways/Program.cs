using CommonLogging;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Cache.CacheManager;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog(Serilogger.Configure);
builder.Services.AddOcelot().AddCacheManager(x =>
{
    x.WithDictionaryHandle();
});
builder.Configuration.AddJsonFile($"Ocelot.{builder.Environment.EnvironmentName}.json", true);

var app = builder.Build();
app.UseOcelot();

app.MapGet("/", () => "Hello World!");

app.Run();
