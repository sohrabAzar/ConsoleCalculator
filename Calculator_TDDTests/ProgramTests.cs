﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void ValidateNumberTest()
        {
            // TEST CASE 1 (NotANumberShouldReturnFalse)
            // Arrange
            bool excpeted_1 = false;
            // Act
            bool actual_1 = Program.ValidateNumber("a");
            // Assert
            Assert.AreEqual(excpeted_1, actual_1);

            // TEST CASE 2 (NumberShouldReturnTrue)
            // Arrange
            bool excpeted_2 = true;
            // Act
            bool actual_2 = Program.ValidateNumber("1");
            // Assert
            Assert.AreEqual(excpeted_2, actual_2);

            // TEST CASE 2 (MARCUSShouldReturnTrue)
            // Arrange
            bool excpeted_3 = true;
            // Act
            bool actual_3 = Program.ValidateNumber("MARCUS");
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
            bool actual_1 = Program.IsUserInputValidMath("+");
            // Assert
            Assert.AreEqual(excpeted_1, actual_1);

            // TEST CASE 2
            // Arrange
            bool excpeted_2 = false;
            // Act
            Program.previousInputType = Program.InputType.Number;
            bool actual_2 = Program.IsUserInputValidMath("as");
            // Assert
            Assert.AreEqual(excpeted_2, actual_2);

            // TEST CASE 3
            // Arrange
            bool excpeted_3 = true;
            // Act
            Program.previousInputType = Program.InputType.Operation;
            bool actual_3 = Program.IsUserInputValidMath("123");
            // Assert
            Assert.AreEqual(excpeted_3, actual_3);

            // TEST CASE 4
            // Arrange
            bool excpeted_4 = false;
            // Act
            Program.previousInputType = Program.InputType.Operation;
            bool actual_4 = Program.IsUserInputValidMath("asd");
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

        [TestMethod()]
        public void CalculateResultTest_TempConversions()
        {
            // TEST CASE 4 (test temp conversion)
            // Arrange
            double excpeted_4 = 32;
            // Act
            Program.SetOperationType("C");
            Program.currentEnteredNumber = 0;
            Program.CalculateResult();
            double actual_4 = Program.result;
            // Assert
            Assert.AreEqual(excpeted_4, actual_4);
        }

        [TestMethod()]
        public void IsInputValidAValidCommandTest()
        {
            // TEST CASE 1 (valid op should return ture)
            // Arrange
            bool excpeted_1 = true;
            // Act
            bool actual_1 = Program.IsInputAValidCommand("quit");
            // Assert
            Assert.AreEqual(excpeted_1, actual_1);

            // TEST CASE 2 (invalid op should return false)
            // Arrange
            bool excpeted_2 = false;
            // Act
            bool actual_2 = Program.IsInputAValidCommand("as");
            // Assert
            Assert.AreEqual(excpeted_2, actual_2);
        }

        [TestMethod()]
        public void BuildMemoryTest()
        {
            // TEST CASE 1 (simple addtion)
            // Arrange
            string excpeted_1 = "1+2 = 3";
            Program.memory_userInputs.Add("1");
            Program.memory_userInputs.Add("+");
            Program.memory_userInputs.Add("2");
            Program.result = 3;

            // Act
            StringBuilder  actual_1 = Program.BuildMemory();

            // Assert
            Assert.AreEqual(excpeted_1, actual_1.ToString());

            // TEST CASE 2 (addtion and multiple)
            // Arrange
            Program.memory_userInputs.Clear();

            string excpeted_2 = "(1+2)*5 = 15";
            Program.memory_userInputs.Add("1");
            Program.memory_userInputs.Add("+");
            Program.memory_userInputs.Add("2");
            Program.memory_userInputs.Add("*");
            Program.memory_userInputs.Add("5");
            Program.result = 15;

            // Act
            StringBuilder actual_2 = Program.BuildMemory();

            // Assert
            Assert.AreEqual(excpeted_2, actual_2.ToString());

        }
    }
}