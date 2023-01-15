using AnimalShelter.Services.Class;
using AnimalShelter.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using AnimalShelter.Data.Class;
using AnimalShelter.Data.Interfaces;
using AnimalShelter.Validation;
using AnimalShelter.Context;
using System.Configuration;

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

            builder.Services.AddTransient<IAnimalServices, AnimalsServices>();
            builder.Services.AddTransient<IEmployeeServices, EmployeesServices>();
            builder.Services.AddTransient<IVolunteerServices, VolunteersServices>();
            builder.Services.AddTransient<IAnimalPhotoServices, AnimalsPhotoServices>();
            builder.Services.AddTransient<IEmployeePhotoServices, EmployeesPhotoServices>();

            builder.Services.AddTransient<AnimalValidation>();
            builder.Services.AddTransient<EmployeeValidation>();
            builder.Services.AddTransient<VolunteerValidation>();

            builder.Services.AddHealthChecks().AddSqlServer(builder.Configuration.GetConnectionString("Default"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHealthChecks("/health");

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