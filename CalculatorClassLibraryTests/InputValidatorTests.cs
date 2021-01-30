using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorClassLibrary.Tests
{
    [TestClass()]
    public class InputValidatorTests
    {
        [TestMethod()]
        public void ValidateNumberTest()
        {
            // TEST CASE 1 (NotANumberShouldReturnFalse)
            // Arrange
            bool excpeted_1 = false;
            // Act
            bool actual_1 = InputValidator.ValidateNumber("a");
            // Assert
            Assert.AreEqual(excpeted_1, actual_1);

            // TEST CASE 2 (NumberShouldReturnTrue)
            // Arrange
            bool excpeted_2 = true;
            // Act
            bool actual_2 = InputValidator.ValidateNumber("1");
            // Assert
            Assert.AreEqual(excpeted_2, actual_2);

            // TEST CASE 2 (MARCUSShouldReturnTrue)
            // Arrange
            bool excpeted_3 = true;
            // Act
            bool actual_3 = InputValidator.ValidateNumber("MARCUS");
            // Assert
            Assert.AreEqual(excpeted_3, actual_3);
        }

        [TestMethod()]
        public void ValidateOperationTest()
        {
            // TEST CASE 1 (valid op should return ture)
            // Arrange
            bool excpeted_1 = true;
            // Act
            bool actual_1 = InputValidator.ValidateOperation("+");
            // Assert
            Assert.AreEqual(excpeted_1, actual_1);

            // TEST CASE 2 (invalid op should return false)
            // Arrange
            bool excpeted_2 = false;
            // Act
            bool actual_2 = InputValidator.ValidateOperation("as");
            // Assert
            Assert.AreEqual(excpeted_2, actual_2);
        }

        [TestMethod()]
        public void IsInputValidAValidCommandTest()
        {
            // TEST CASE 1 (valid op should return ture)
            // Arrange
            bool excpeted_1 = true;
            // Act
            bool actual_1 = InputValidator.IsInputAValidCommand("quit");
            // Assert
            Assert.AreEqual(excpeted_1, actual_1);

            // TEST CASE 2 (invalid op should return false)
            // Arrange
            bool excpeted_2 = false;
            // Act
            bool actual_2 = InputValidator.IsInputAValidCommand("as");
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
            Core.previousInputType = Enumrations.InputType.Number;
            bool actual_1 = InputValidator.IsUserInputValidMath("+");
            // Assert
            Assert.AreEqual(excpeted_1, actual_1);

            // TEST CASE 2
            // Arrange
            bool excpeted_2 = false;
            // Act
            Core.previousInputType = Enumrations.InputType.Number;
            bool actual_2 = InputValidator.IsUserInputValidMath("as");
            // Assert
            Assert.AreEqual(excpeted_2, actual_2);

            // TEST CASE 3
            // Arrange
            bool excpeted_3 = true;
            // Act
            Core.previousInputType = Enumrations.InputType.Operation;
            bool actual_3 = InputValidator.IsUserInputValidMath("123");
            // Assert
            Assert.AreEqual(excpeted_3, actual_3);

            // TEST CASE 4
            // Arrange
            bool excpeted_4 = false;
            // Act
            Core.previousInputType = Enumrations.InputType.Operation;
            bool actual_4 = InputValidator.IsUserInputValidMath("asd");
            // Assert
            Assert.AreEqual(excpeted_4, actual_4);
        }
    }


}