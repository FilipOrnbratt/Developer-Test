using Microsoft.VisualStudio.TestTools.UnitTesting;
using Developer_Test;
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
        public void CalculatePrice_SmallCarPrice_CorrectPrice()
        {
            // price = baseDayRental * numberOfDays
            
            Assert.AreEqual(300, model.CalculatePrice("A33", "22/07/2010 00:00:00", "100"));
        }

        [TestMethod]
        public void CalculatePrice_VanPrice_CorrectPrice()
        {
            // price = baseDayRental * numberOfDays * 1.2 + kmPrice * numberOfKm
            
            Assert.AreEqual(460, model.CalculatePrice("A43", "22/07/2010 00:00:00", "60"));
        }

        [TestMethod]
        public void CalculatePrice_MinibusPrice_CorrectPrice()
        {
            // price = baseDayRental * numberOfDays * 1.7 + (kmPrice * numberOfKm * 1.5)
            
            Assert.AreEqual(810, model.CalculatePrice("A53", "22/07/2010 00:00:00", "70"));
        }
    }
}
