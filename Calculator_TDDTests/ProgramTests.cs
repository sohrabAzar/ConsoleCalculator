using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator_TDD;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator_TDD.Tests
{
    [TestClass()]
    public class ProgramTests
    {

        [TestMethod()]
        public void CalculateResultTest_MathOperations()
        {
            // TEST CASE 1 
            // Arrange
            double excpeted_1 = 110;
            // Act
            Program.result = 100;
            Program.SetOperationType("+");
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
    }
}