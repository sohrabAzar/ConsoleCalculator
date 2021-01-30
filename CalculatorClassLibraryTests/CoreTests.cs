using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorClassLibrary.Tests
{
    [TestClass()]
    public class CoreTests
    {
        [TestMethod()]
        public void CalculateResultTest_MathOperations()
        {
            // TEST CASE 1 
            // Arrange
            double excpeted_1 = 110;
            // Act
            Core.Result = 100;
            Core.SetOperationType("+");
            Core.CurrentEnteredNumber = 10;
            Core.CalculateResult();
            double actual_1 = Core.Result;
            // Assert
            Assert.AreEqual(excpeted_1, actual_1);

            // TEST CASE 2 
            // Arrange
            double excpeted_2 = 30;
            // Act
            Core.Result = 6;
            Core.SetOperationType("*");
            Core.CurrentEnteredNumber = 5;
            Core.CalculateResult();
            double actual_2 = Core.Result;
            // Assert
            Assert.AreEqual(excpeted_2, actual_2);

            // TEST CASE 3
            // Arrange
            double excpeted_3 = 10;
            // Act
            Core.Result = 80;
            Core.SetOperationType("/");
            Core.CurrentEnteredNumber = 8;
            Core.CalculateResult();
            double actual_3 = Core.Result;
            // Assert
            Assert.AreEqual(excpeted_3, actual_3);
        }

        [TestMethod()]
        public void SetOperationTypeTest()
        {
            // TEST CASE 1 (if + then set operation type to add)
            // Arrange
            Enumrations.OperationType excpeted_1 = Enumrations.OperationType.add;
            // Act
            Core.SetOperationType("+");
            // Assert
            Assert.AreEqual(excpeted_1, Core.LastOperationType);

            // TEST CASE 1 (if * then set operation type to add)
            // Arrange
            Enumrations.OperationType excpeted_2 = Enumrations.OperationType.multiple;
            // Act
            Core.SetOperationType("*");
            // Assert
            Assert.AreEqual(excpeted_2, Core.LastOperationType);
        }

        [TestMethod()]
        public void CalculateResultTest_TempConversions()
        {
            // TEST CASE 4 (test temp conversion)
            // Arrange
            double excpeted_4 = 32;
            // Act
            Core.SetOperationType("C");
            Core.CurrentEnteredNumber = 0;
            Core.CalculateResult();
            double actual_4 = Core.Result;
            // Assert
            Assert.AreEqual(excpeted_4, actual_4);
        }
    }
}