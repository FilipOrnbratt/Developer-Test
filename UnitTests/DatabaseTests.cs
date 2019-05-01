using Microsoft.VisualStudio.TestTools.UnitTesting;
using Developer_Test;
using System.Linq;
using System;

namespace UnitTests
{
    [TestClass]
    public class DatabaseTests
    {
        private Model model;

        [TestInitialize]
        public void TestInitialize()
        {
            model = new Model("Car_Rentals_Test.db");
            model.SaveRental("A33", new DateTime(2000, 07, 19).ToString(), CarCategories.SmallCar.ToString(), new DateTime(2010, 07, 19).ToString(), "80");
        }

        [TestCleanup]
        public void CleanUp()
        {
            model.DropDatabase();
        }

        [TestMethod]
        public void SaveRental_InsertRentalToDatabase_InDatabase()
        {
            model.SaveRental("A73", new DateTime(2000, 07, 19).ToString(), CarCategories.Van.ToString(), new DateTime(2010, 07, 19).ToString(), "54");

            var savedRental = model.database.CarRentals.Where(x => x.BookingNumber == "A73").FirstOrDefault();

            Assert.AreNotEqual(null, savedRental, "Rental not saved");
            Assert.AreEqual(CarCategories.Van, savedRental.CarCategory, "Wrong car category");
            Assert.AreEqual(54, savedRental.Milage, "Wrong milage");
        }

        [TestMethod]
        public void SaveReturnDate_UpdateReturnTime_InDatabase()
        {
            model.SaveReturnDate("A33", new DateTime(2010, 07, 21).ToString());

            var updatedRental = model.database.CarRentals.Where(x => x.BookingNumber == "A33").First();

            Assert.AreEqual(new DateTime(2010, 07, 21).ToString(), updatedRental.ReturnDate.ToString());
        }
    }
}
