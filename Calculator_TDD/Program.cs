using System;

namespace Calculator_TDD
{
    public class Program
    {
        public static InputType previousInputType = InputType.Operation;
        public static OperationType lastOperationType = OperationType.none;
        public static SpecialCommand command = SpecialCommand.help;

        public static double result = 0;

        static void Main(string[] args)
        {
            string userInput;

            while (true)
            {
                do
                {
                    ShowConsolePromot(previousInputType);

                    //Get user input
                    userInput = Console.ReadLine();

                    // Validate user input
                    ProcessUserInput(IsUserInputValid(userInput));

                } while (!IsUserInputValid(userInput));


                switch (GetCurrentInputType())
                {
                    case InputType.Operation:
                        /// entering operation  
                        previousInputType = InputType.Operation;
                        SetOperationType(userInput);
                        break;
                    case InputType.Number:
                        /// entering number
                        previousInputType = InputType.Number;
                        CalculateResult(userInput);
                        DisplayResult();
                        break;
                }
            }

        }

        #region MEMBERS
        public enum InputType
        {
            Number,
            Operation,
        }

        public enum OperationType
        {
            none,
            add,
            reduce,
            multiple,
            devide,
            convertCelsiusToFarenhit,
            convertFarenhitToCelsius
        }

        public enum SpecialCommand
        {
            quit,
            help,
            list,
            reset
        }
        #endregion

        #region METHODS

        private static void ShowConsolePromot(InputType lastInputType)
        {
            switch (lastInputType)
            {
                case InputType.Number:
                    Console.Write("OPERATION >");
                    break;
                case InputType.Operation:
                    Console.Write("NUMBER >");
                    break;
            }
        }

        private static InputType GetCurrentInputType()
        {
            InputType a = InputType.Operation;

            switch (previousInputType)
            {
                case InputType.Number:
                    a = InputType.Operation;
                    break;
                case InputType.Operation:
                    a = InputType.Number;
                    break;
            }

            return a;
        }

        public static void SetOperationType(string input)
        {
            if (input == "+") { lastOperationType = OperationType.add; }
            if (input == "-") { lastOperationType = OperationType.reduce; }
            if (input == "*") { lastOperationType = OperationType.multiple; }
            if (input == "/") { lastOperationType = OperationType.devide; }
            if (input == "C") { lastOperationType = OperationType.convertCelsiusToFarenhit; }
            if (input == "F") { lastOperationType = OperationType.convertFarenhitToCelsius; }
        }

        public static void CalculateResult(string input)
        {
            // if first input (operation none) then set result to it
            // else based on what operation type that was entered is do operation on result
            
            bool isInputValid = double.TryParse(input, out double a);

            switch (lastOperationType)
            {
                case OperationType.add:
                    result = result + a;
                    break;

                case OperationType.reduce:
                    result = result - a;
                    break;

                case OperationType.multiple:
                    result = result * a;
                    break;

                case OperationType.devide:
                    result = result / a;
                    break;

                case OperationType.none:
                    result = a;
                    break;
            }
        }

        private static void DisplayResult()
        {
            if (lastOperationType != OperationType.none)
            {
                Console.WriteLine(result + "\n");
            }
        }

        #region PROCESS USER INPUT
        private static void ProcessUserInput(bool isInputValid)
        {
            if (!isInputValid)
            {
                Console.WriteLine($"enter a valid {GetCurrentInputType()} \n");
            }

        }
        #region VALIDATE USER INPUT
        public static bool IsUserInputValid(string input)
        {
            bool isInputValid = false;

            isInputValid = IsInputValidAValidCommand(input);

            switch (previousInputType)
            {
                case InputType.Number:
                    isInputValid = ValidateOperation(input);
                    break;
                case InputType.Operation:
                    isInputValid = ValidateNumber(input);
                    break;
            }
            return isInputValid;
        }

        public static bool IsInputValidAValidCommand(string input)
        {
            bool isInputValid = false;

            if (input == "quit")
            {
                isInputValid = true;
                command = SpecialCommand.quit;
            }

            if (input == "help")
            {
                isInputValid = true;
                command = SpecialCommand.help;
            }

            return isInputValid;
        }

        public static bool ValidateNumber(string input)
        {
            bool isInputValid = double.TryParse(input, out double a);
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
        #endregion
        #endregion

        #endregion

    }
}
