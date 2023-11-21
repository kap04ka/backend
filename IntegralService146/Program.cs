using IntegralService146.Services;
using MathNet.Numerics;
using Microsoft.Extensions.DependencyInjection;

namespace IntegralService146
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            /*builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:5020/swagger/",
                                            "http://localhost:3000",
                                            "http://localhost:3000/integral",
                                            "http://localhost:3000/static/js/bundle.js:304524:14");
                    });
            });*/

            builder.Services.AddCors();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddTransient<ICalculatorService, CalculatorService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                app.UseCors(builder => builder
                   .AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader());
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}