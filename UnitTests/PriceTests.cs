using Microsoft.VisualStudio.TestTools.UnitTesting;
using Developer_Test;
using System;

namespace UnitTests
{
    [TestClass]
    public class PriceTests
    {
        // BaseDayRental = 100, kmPrice = 10
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
        public void CalculatePrice_SmallCarPrice_CorrectPrice()
        {
            // price = baseDayRental * numberOfDays

            Assert.AreEqual(300, model.CalculatePrice("A33", new DateTime(2010, 07, 22).ToString(), "100"));
        }

        [TestMethod]
        public void CalculatePrice_VanPrice_CorrectPrice()
        {
            // price = baseDayRental * numberOfDays * 1.2 + kmPrice * numberOfKm

            Assert.AreEqual(460, model.CalculatePrice("A43", new DateTime(2010, 07, 22).ToString(), "60"));
        }

        [TestMethod]
        public void CalculatePrice_MinibusPrice_CorrectPrice()
        {
            // price = baseDayRental * numberOfDays * 1.7 + (kmPrice * numberOfKm * 1.5)

            Assert.AreEqual(810, model.CalculatePrice("A53", new DateTime(2010, 07, 22).ToString(), "70"));
        }
    }
}
