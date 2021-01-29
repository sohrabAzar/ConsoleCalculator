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
        public void ValidateNumberTest_NotANumberShouldReturnFalse()
        {
            // TEST CASE 1 (NotANumberShouldReturnFalse)
            // Arrange
            bool excpeted_1 = false;
            // Act
            bool actual_1 = Program.ValidateNumber("a");
            // Assert
            Assert.AreEqual(excpeted_1, actual_1);

            // TEST CASE 1 (NumberShouldReturnTrue)
            // Arrange
            bool excpeted_2 = true;
            // Act
            bool actual_2 = Program.ValidateNumber("1");
            // Assert
            Assert.AreEqual(excpeted_2, actual_2);
        }

        [TestMethod()]
        public void ValidateOperationTest()
        {
            // TEST CASE 1 (valid op should return ture)
            // Arrange
            bool excpeted_1 = true;
            // Act
            bool actual_1 = Program.ValidateOperation("+");
            // Assert
            Assert.AreEqual(excpeted_1, actual_1);

            // TEST CASE 2 (invalid op should return false)
            // Arrange
            bool excpeted_2 = false;
            // Act
            bool actual_2 = Program.ValidateOperation("as");
            // Assert
            Assert.AreEqual(excpeted_2, actual_2);
        }

        [TestMethod()]
        public void IsUserInputValidTest()
        {
            // TEST CASE 1
            // Arrange
            bool excpeted_1 = true;
            // Act
            Program.previousInputType = Program.InputType.Number;
            bool actual_1 = Program.IsUserInputValid("+");
            // Assert
            Assert.AreEqual(excpeted_1, actual_1);

            // TEST CASE 2
            // Arrange
            bool excpeted_2 = false;
            // Act
            Program.previousInputType = Program.InputType.Number;
            bool actual_2 = Program.IsUserInputValid("as");
            // Assert
            Assert.AreEqual(excpeted_2, actual_2);

            // TEST CASE 3
            // Arrange
            bool excpeted_3 = true;
            // Act
            Program.previousInputType = Program.InputType.Operation;
            bool actual_3 = Program.IsUserInputValid("123");
            // Assert
            Assert.AreEqual(excpeted_3, actual_3);

            // TEST CASE 4
            // Arrange
            bool excpeted_4 = false;
            // Act
            Program.previousInputType = Program.InputType.Operation;
            bool actual_4 = Program.IsUserInputValid("asd");
            // Assert
            Assert.AreEqual(excpeted_4, actual_4);
        }

        [TestMethod()]
        public void SetOperationTypeTest()
        {
            // TEST CASE 1 (if + then set operation type to add)
            // Arrange
            Program.OperationType excpeted_1 = Program.OperationType.add;
            // Act
            Program.SetOperationType("+");
            // Assert
            Assert.AreEqual(excpeted_1, Program.lastOperationType);

            // TEST CASE 1 (if * then set operation type to add)
            // Arrange
            Program.OperationType excpeted_2 = Program.OperationType.multiple;
            // Act
            Program.SetOperationType("*");
            // Assert
            Assert.AreEqual(excpeted_2, Program.lastOperationType);
        }
    }
}