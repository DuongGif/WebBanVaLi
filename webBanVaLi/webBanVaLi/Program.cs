using Microsoft.EntityFrameworkCore;
using webBanVaLi.Models;
using webBanVaLi.Res;

namespace webBanVaLi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            string connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=QLBanVaLi;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            //var connectionString = builder.Configuration.GetConnectionString("QLBanVaLiContext");
            builder.Services.AddDbContext<QLBanVaLiContext>(x => x.UseSqlServer(connectionString));

            builder.Services.AddScoped<IloaispRespository, loaispRespository>();
            builder.Services.AddSession();
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
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Access}/{action=Login}/{id?}");

            app.Run();
        }
    }
}