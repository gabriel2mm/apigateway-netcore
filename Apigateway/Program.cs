using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Configuration.AddJsonFile("ocelot.json");

    //custom configs
    builder.Services.AddOcelot(builder.Configuration);
}

var app = builder.Build();
{
    app.UseHttpsRedirection();

    app.UseOcelot().Wait();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}

