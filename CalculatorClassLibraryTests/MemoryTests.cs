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
            Memory.Memory_userInputs.Add("1");
            Memory.Memory_userInputs.Add("+");
            Memory.Memory_userInputs.Add("2");
            Core.Result = 3;

            // Act
            StringBuilder actual_1 = Memory.BuildMemory();

            // Assert
            Assert.AreEqual(excpeted_1, actual_1.ToString());

            // TEST CASE 2 (addtion and multiple)
            // Arrange
            Memory.Memory_userInputs.Clear();

            string excpeted_2 = "(1+2)*5 = 15";
            Memory.Memory_userInputs.Add("1");
            Memory.Memory_userInputs.Add("+");
            Memory.Memory_userInputs.Add("2");
            Memory.Memory_userInputs.Add("*");
            Memory.Memory_userInputs.Add("5");
            Core.Result = 15;

            // Act
            StringBuilder actual_2 = Memory.BuildMemory();

            // Assert
            Assert.AreEqual(excpeted_2, actual_2.ToString());

        }

        [TestMethod()]
        public void ResetMemoryTest()
        {
            // Act
            Memory.ResetMemory();

            // Assert
            Assert.IsTrue(Memory.Memory_userInputs.Count == 0);
            Assert.IsTrue(Memory.Memory_results.Count == 0);
        }
    }
}