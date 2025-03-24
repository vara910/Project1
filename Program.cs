using Microsoft.EntityFrameworkCore;
using SubjectManagement1.Models;
using Microsoft.Extensions.DependencyInjection;
using StudentManagement1.Data;

namespace SubjectManagement1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<StudentManagement1Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("StudentManagement1Context") ?? throw new InvalidOperationException("Connection string 'StudentManagement1Context' not found.")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Subject}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
