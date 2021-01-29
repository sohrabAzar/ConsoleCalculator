using System;

namespace Calculator_TDD
{
    public class Program
    {
        static void Main(string[] args)
        {
            string userInput;

            IntroduceProgram();
            
            while (!quit)
            {
                // Get Input and validate, only process if data is valid
                do
                {
                    ShowConsolePromot(previousInputType);
                    userInput = Console.ReadLine();
                    ValidateUserInput(userInput);

                } while (!IsUserInputValid(userInput));

                // Process data based on what was entered
                // Command processing
                if (enteredACommand)
                {
                    ExecuteCommand();
                    enteredACommand = false;    // set false so you can go to normal operations after command executed
                }
                // Operations and numbers processing
                else
                {
                    switch (GetCurrentInputType())
                    {
                        case InputType.Operation:
                            previousInputType = InputType.Operation;
                            SetOperationType(userInput);
                            break;
                        case InputType.Number:
                            previousInputType = InputType.Number;
                            CalculateResult();
                            DisplayResult();
                            break;
                    }
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
            none,
            quit,
            help,
            list,
            reset
        }

        public static InputType previousInputType = InputType.Operation;
        public static OperationType lastOperationType = OperationType.none;
        public static double result = 0;                                        // keeps track of the calculation results
        public static double currentEnteredNumber = 0;                          // keeps track of the enetered number, was added during refactoring process number func to avoid doing same thing in validate and calculate funcs

        private static bool quit = false;                                       // used to exit program main while loop
        private static SpecialCommand command = SpecialCommand.none;            // used for keeping track of which special command was entered
        private static bool enteredACommand = false;                            // used to process special commands in main

        #endregion

        #region METHODS

        private static void IntroduceProgram()
        {
            Console.Clear();

            // Title
            Console.WriteLine("SOHRABS CALCULATOR \n");

            // Guide
            Console.WriteLine(
@"**** HOW TO USE ****
Enter any valid input and press enter 
A list of valid inputs is shown below

(VALID NUMBERS)
Enter when prompt shows NUMBER
- Numbers: Any valid doule
- MARCUS: Write MARCUS instead of number 42

(VALID OPERATIONS)
Enter when prompt shows OPERATION
- +, -, *,/: Normal math operations
- C: Write C and the next number entered is converted to Farenhiet
- F: Write F and the next number entered is converted to Celsius

(SPECIAL COMMANDS)
Can be entered at any time
- quit: Exit program
- help: Show guideS
- list: see current calculation
- reset: reset calculation
*****************************************
");
        }
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
            InputType a = InputType.Number;

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

        public static void CalculateResult()
        {         
            switch (lastOperationType)
            {
                case OperationType.add:
                    result = result + currentEnteredNumber;
                    break;

                case OperationType.reduce:
                    result = result - currentEnteredNumber;
                    break;

                case OperationType.multiple:
                    result = result * currentEnteredNumber;
                    break;

                case OperationType.devide:
                    result = result / currentEnteredNumber;
                    break;

                case OperationType.none:
                    result = currentEnteredNumber;
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

        #region COMMANDS
        private static void ExecuteCommand()
        {
            switch (command)
            {
                case SpecialCommand.none:
                    break;

                case SpecialCommand.quit:
                    quit = true;
                    break;

                case SpecialCommand.help:
                    Console.Clear();
                    IntroduceProgram();
                    break;

                case SpecialCommand.list:
                    break;

                case SpecialCommand.reset:
                    Console.Clear();
                    result = 0;
                    previousInputType = InputType.Operation;
                    lastOperationType = OperationType.none;
                    break;

                default:
                    break;
            }
        }

        private static void SetCommandType(string input)
        {
            // loop through enm if text euqal set it

            foreach (SpecialCommand val in Enum.GetValues(typeof(SpecialCommand)))
            {
                if (input == val.ToString())
                {
                    command = val;
                }
            }
            //    if (input == "quit")
            //{
            //    command = SpecialCommand.quit;
            //}

            //if (input == "help")
            //{
            //    command = SpecialCommand.help;
            //}

            //if (input == "reset")
            //{
            //    command = SpecialCommand.reset;
            //}
        }
        #endregion

        #region PROCESS USER INPUT
        private static void ValidateUserInput(string input)
        {
            // check if input is command, if yes then set input type, if no then check if input is valid
            if (IsInputValidAValidCommand(input))
            {
                enteredACommand = true; // set to ture so that in main a command is executed instead of normal operations
                SetCommandType(input);
            }           
            else if (!IsUserInputValid(input))
            {
                Console.WriteLine($"enter a valid {GetCurrentInputType()} \n");
            }
        }

        #region VALIDATE USER INPUT
        public static bool IsUserInputValid(string input)
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
                    case InputType.Number:
                        isInputValid = ValidateOperation(input);
                        break;
                    case InputType.Operation:
                        isInputValid = ValidateNumber(input);
                        break;
                }
            }

            return isInputValid;
        }

        public static bool IsInputValidAValidCommand(string input)
        {
            bool isInputValid = false;

            if (input == "quit" || input == "help" || input == "reset")
            {
                isInputValid = true;
            }
            return isInputValid;
        }
        public static bool ValidateNumber(string input)
        {
            bool isInputValid = ProceesNumberInput(input);           
            return isInputValid;
        }
        private static bool ProceesNumberInput(string input)
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
