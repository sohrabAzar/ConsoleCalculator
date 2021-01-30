using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorClassLibrary
{
    public class Core
    {
        public static Enumrations.InputType PreviousInputType { get; set; } = Enumrations.InputType.Operation;
        public static Enumrations.OperationType LastOperationType { get; set; } = Enumrations.OperationType.none;
        public static double Result { get; set; }                                    // keeps track of the calculation results
        public static double CurrentEnteredNumber { get; set; }                      // keeps track of the enetered number, was added during refactoring process number func to avoid doing same thing in validate and calculate funcs       



        public static void CalculateResult()
        {
            switch (LastOperationType)
            {
                case Enumrations.OperationType.add:
                    Result = Result + CurrentEnteredNumber;
                    break;

                case Enumrations.OperationType.reduce:
                    Result = Result - CurrentEnteredNumber;
                    break;

                case Enumrations.OperationType.multiple:
                    Result = Result * CurrentEnteredNumber;
                    break;

                case Enumrations.OperationType.devide:
                    Result = Result / CurrentEnteredNumber;
                    break;

                case Enumrations.OperationType.convertCelsiusToFarenhit:
                    Memory.SaveResultToMemory(Result);
                    Result = (CurrentEnteredNumber * 1.8) + 32;
                    Memory.SaveResultToMemory(Result);
                    break;

                case Enumrations.OperationType.convertFarenhitToCelsius:
                    Memory.SaveResultToMemory(Result);
                    Result = (CurrentEnteredNumber - 32) / 1.8;
                    Memory.SaveResultToMemory(Result);
                    break;

                case Enumrations.OperationType.none:
                    Result = CurrentEnteredNumber;
                    break;
            }
        }
        public static void SetOperationType(string input)
        {
            if (input == "+") { LastOperationType = Enumrations.OperationType.add; }
            if (input == "-") { LastOperationType = Enumrations.OperationType.reduce; }
            if (input == "*") { LastOperationType = Enumrations.OperationType.multiple; }
            if (input == "/") { LastOperationType = Enumrations.OperationType.devide; }
            if (input == "C") { LastOperationType = Enumrations.OperationType.convertCelsiusToFarenhit; }
            if (input == "F") { LastOperationType = Enumrations.OperationType.convertFarenhitToCelsius; }
        }
        public static Enumrations.InputType GetCurrentInputType()
        {
            Enumrations.InputType a = Enumrations.InputType.Number;

            switch (PreviousInputType)
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
