using Microsoft.VisualStudio.TestTools.UnitTesting;
using Developer_Test;
using System;

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
            model.SaveRental("A33", new DateTime(2000, 07, 19).ToString(), CarCategories.SmallCar.ToString(), new DateTime(2010, 07, 19).ToString(), "80");
            model.SaveRental("A43", new DateTime(2000, 07, 19).ToString(), CarCategories.Van.ToString(), new DateTime(2010, 07, 19).ToString(), "50");
            model.SaveRental("A53", new DateTime(2000, 07, 19).ToString(), CarCategories.Minibus.ToString(), new DateTime(2010, 07, 19).ToString(), "50");
        }

        [TestCleanup]
        public void CleanUp()
        {
            model.DropDatabase();
        }

        [TestMethod]
        public void ValidateRentalData_OnlyValidData_Valid()
        {
            Assert.AreEqual(0, model.ValidateRentalData("A11", new DateTime(2000, 07, 19).ToString(),
                CarCategories.SmallCar.ToString(), new DateTime(2010, 07, 22).ToString(), "20"));
        }

        [TestMethod]
        public void ValidateRentalData_EmptyBookingNumber_Invalid()
        {
            Assert.AreEqual(1, model.ValidateRentalData(string.Empty, new DateTime(2000, 07, 19).ToString(),
                CarCategories.SmallCar.ToString(), new DateTime(2010, 07, 22).ToString(), "20"));
        }

        [TestMethod]
        public void ValidateRentalData_DuplicateBookingNumber_Invalid()
        {
            string duplicateBookingNumber = "A22";
            model.SaveRental(duplicateBookingNumber, new DateTime(2000, 07, 19).ToString(), CarCategories.SmallCar.ToString(), new DateTime(2010, 07, 19).ToString(), "80");

            Assert.AreEqual(1, model.ValidateRentalData(duplicateBookingNumber, new DateTime(2000, 07, 19).ToString(),
                CarCategories.SmallCar.ToString(), new DateTime(2010, 07, 22).ToString(), "20"));
        }

        [TestMethod]
        public void ValidateRentalData_BirthWrongFormat_Invalid()
        {
            Assert.AreEqual(2, model.ValidateRentalData("A11", "07/2000 00:00:00",
                CarCategories.SmallCar.ToString(), new DateTime(2010, 07, 22).ToString(), "20"));
        }

        [TestMethod]
        public void ValidateRentalData_NonExistentCarCategory_Invalid()
        {
            Assert.AreEqual(3, model.ValidateRentalData("A11", new DateTime(2000, 07, 19).ToString(),
                "Not a car", new DateTime(2010, 07, 22).ToString(), "20"));
        }

        [TestMethod]
        public void ValidateRentalData_RentalDateWrongFormat_Invalid()
        {
            Assert.AreEqual(4, model.ValidateRentalData("A11", new DateTime(2000, 07, 19).ToString(),
                CarCategories.SmallCar.ToString(), "22/07 00:00:00", "20"));
        }

        [TestMethod]
        public void ValidateRentalData_MilageNotANumber_Invalid()
        {
            Assert.AreEqual(5, model.ValidateRentalData("A11", new DateTime(2000, 07, 19).ToString(),
                CarCategories.SmallCar.ToString(), new DateTime(2010, 07, 22).ToString(), "abc"));
        }

        [TestMethod]
        public void ValidateRentalData_MilageBelowZero_Invalid()
        {
            Assert.AreEqual(5, model.ValidateRentalData("A11", new DateTime(2000, 07, 19).ToString(),
                CarCategories.SmallCar.ToString(), new DateTime(2010, 07, 22).ToString(), "-2"));
        }

        [TestMethod]
        public void ValidateReturnData_OnlyValidData_Valid()
        {
            Assert.AreEqual(0, model.ValidateReturnData("A33", "100", new DateTime(2010, 07, 22).ToString()));
        }

        [TestMethod]
        public void ValidateReturnData_NotExistentRental_Invalid()
        {
            Assert.AreEqual(1, model.ValidateReturnData("A32", "100", new DateTime(2010, 07, 22).ToString()));
        }

        [TestMethod]
        public void ValidateReturnData_RentalAlreadyReturned_Invalid()
        {
            model.SaveReturnDate("A33", new DateTime(2010, 07, 22).ToString());

            Assert.AreEqual(1, model.ValidateReturnData("A33", "100", new DateTime(2010, 07, 22).ToString()));
        }

        [TestMethod]
        public void ValidateReturnData_ReturnMilageNotANumber_Invalid()
        {
            Assert.AreEqual(2, model.ValidateReturnData("A33", "abc", new DateTime(2010, 07, 22).ToString()));
        }

        [TestMethod]
        public void ValidateReturnData_ReturnMilageBelowRentalMilage_Invalid()
        {
            Assert.AreEqual(2, model.ValidateReturnData("A33", "70", new DateTime(2010, 07, 22).ToString()));
        }

        [TestMethod]
        public void ValidateReturnData_ReturnDateWrongFormat_Invalid()
        {
            Assert.AreEqual(3, model.ValidateReturnData("A33", "100", "222010 00:00:00"));
        }
    }
}
