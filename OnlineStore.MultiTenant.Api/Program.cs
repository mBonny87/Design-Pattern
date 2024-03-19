using Microsoft.EntityFrameworkCore;
using OnlineStore.MultiTenant.Api.Contexts;
using OnlineStore.MultiTenant.Api.DesignPatterns.Repository;
using OnlineStore.MultiTenant.Api.Models;

namespace OnlineStore.MultiTenant.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString = builder.Configuration.GetConnectionString("ONLINE_STORE_DB");

            builder.Services.AddDbContext<OnlineStoreContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            //provide an instance of Repository<Order, OnlineStoreContext> whenever IRepository<Order> is requested.
            builder.Services.AddScoped<IRepository<Order>, Repository<Order, OnlineStoreContext>>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<OnlineStoreContext>();
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while migrating the DB.");
                }
            }

                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            //var summaries = new[]
            //{
            //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            //};

            //app.MapGet("/weatherforecast", (HttpContext httpContext) =>
            //{
            //    var forecast = Enumerable.Range(1, 5).Select(index =>
            //        new WeatherForecast
            //        {
            //            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            //            TemperatureC = Random.Shared.Next(-20, 55),
            //            Summary = summaries[Random.Shared.Next(summaries.Length)]
            //        })
            //        .ToArray();
            //    return forecast;
            //})
            //.WithName("GetWeatherForecast")
            //.WithOpenApi();

            app.MapGet("/GetAllOrders", async (IRepository<Order> orders) =>
            {
                return await orders.GetAllAsync();
            });

            app.Run();
        }
    }
}
