using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using URL_ShortenerApi.Data.Base;
using URL_ShortenerApi.Data.Services.Implementation;
using URL_ShortenerApi.Data.Services.Interfaces;
using URL_ShortenerApi.Models;

namespace URL_ShortenerApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IEntityBaseRepository<ShortenedUrl>, EntityBaseRepository<ShortenedUrl>>();
            builder.Services.AddScoped<IShortUrlService,ShortUrlService>();
            builder.Services.AddDbContext<AppDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
        }
    }
}