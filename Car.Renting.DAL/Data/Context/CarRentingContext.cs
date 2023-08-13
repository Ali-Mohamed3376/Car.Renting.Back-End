using Car.Renting.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace Car.Renting.DAL;
public class CarRentingContext : DbContext
{
    public DbSet<Car> Cars => Set<Car>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<BookingCars> BookingCars => Set<BookingCars>();

    public CarRentingContext(DbContextOptions<CarRentingContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region Car

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(c => c.Id);


            entity.Property(c => c.ModelName)
                  .IsRequired()
                  .HasMaxLength(50);

            entity.Property(c => c.ModelType)
                  .IsRequired()
                  .HasMaxLength(50);

            entity.Property(c => c.ModelYear)
                  .IsRequired();

            entity.Property(c => c.BrandName)
                  .IsRequired()
                  .HasMaxLength(50);


            entity.Property(c => c.Power)
                  .IsRequired();

            entity.Property(c => c.Counter)
                  .ValueGeneratedOnAdd()
                  .UseIdentityColumn();


        });


        #endregion

        #region Customer

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(c => c.Id);


            entity.Property(c => c.Name)
                  .IsRequired()
                  .HasMaxLength(50);

            entity.Property(c => c.Nationality)
                  .IsRequired()
                  .HasMaxLength(50);

            entity.Property(c => c.DrivingLicenseNo)
                  .IsRequired()
                  .HasMaxLength(50);

        });


        #endregion

        #region BookingCars

        modelBuilder.Entity<BookingCars>(entity =>
        {
            entity.HasKey(c => c.Id);

            entity.Property(c => c.TransactionDate)
                  .IsRequired();


        });

        #endregion

        #region RentedCars

        modelBuilder.Entity<RentedCars>(entity =>
        {
            entity.HasKey(c => new { c.CarId, c.BookingCarsId});

            entity.HasOne(c => c.Booking)
                  .WithMany( c => c.RentedCars)
                  .HasForeignKey( c => c.BookingCarsId );
        });


        #endregion

        #region Customer Seeding
        List<Customer> customers = new List<Customer>()
        {
            new Customer
            {
                Id = Guid.NewGuid(),
                Name = "John Doe",
                Nationality = "American",
                DrivingLicenseNo = "1234567890"
            },
            new Customer
            {
                Id = Guid.NewGuid(),
                Name = "Jane Doe",
                Nationality = "Canadian",
                DrivingLicenseNo = "9876543210"
            },
            new Customer
            {
                Id = Guid.NewGuid(),
                Name = "Peter Smith",
                Nationality = "British",
                DrivingLicenseNo = "0123456789"
            }
        };
        #endregion

        #region Car Seeding
        List<Car> cars = new List<Car>()
        {
            new Car
            {
                Id = Guid.NewGuid(),
                ModelName = "Toyota Camry",
                ModelType = "Sedan",
                ModelYear = 2023,
                BrandName = "Toyota",
                Power = 203
            },
            new Car
            {
                Id = Guid.NewGuid(),
                ModelName = "Honda Civic",
                ModelType = "Sedan",
                ModelYear = 2023,
                BrandName = "Honda",
                Power = 174
            },
            new Car
            {
                Id = Guid.NewGuid(),
                ModelName = "Tesla Model 3",
                ModelType = "Sedan",
                ModelYear = 2023,
                BrandName = "Tesla",
                Power = 358
            }
        };
        #endregion

        modelBuilder.Entity<Customer>().HasData(customers);
        modelBuilder.Entity<Car>().HasData(cars);
    }
}
