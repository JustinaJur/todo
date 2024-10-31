// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();


// List<Todo> todos = new()
// {
//     new Todo{ Id=1, Title="Clean house", IsDone=false},
//     new Todo{ Id=2, Title="Do shopping", IsDone=true }
// };


// app.MapGet("/Todos", () => todos);

// app.Run();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }

// public class Todo
// {
//     public int Id { get; set; }
//     public string Title { get; set; }
//     public bool IsDone { get; set; }
// };

using DotnetWebApiWithEFCodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetWebApiWithEFCodeFirst
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            //This section below is for connection string 
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<SampleDBContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            // be sito swageris neveiktu ir dar kazkas

            app.Run();
        }
    }
}