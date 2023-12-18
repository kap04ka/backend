using IntegralService146.Models;
using IntegralService146.Services;
using Microsoft.EntityFrameworkCore;

namespace IntegralService146
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddTransient<ICalculatorService, CalculatorService>();
            
            var server = Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost";
            var port = Environment.GetEnvironmentVariable("DB_PORT") ?? "1433";
            var user = Environment.GetEnvironmentVariable("DB_USER") ?? "SA";
            var database = Environment.GetEnvironmentVariable("DB_NAME") ?? "QuestionsDB";
            var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "h25Sa1p35Ow";

            /*builder.Services.AddDbContext<QuestionContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));*/

            builder.Services.AddDbContext<QuestionContext>(options =>
            options.UseSqlServer($"Server={server},{port};Initial Catalog={database};User ID ={user};Password={dbPassword};TrustServerCertificate=True;Trusted_Connection=True;MultipleActiveResultSets=True;"));

            // "Server=(localdb)\\MSSQLLocalDB;Database=QuestionsDB;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;"

            var app = builder.Build();

            app.UseCors(builder => builder
                  .AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader());

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

            }

            PrepDB.PrepQuestion(app);

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}