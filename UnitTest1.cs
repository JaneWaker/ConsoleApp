using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class WarehouseTests
    {
        [TestMethod]
        public void Box_ExpiryDate_CalculatedCorrectly()
        {
            // Arrange
            DateTime productionDate = new DateTime(2024, 1, 1);
            Box box = new Box(1, 1, 1, 1, productionDate);

            // Act
            DateTime expectedExpiryDate = productionDate.AddDays(100);

            // Assert
            Assert.AreEqual(expectedExpiryDate, box.ExpiryDate);
        }

        [TestMethod]
        public void Pallet_GetExpiryDate_ReturnsMinValueWhenNoBoxes()
        {
            // Arrange
            Pallet pallet = new Pallet { ID = 1, Width = 10, Height = 10, Depth = 10 };

            // Act
            DateTime expiryDate = pallet.GetExpiryDate();

            // Assert
            Assert.AreEqual(DateTime.MinValue, expiryDate);
        }

        [TestMethod]
        public void Pallet_GetWeight_CalculatesCorrectWeight()
        {
            // Arrange
            Pallet pallet = new Pallet { ID = 1, Width = 10, Height = 10, Depth = 10 };
            Box box1 = new Box(1, 1, 1, 1, new DateTime(2024, 1, 1));
            Box box2 = new Box(1, 1, 1, 2, new DateTime(2024, 1, 1));
            pallet.AddBox(box1);
            pallet.AddBox(box2);

            // Act
            double weight = pallet.GetWeight();

            // Assert
            Assert.AreEqual(33, weight); // 30 (по умолчанию) + 1 + 2
        }

        [TestMethod]
        public void Pallet_GetVolume_CalculatesCorrectVolume()
        {
            // Arrange
            Pallet pallet = new Pallet { ID = 1, Width = 10, Height = 10, Depth = 10 };
            Box box1 = new Box(1, 1, 1, 1, new DateTime(2024, 1, 1));
            Box box2 = new Box(1, 1, 1, 1, new DateTime(2024, 1, 1));
            pallet.AddBox(box1);
            pallet.AddBox(box2);

            // Act
            double volume = pallet.GetVolume();

            // Assert
            Assert.AreEqual(1000 + 2, volume); // объем паллеты + объем двух коробок
        }
    }
}