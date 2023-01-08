using AnimalShelter.Models;
using AnimalShelter.Models.Animal;
using AnimalShelter.Models.Employee;
using AnimalShelter.Models.Volunteer;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Context
{
    public class AnimalShelterContext : DbContext
    {
        public AnimalShelterContext( DbContextOptions<AnimalShelterContext> dbContextOptions):base(dbContextOptions)
        {
        }

        public DbSet<Animal> Animals { get; set; }

        public DbSet<AnimalPhoto> AnimalsPhotos { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeePhoto> EmployeesPhotos { get; set; }

        public DbSet<Volunteer> Volunteers { get; set; }    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Animal>().HasMany(x => x.Tags).WithMany(x=>x.Animals);

            modelBuilder.Entity<AnimalTag>().HasData(new List<AnimalTag> {new AnimalTag(){Id = (int)AnimalStatus.IWantToRecover, Name = "IWantToRecover"} ,
        new AnimalTag(){Id = (int)AnimalStatus.Sterilized, Name = "Sterilized"},
        new AnimalTag(){Id = (int)AnimalStatus.LookingForAnOverstay, Name = "LookingForAnOverstay"},
        new AnimalTag(){Id = (int)AnimalStatus.NoParasites, Name = "NoParasites"},
        new AnimalTag(){Id = (int)AnimalStatus.IWantToHome, Name = "IWantToHome"} });
        }
    }
}
