using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorClassLibrary
{
    public class Core
    {
        public static Enumrations.InputType previousInputType = Enumrations.InputType.Operation;
        public static Enumrations.OperationType lastOperationType = Enumrations.OperationType.none;

        public static double result = 0;                                        // keeps track of the calculation results
        public static double currentEnteredNumber = 0;                          // keeps track of the enetered number, was added during refactoring process number func to avoid doing same thing in validate and calculate funcs

        public static void CalculateResult()
        {
            switch (lastOperationType)
            {
                case Enumrations.OperationType.add:
                    result = result + currentEnteredNumber;
                    break;

                case Enumrations.OperationType.reduce:
                    result = result - currentEnteredNumber;
                    break;

                case Enumrations.OperationType.multiple:
                    result = result * currentEnteredNumber;
                    break;

                case Enumrations.OperationType.devide:
                    result = result / currentEnteredNumber;
                    break;

                case Enumrations.OperationType.convertCelsiusToFarenhit:
                    Memory.SaveResultToMemory(result);
                    result = (currentEnteredNumber * 1.8) + 32;
                    Memory.SaveResultToMemory(result);
                    break;

                case Enumrations.OperationType.convertFarenhitToCelsius:
                    Memory.SaveResultToMemory(result);
                    result = (currentEnteredNumber - 32) / 1.8;
                    Memory.SaveResultToMemory(result);
                    break;

                case Enumrations.OperationType.none:
                    result = currentEnteredNumber;
                    break;
            }
        }
        public static void SetOperationType(string input)
        {
            if (input == "+") { lastOperationType = Enumrations.OperationType.add; }
            if (input == "-") { lastOperationType = Enumrations.OperationType.reduce; }
            if (input == "*") { lastOperationType = Enumrations.OperationType.multiple; }
            if (input == "/") { lastOperationType = Enumrations.OperationType.devide; }
            if (input == "C") { lastOperationType = Enumrations.OperationType.convertCelsiusToFarenhit; }
            if (input == "F") { lastOperationType = Enumrations.OperationType.convertFarenhitToCelsius; }
        }

        public static Enumrations.InputType GetCurrentInputType()
        {
            Enumrations.InputType a = Enumrations.InputType.Number;

            switch (previousInputType)
            {
                case Enumrations.InputType.Number:
                    a = Enumrations.InputType.Operation;
                    break;
                case Enumrations.InputType.Operation:
                    a = Enumrations.InputType.Number;
                    break;
            }

            return a;
        }

    }
}
