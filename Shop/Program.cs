using Microsoft.EntityFrameworkCore;
using Shop.ApplicationServices.Services.Kindergarten;
using Shop.ApplicationServices.Services.SpaceShips;
using Shop.Core.Domain.Kindergartens;
using Shop.Core.ServiceInterface.Kindergarten;
using Shop.Core.ServiceInterface.SpaceShips;
using Shop.Data.Kindergarten;
using Shop.Data.SpaceShips;

namespace Shop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //builder.Services.AddScoped< SpaceShipServices>();
            //s

            builder.Services.AddScoped<ISpaceShipsServices, ApplicationServices.Services.SpaceShips.SpaceShipsServices>();

            builder.Services.AddScoped<IKindergartensServices, Shop.ApplicationServices.Services.Kindergarten.KindergartenServices>();

            builder.Services.AddDbContext<ShopContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Shop.Data")));

            builder.Services.AddDbContext<KindergartenContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Shop.Data")));


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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
