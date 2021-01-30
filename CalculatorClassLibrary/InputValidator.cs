using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorClassLibrary
{
    public class InputValidator
    {
        private static bool ProceesNumberInput(string input)
        {
            bool isInputValid = false;

            if (input == "MARCUS")
            {
                isInputValid = true;
                Core.currentEnteredNumber = 42;
            }
            else
            {
                isInputValid = double.TryParse(input, out Core.currentEnteredNumber);
            }
            return isInputValid;
        }

        public static bool ValidateNumber(string input)
        {
            bool isInputValid = ProceesNumberInput(input);
            return isInputValid;
        }

        public static bool IsUserInputValidMath(string input)
        {
            bool isInputValid = false;

            if (Commands.EnteredACommand)
            {
                isInputValid = true;
            }
            else
            {
                switch (Core.previousInputType)
                {
                    case Enumrations.InputType.Number:
                        isInputValid = ValidateOperation(input);

                        break;
                    case Enumrations.InputType.Operation:
                        isInputValid = ValidateNumber(input);
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
