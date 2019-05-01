using System;
using System.Collections.Generic;
using System.Linq;

namespace Developer_Test
{
    public class Model
    {
        public Database database;
        private const int baseDayRental = 100, kmPrice = 10;

        public Model(string databaseName = "Car_Rentals.db")
        {
            database = new Database(databaseName);
        }

        public double CalculatePrice(string bookingNumber, string returnDate, string returnMilage)
        {
            var rental = database.CarRentals.Where(x => x.BookingNumber == bookingNumber).First();
            CarCategories car = rental.CarCategory;
            DateTime returnDateConverted;
            DateTime.TryParse(returnDate, out returnDateConverted);
            int returnMilageConverted;
            Int32.TryParse(returnMilage, out returnMilageConverted);

            int numberOfDays = (int)Math.Ceiling((returnDateConverted - rental.RentalDate).TotalDays);
            int numberOfKm = returnMilageConverted - rental.Milage;
            double price = 0;
            switch (car)
            {
                case CarCategories.SmallCar:
                    price = baseDayRental * numberOfDays;
                    break;
                case CarCategories.Van:
                    price = baseDayRental * numberOfDays * 1.2 + kmPrice * numberOfKm;
                    break;
                case CarCategories.Minibus:
                    price = baseDayRental * numberOfDays * 1.7 + (kmPrice * numberOfKm * 1.5);
                    break;
            }
            return price;
        }

        public int ValidateRentalData(string bookingNumber, string customerBirth, string car, string rentalDate, string milage)
        {
            if (string.IsNullOrEmpty(bookingNumber) || database.CarRentals.Any(x => x.BookingNumber == bookingNumber))
            {
                return 1;
            }
            DateTime date;
            if (!DateTime.TryParse(customerBirth, out date))
            {
                return 2;
            }
            if (!Enum.IsDefined(typeof(CarCategories), car))
            {
                return 3;
            }
            if (!DateTime.TryParse(rentalDate, out date))
            {
                return 4;
            }
            if (!(Int32.TryParse(milage, out int milageConverted) && milageConverted >= 0))
            {
                return 5;
            }
            return 0;
        }

        public int ValidateReturnData(string bookingNumber, string returnMilage, string returnDate)
        {
            var rental = database.CarRentals.Where(x => x.BookingNumber == bookingNumber).FirstOrDefault();
            if (!(database.CarRentals.Any(x => x.BookingNumber == bookingNumber) && rental.ReturnDate == null))
            {
                return 1;
            }
            if (!(Int32.TryParse(returnMilage, out int returnMilageConverted) && returnMilageConverted >= rental.Milage))
            {
                return 2;
            }
            if (!DateTime.TryParse(returnDate, out DateTime date))
            {
                return 3;
            }
            return 0;
        }

        public void SaveRental(string bookingNumber, string customerBirth, string car, string rentalDate, string milage)
        {
            DateTime customerBirthConverted;
            DateTime.TryParse(customerBirth, out customerBirthConverted);
            CarCategories carCategoryConverted;
            Enum.TryParse(car, out carCategoryConverted);
            DateTime rentalDateConverted;
            DateTime.TryParse(rentalDate, out rentalDateConverted);
            int milageConverted;
            Int32.TryParse(milage, out milageConverted);

            var rental = new CarRentals
            {
                BookingNumber = bookingNumber,
                CustomerBirth = customerBirthConverted,
                CarCategory = carCategoryConverted,
                RentalDate = rentalDateConverted,
                Milage = milageConverted,
                ReturnDate = null
            };
            database.CarRentals.Add(rental);
            database.SaveChanges();
        }

        public void SaveReturnDate(string bookingNumber, string returnDate)
        {
            DateTime returnDateConverted;
            DateTime.TryParse(returnDate, out returnDateConverted);

            database.CarRentals.Where(x => x.BookingNumber == bookingNumber).First().ReturnDate = returnDateConverted;
            database.SaveChanges();
        }

        public List<CarRentals> GetAllRentals()
        {
            return database.CarRentals.OrderByDescending(x => x.RentalDate).ToList();
        }

        public object[] GetBookingNumberForActiveRentalsAsArray()
        {
            return database.CarRentals.Where(x => x.ReturnDate == null).Select(x => x.BookingNumber).ToArray();
        }

        public void DropDatabase()
        {
            // Only used for testing
            database.Database.EnsureDeleted();
        }
    }
}
