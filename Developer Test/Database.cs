using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace Developer_Test
{
    public enum CarCategories
    {
        SmallCar,
        Van,
        Minibus
    }

    public class Database : DbContext
    {
        public DbSet<CarRentals> CarRentals { get; set; }
        private string databaseName;

        public Database(string databaseName)
        {
            this.databaseName = databaseName;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=" + databaseName);
        }
    }

    public class CarRentals
    {
        [Key]
        public string BookingNumber { get; set; }
        public DateTime CustomerBirth { get; set; }
        public CarCategories CarCategory { get; set; }
        public DateTime RentalDate { get; set; }
        public int Milage { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
