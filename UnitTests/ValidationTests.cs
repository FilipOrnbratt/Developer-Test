using Microsoft.VisualStudio.TestTools.UnitTesting;
using Developer_Test;
namespace UnitTests
{
    [TestClass]
    public class ValidationTests
    {
        private Model model;
        
        [TestInitialize]
        public void TestInitialize()
        {
            model = new Model("Car_Rentals_Test.db");
            model.SaveRental("A33", "19/07/2000 00:00:00", CarCategories.SmallCar.ToString(), "19/07/2010 00:00:00", "80");
            model.SaveRental("A43", "19/07/2000 00:00:00", CarCategories.Van.ToString(), "19/07/2010 00:00:00", "50");
            model.SaveRental("A53", "19/07/2000 00:00:00", CarCategories.Minibus.ToString(), "19/07/2010 00:00:00", "50");
        }

        [TestCleanup]
        public void CleanUp()
        {
            model.DropDatabase();
        }

        [TestMethod]
        public void ValidateRentalData_OnlyValidData_Valid()
        {
            Assert.AreEqual(0, model.ValidateRentalData("A11", "19/07/2000 00:00:00", 
                CarCategories.SmallCar.ToString(), "22/07/2010 00:00:00", "20"));
        }

        [TestMethod]
        public void ValidateRentalData_EmptyBookingNumber_Invalid()
        {
            Assert.AreEqual(1, model.ValidateRentalData(string.Empty, "19/07/2000 00:00:00",
                CarCategories.SmallCar.ToString(), "22/07/2010 00:00:00", "20"));
        }

        [TestMethod]
        public void ValidateRentalData_DuplicateBookingNumber_Invalid()
        {
            string duplicateBookingNumber = "A22";
            model.SaveRental(duplicateBookingNumber, "19/07/2000 00:00:00", CarCategories.SmallCar.ToString(), "19/07/2010 00:00:00", "80");

            Assert.AreEqual(1, model.ValidateRentalData(duplicateBookingNumber, "19/07/2000 00:00:00",
                CarCategories.SmallCar.ToString(), "22/07/2010 00:00:00", "20"));
        }

        [TestMethod]
        public void ValidateRentalData_BirthWrongFormat_Invalid()
        {
            Assert.AreEqual(2, model.ValidateRentalData("A11", "07/2000 00:00:00",
                CarCategories.SmallCar.ToString(), "22/07/2010 00:00:00", "20"));
        }

        [TestMethod]
        public void ValidateRentalData_NonExistentCarCategory_Invalid()
        {
            Assert.AreEqual(3, model.ValidateRentalData("A11", "19/07/2000 00:00:00",
                "Not a car", "22/07/2010 00:00:00", "20"));
        }

        [TestMethod]
        public void ValidateRentalData_RentalDateWrongFormat_Invalid()
        {
            Assert.AreEqual(4, model.ValidateRentalData("A11", "19/07/2000 00:00:00",
                CarCategories.SmallCar.ToString(), "22/07 00:00:00", "20"));
        }

        [TestMethod]
        public void ValidateRentalData_MilageNotANumber_Invalid()
        {
            Assert.AreEqual(5, model.ValidateRentalData("A11", "19/07/2000 00:00:00",
                CarCategories.SmallCar.ToString(), "22/07/2010 00:00:00", "abc"));
        }

        [TestMethod]
        public void ValidateRentalData_MilageBelowZero_Invalid()
        {
            Assert.AreEqual(5, model.ValidateRentalData("A11", "19/07/2000 00:00:00",
                CarCategories.SmallCar.ToString(), "22/07/2010 00:00:00", "-2"));
        }

        [TestMethod]
        public void ValidateReturnData_OnlyValidData_Valid()
        {
            Assert.AreEqual(0, model.ValidateReturnData("A33", "100", "22/07/2010 00:00:00"));
        }

        [TestMethod]
        public void ValidateReturnData_NotExistentRental_Invalid()
        {
            Assert.AreEqual(1, model.ValidateReturnData("A32", "100", "22/07/2010 00:00:00"));
        }

        [TestMethod]
        public void ValidateReturnData_RentalAlreadyReturned_Invalid()
        {
            model.SaveReturnDate("A33", "22/07/2010 00:00:00");

            Assert.AreEqual(1, model.ValidateReturnData("A33", "100", "22/07/2010 00:00:00"));
        }

        [TestMethod]
        public void ValidateReturnData_ReturnMilageNotANumber_Invalid()
        {
            Assert.AreEqual(2, model.ValidateReturnData("A33", "abc", "22/07/2010 00:00:00"));
        }

        [TestMethod]
        public void ValidateReturnData_ReturnMilageBelowRentalMilage_Invalid()
        {
            Assert.AreEqual(2, model.ValidateReturnData("A33", "70", "22/07/2010 00:00:00"));
        }

        [TestMethod]
        public void ValidateReturnData_ReturnDateWrongFormat_Invalid()
        {
            Assert.AreEqual(3, model.ValidateReturnData("A33", "100", "222010 00:00:00"));
        }
    }
}
