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
            double result = 100;

            // TEST CASE 1 
            // Arrange
            double excpeted_1 = 110;
            // Act
            Program.result = 100;
            SetOperationType("+");
            Program.currentEnteredNumber = 10;
            Program.CalculateResult();
            double actual_1 = Program.result;
            // Assert
            Assert.AreEqual(excpeted_1, actual_1);

            // TEST CASE 2 
            // Arrange
            double excpeted_2 = 30;
            // Act
            Program.result = 6;
            Program.SetOperationType("*");
            Program.currentEnteredNumber = 5;
            Program.CalculateResult();
            double actual_2 = Program.result;
            // Assert
            Assert.AreEqual(excpeted_2, actual_2);

            // TEST CASE 3
            // Arrange
            double excpeted_3 = 10;
            // Act
            Program.result = 80;
            Program.SetOperationType("/");
            Program.currentEnteredNumber = 8;
            Program.CalculateResult();
            double actual_3 = Program.result;
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
            Assert.AreEqual(excpeted_1, Program.lastOperationType);

            // TEST CASE 1 (if * then set operation type to add)
            // Arrange
            Enumrations.OperationType excpeted_2 = Enumrations.OperationType.multiple;
            // Act
            Program.SetOperationType("*");
            // Assert
            Assert.AreEqual(excpeted_2, Program.lastOperationType);
        }
    }
}