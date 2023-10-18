using Microsoft.EntityFrameworkCore;
using MinyaG02Demo.Entity;

namespace MinyaG02Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(corsOptions =>
            {
                corsOptions.AddPolicy("myPolicy", corsPolicyOptions =>
                {
                    corsPolicyOptions.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                    //corsPolicyOptions.WithOrigins("").WithMethods("").WithHeaders("");
                });
            });
            builder.Services.AddDbContext<CompanyContext>(options =>
            {
                options.UseSqlServer("Data Source=.;Initial Catalog=MinyaG02API;Integrated Security=True;Encrypt=False");
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
          //  if (app.Environment.IsDevelopment())
          if(app.Environment.IsProduction())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //   app.UseAuthorization();
            app.UseStaticFiles();
            app.UseCors("myPolicy");

            app.MapControllers();

            app.Run();
        }
    }
}