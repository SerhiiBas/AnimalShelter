using AnimalShelter.Services.Class;
using AnimalShelter.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using AnimalShelter.Data.Class;
using AnimalShelter.Data.Interfaces;
using AnimalShelter.Validation;
using AnimalShelter.Context;

namespace AnimalShelter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AnimalShelterContext>(options =>
            
            options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
            );

            builder.Services.AddTransient<AnimalShelterContext>();
            builder.Services.AddTransient<IAnimalsRepo, AnimalsRepo>();
            builder.Services.AddTransient<IEmployeesRepo, EmployeesRepo>();
            builder.Services.AddTransient<IVolunteersRepo, VolunteersRepo>();
            builder.Services.AddTransient<IAnimalsPhotoRepo, AnimalsPhotoRepo>();
            builder.Services.AddTransient<IEmployeesPhotoRepo, EmployeesPhotoRepo>();

            builder.Services.AddTransient<IAnimalsServices, AnimalsServices>();
            builder.Services.AddTransient<IEmployeesServices, EmployeesServices>();
            builder.Services.AddTransient<IVolunteersServices, VolunteersServices>();
            builder.Services.AddTransient<IAnimalsPhotoServices, AnimalsPhotoServices>();
            builder.Services.AddTransient<IEmployeesPhotoServices, EmployeesPhotoServices>();

            builder.Services.AddTransient<AnimalValidation>();
            builder.Services.AddTransient<EmployeeValidation>();
            builder.Services.AddTransient<VolunteerValidation>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.UseRouting();

            app.Run();
        }
    }
}