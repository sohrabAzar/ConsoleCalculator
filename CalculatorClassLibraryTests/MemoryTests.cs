using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorClassLibrary.Tests
{
    [TestClass()]
    public class MemoryTests
    {
        [TestMethod()]
        public void BuildMemoryTest_MathOperations()
        {
            // TEST CASE 1 (simple addtion)
            // Arrange
            string excpeted_1 = "1+2 = 3";
            Memory.memory_userInputs.Add("1");
            Memory.memory_userInputs.Add("+");
            Memory.memory_userInputs.Add("2");
             double result_1 = 3;

            // Act
            StringBuilder actual_1 = Memory.BuildMemory(result_1);

            // Assert
            Assert.AreEqual(excpeted_1, actual_1.ToString());

            // TEST CASE 2 (addtion and multiple)
            // Arrange
            Memory.memory_userInputs.Clear();

            string excpeted_2 = "(1+2)*5 = 15";
            Memory.memory_userInputs.Add("1");
            Memory.memory_userInputs.Add("+");
            Memory.memory_userInputs.Add("2");
            Memory.memory_userInputs.Add("*");
            Memory.memory_userInputs.Add("5");
            double result_2 = 15;

            // Act
            StringBuilder actual_2 = Memory.BuildMemory(result_2);

            // Assert
            Assert.AreEqual(excpeted_2, actual_2.ToString());

        }
    }
}