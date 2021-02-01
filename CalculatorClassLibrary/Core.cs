using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorClassLibrary
{
    public class Core
    {
        #region MEMBERS
        // Keep tack of the last input type that was enetered
        public static Enumrations.InputType PreviousInputType { get; set; } = Enumrations.InputType.Operation;
        // Keep tack of the last operation type that was enetered
        public static Enumrations.OperationType LastOperationType { get; set; } = Enumrations.OperationType.none;
        // keeps track of the calculation results
        public static double Result { get; set; }
        // Keeps track of the enetered number
        // was added during refactoring process number func to avoid doing same thing in validate and calculate funcs       
        public static double CurrentEnteredNumber { get; set; }
        #endregion

        #region METHODS

        #region private
        /// <summary>
        /// If first entry after console reset, operation is none
        /// </summary>
        /// <returns>True is first entry</returns>
        private static bool IsFirstUserEntry()
        {
            return (Core.LastOperationType == Enumrations.OperationType.none);
        }
        #endregion

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

        /// <summary>
        /// Get Calculation results,ready to be shown on UI
        /// </summary>
        /// <returns>Results for UI</returns>
        public static string GetCalculationResultForUIDisplay()
        {
            StringBuilder ResultForUIDisplay = new StringBuilder();

            // when first entry operation is none, if not first entry then show result
            if (!(IsFirstUserEntry()))
            {
                ResultForUIDisplay.Append(Core.Result);

                // If temp conversion operation add temp unit at the end and reset calculrator. 
                // This part can be taken out as well if you want to continue using the result
                switch (Core.LastOperationType)
                {
                    case Enumrations.OperationType.convertCelsiusToFarenhit:
                        ResultForUIDisplay.Append("F");
                        Memory.ResetConsole();
                        break;
                    case Enumrations.OperationType.convertFarenhitToCelsius:
                        ResultForUIDisplay.Append("C");
                        Memory.ResetConsole();
                        break;
                    default:
                        break;
                }
            }

            return ResultForUIDisplay.ToString();
        }
        #endregion



    }
}
