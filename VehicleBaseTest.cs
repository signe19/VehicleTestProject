using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bridge;
namespace VehicleTestProject
{
    [TestClass]
    public sealed class VehicleBaseTest
    {
        [TestMethod]
        public void VehicleBase_polymorphicTest()
        {
            // Arrange
            var MC = new MC("ABC123", DateTime.Now, false);
            var Car = new Car("XYZ789", DateTime.Now, false);
            // Act
            var price = MC.Price();
            var type = MC.VehicleType();
            var carPrice = Car.Price();
            var carType = Car.VehicleType();

            // Assert
            Assert.AreEqual(120.0, price);
            Assert.AreEqual("MC", type);
            Assert.AreEqual(230.0, carPrice);
            Assert.AreEqual("Car", carType);
        }
        [TestMethod]
        public void Car_withBrobizzDiscount()
        {
            // Arrange
            var car = new Car("XYZ789", DateTime.Now, true);
            // Act
            var price = car.Price();
            // Assert
            Assert.AreEqual(207.0, price, 0.001); // 10% discount on 230.0
        }
        [TestMethod]
        public void Car_withoutBrobizzDiscount()
        {
            // Arrange
            var car = new Car("ABC123", DateTime.Now, false);
            // Act
            var price = car.Price();
            // Assert
            Assert.AreEqual(230.0, price, 0.001); // no discount
        }
        [TestMethod]
        public void MC_withBrobizzDiscount()
        {
            // Arrange
            var mc = new MC("XYZ789", DateTime.Now, true);
            // Act
            var price = mc.Price();
            // Assert
            Assert.AreEqual(108.0, price, 0.001); // 10% discount on 120.0
        }
        [TestMethod]
        public void MC_withoutBrobizzDiscount()
        {
            // Arrange
            var mc = new MC("ABC123", DateTime.Now, false);
            // Act
            var price = mc.Price();
            // Assert
            Assert.AreEqual(120.0, price, 0.001); // no discount
        }
    }
}
