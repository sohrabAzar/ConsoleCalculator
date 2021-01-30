using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorClassLibrary
{
    public class InputValidator
    {
        public static bool ProceesNumberInput(string input, out double currentEnteredNumber)
        {
            bool isInputValid = false;

            if (input == "MARCUS")
            {
                isInputValid = true;
                currentEnteredNumber = 42;
            }
            else
            {
                isInputValid = double.TryParse(input, out currentEnteredNumber);
            }
            return isInputValid;
        }

        public static bool ValidateNumber(string input, out double currentEnteredNumber)
        {
            bool isInputValid = ProceesNumberInput(input, out currentEnteredNumber);
            return isInputValid;
        }

        public static bool IsUserInputValidMath(string input, bool enteredACommand, Enumrations.InputType previousInputType, ref double currentEnteredNumber)
        {
            bool isInputValid = false;

            if (enteredACommand)
            {
                isInputValid = true;
            }
            else
            {
                switch (previousInputType)
                {
                    case Enumrations.InputType.Number:
                        isInputValid = ValidateOperation(input);

                        break;
                    case Enumrations.InputType.Operation:
                        isInputValid = ValidateNumber(input, out currentEnteredNumber);
                        break;
                }
            }

            return isInputValid;
        }

        public static bool ValidateOperation(string input)
        {
            bool isInputValid = false;

            if (input == "+" || input == "-" || input == "*" || input == "/" || input == "C" || input == "F")
            {
                isInputValid = true;
            }

            return isInputValid;
        }

        public static bool IsInputAValidCommand(string input)
        {
            bool isInputValid = false;

            if (input == "quit" || input == "help" || input == "reset" || input == "newton" || input == "list")
            {
                isInputValid = true;
            }
            return isInputValid;
        }


    }
}
