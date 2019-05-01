using Microsoft.VisualStudio.TestTools.UnitTesting;
using Developer_Test;
using System.Linq;

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
            model.SaveRental("A33", "19/07/2000 00:00:00", CarCategories.SmallCar.ToString(), "19/07/2010 00:00:00", "80");
        }

        [TestCleanup]
        public void CleanUp()
        {
            model.DropDatabase();
        }

        [TestMethod]
        public void SaveRental_InsertRentalToDatabase_InDatabase()
        {
            model.SaveRental("A73", "19/07/2000 00:00:00", CarCategories.Van.ToString(), "19/07/2010 00:00:00", "54");

            var savedRental = model.database.CarRentals.Where(x => x.BookingNumber == "A73").FirstOrDefault();

            Assert.AreNotEqual(null, savedRental, "Rental not saved");
            Assert.AreEqual(CarCategories.Van, savedRental.CarCategory, "Wrong car category");
            Assert.AreEqual(54, savedRental.Milage, "Wrong milage");
        }

        [TestMethod]
        public void SaveReturnDate_UpdateReturnTime_InDatabase()
        {
            model.SaveReturnDate("A33", "21/07/2010 00:00:00");

            var updatedRental = model.database.CarRentals.Where(x => x.BookingNumber == "A33").First();

            Assert.AreEqual("21/07/2010 00:00:00", updatedRental.ReturnDate.ToString());
        }
    }
}
