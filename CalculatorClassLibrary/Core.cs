using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorClassLibrary
{
    public class Core
    {
        public static void CalculateResult(double currentEnteredNumber, ref double result, Enumrations.OperationType lastOperationType)
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
        public static void SetOperationType(string input, ref Enumrations.OperationType lastOperationType)
        {
            if (input == "+") { lastOperationType = Enumrations.OperationType.add; }
            if (input == "-") { lastOperationType = Enumrations.OperationType.reduce; }
            if (input == "*") { lastOperationType = Enumrations.OperationType.multiple; }
            if (input == "/") { lastOperationType = Enumrations.OperationType.devide; }
            if (input == "C") { lastOperationType = Enumrations.OperationType.convertCelsiusToFarenhit; }
            if (input == "F") { lastOperationType = Enumrations.OperationType.convertFarenhitToCelsius; }
        }

    }
}
