using AnimalShelter.Models;
using AnimalShelter.Models.Animal;
using AnimalShelter.Models.Employee;
using AnimalShelter.Models.Volunteer;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace AnimalShelter.Context
{
    public class AnimalShelterContext : DbContext
    {
        public AnimalShelterContext(DbContextOptions<AnimalShelterContext> dbContextOptions) : base(dbContextOptions)
        {
            Database.EnsureCreated();
        }

        public DbSet<Animal> Animals { get; set; }

        public DbSet<AnimalPhoto> AnimalsPhotos { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeePhoto> EmployeesPhotos { get; set; }

        public DbSet<Volunteer> Volunteers { get; set; }

        public DbSet<AnimalTag> AnimalTag { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Animal>().HasMany(x => x.Tags).WithMany(x => x.Animals);

            modelBuilder.Entity<AnimalTag>().HasData(new List<AnimalTag> {
            new AnimalTag(){TagId = (int)AnimalStatus.WantsToGetBetter, Name = "WantsToGetBetter"} ,
            new AnimalTag(){TagId = (int)AnimalStatus.Sterilized, Name = "Sterilized"},
            new AnimalTag(){TagId = (int)AnimalStatus.LookingForAnOverstay, Name = "LookingForAnOverstay"},
            new AnimalTag(){TagId = (int)AnimalStatus.NoParasites, Name = "NoParasites"},
            new AnimalTag(){TagId = (int)AnimalStatus.NeedsAHome, Name = "NeedsAHome"}
            });

            modelBuilder.Entity<Animal>().HasMany(x => x.AnimalPhotos).WithOne(x => x.Animal);

            modelBuilder.Entity<Employee>().HasMany(x => x.EmployeePhotos).WithOne(x => x.Employee);
        }
    }
}
