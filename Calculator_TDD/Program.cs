using System;

namespace Calculator_TDD
{
    public class Program
    {
        public static InputType previousInputType = InputType.Operation;
        public static OperationType lastOperationType = OperationType.none;

        static void Main(string[] args)
        {
            ShowConsolePromot(previousInputType);

            //Get user input
            string userInput = Console.ReadLine();

            // Validate user input
            ProcessUserInput(IsUserInputValid(userInput));

            switch (previousInputType)
            {
                case InputType.Number:
                    /// entering operation  
                    previousInputType = InputType.Operation;
                    SetOperationType(userInput);
                    break;
                case InputType.Operation:
                    /// entering number
                    CalculateResult();                 
                    DisplayResult();

                    break;
                default:
                    break;
            }
        }




        private static void ProcessUserInput(bool isInputValid)
        {
            if (!isInputValid)
            {
                Console.WriteLine($"enter a valid {GetCurrentInputType()}");
                Console.ReadLine();
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
        private static void CalculateResult()
        {
            // if first input then set result to it
            // else based on what operation type that was entered is do operation on result
            throw new NotImplementedException();
        }

        private static void DisplayResult()
        {
            // show result if not the first entry
            throw new NotImplementedException();
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

        enum SpecialCommand
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

        #region VALIDATE USER INPUT
        public static bool IsUserInputValid(string input)
        {
            bool isInputValid = false;

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

    }
}
