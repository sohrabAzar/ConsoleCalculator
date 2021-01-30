using System;
using System.Collections.Generic;
using System.Text;

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

                } while (!IsUserInputValidMath(userInput));

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
      
        #region **** MEMBERS ****
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
            reset,
            newton
        }

        public static InputType previousInputType = InputType.Operation;
        public static OperationType lastOperationType = OperationType.none;
        public static double result = 0;                                        // keeps track of the calculation results
        public static double currentEnteredNumber = 0;                          // keeps track of the enetered number, was added during refactoring process number func to avoid doing same thing in validate and calculate funcs

        private static bool quit = false;                                       // used to exit program main while loop
        private static SpecialCommand command = SpecialCommand.none;            // used for keeping track of which special command was entered
        private static bool enteredACommand = false;                            // used to process special commands in main

        // varibles needed for the list command 
        // used to save user input and calculation internally so they can be shown later 
        public static List<string> memory_userInputs = new List<string>();
        public static List<double> memory_results = new List<double>();

        #endregion

        #region **** METHODS ****

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

                case OperationType.convertCelsiusToFarenhit:
                    SaveResultToMemory(result);
                    result = (currentEnteredNumber * 1.8) + 32;
                    SaveResultToMemory(result);
                    break;

                case OperationType.convertFarenhitToCelsius:
                    SaveResultToMemory(result);
                    result = result = (currentEnteredNumber - 32) / 1.8;
                    SaveResultToMemory(result);
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
                Console.WriteLine("= " + result + "\n");

                // if temp conversion operation reset calculrator. This can be taken out as well if you want to continue using the result
                if (lastOperationType == OperationType.convertCelsiusToFarenhit || lastOperationType == OperationType.convertFarenhitToCelsius)
                {
                    ResetConsole();
                }             
            }
        }

        #region ** COMMANDS **
        private static void SetCommandType(string input)
        {
            foreach (SpecialCommand val in Enum.GetValues(typeof(SpecialCommand)))
            {
                if (input == val.ToString())
                {
                    command = val;
                }
            }
        }
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
                    DisplayMemory();
                    break;

                case SpecialCommand.reset:
                    Console.Clear();
                    Reset();
                    break;

                case SpecialCommand.newton:
                    Newton();
                    break;
                default:
                    break;
            }
        }

        #region reset
        private static void Reset()
        {
            ResetMemory();
            ResetConsole();
        }
        private static void ResetConsole()
        {
            result = 0;
            previousInputType = InputType.Operation;
            lastOperationType = OperationType.none;
        }
        private static void ResetMemory()
        {
            memory_results.Clear();
            memory_userInputs.Clear();
        }
        #endregion

        #region list
        private static void DisplayMemory()
        {
            StringBuilder display = BuildMemory();
            Console.WriteLine(display + "\n");
        }
        public static StringBuilder BuildMemory()
        {

            StringBuilder display = new StringBuilder();   // Used to create a displayable version of memory 
            bool TempConversion = false;                   // Used to handle special commands
            int j = 0;                                     // Index to manually keep track of the memory_results list
            int x = 0;                                     // Index to know where to add paranthesis to keep formulas math correct with list command

            for (int i = 0; i < memory_userInputs.Count; i++)
            {
                // Handeling temp conversion
                // If temp conversion is entered, break line and show it on a seperate line
                if (memory_userInputs[i] == "C" || memory_userInputs[i] == "F")
                {
                    TempConversion = true;

                    AppanedResultToDisplay(display, ref j);
                    display.AppendLine();
                    display.Append(memory_userInputs[i]);
                    display.Append(memory_userInputs[i + 1]);
                    AppanedResultToDisplay(display, ref j);
                    display.AppendLine();

                    // Add next open parathesis in the begin of next line 
                    x = display.ToString().Length;

                }
                // If previous operation was special command then next string in memory is manually added so dont add it again
                else if (TempConversion)
                {
                    TempConversion = false;
                }

                // Handeling normal inputs
                // Append to display list
                else
                {
                    // check if * or /, if so add parantesis before and after to have a mathematically correct formula
                    if (memory_userInputs[i] == "*" || memory_userInputs[i] == "/")
                    {
                        display.Insert(x, "(");
                        display.Append(")");
                    }
                    
                    // append input to display list
                    display.Append(memory_userInputs[i]);


                    // Show results for the final line
                    if (i == memory_userInputs.Count - 1)
                    {
                        display.Append(" = " + result);
                    }
                }
            }
            
            return display;
        }
        private static void AppanedResultToDisplay(StringBuilder display, ref int j)
        {
            display.Append(" = " + memory_results[j].ToString());
            j += 1;
        }
        private static void SaveResultToMemory(double result)
        {
            memory_results.Add(result);
        }
        #endregion

        #region newton
        private static void Newton()
        {
            double m;
            double a;

            ResetConsole();

            Console.WriteLine("\nm(mass) * a(acceleration) = F(force)");

            GetNewtonsLawInput("a", out a);
            GetNewtonsLawInput("m", out m);

            double f = m * a;

            Console.WriteLine($"F = {f}(n) \n");
        }
        private static void GetNewtonsLawInput(string inputType, out double value)
        {
            bool inputIsValid;

            do
            {
                Console.Write($"{inputType}?> ");
                string input_m = Console.ReadLine();
                inputIsValid = double.TryParse(input_m, out value);
                if (!inputIsValid)
                {
                    Console.WriteLine("Enter valid mass\n");
                }
            } while (!inputIsValid);
        }
        #endregion
        #endregion
       
        #region ** PROCESS USER INPUT **
        private static void ValidateUserInput(string input)
        {
            // check if input is command, if yes then set input type, if no then check if input is valid
            if (IsInputAValidCommand(input))
            {
                enteredACommand = true; // set to ture so that in main a command is executed instead of normal operations
                SetCommandType(input);
            }
            // if input not command, check if valid math (numbers and signs), if so add it to memory, if not ask again
            else
            {              
                if (IsUserInputValidMath(input))
                {
                    SaveInputToMemory(input);
                }
                else
                {
                    Console.WriteLine($"enter a valid {GetCurrentInputType()} \n");
                }
            }

        }
        private static void SaveInputToMemory(string input)
        {
            memory_userInputs.Add(input);
        }

        #region validate input
        public static bool IsUserInputValidMath(string input)
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

        public static bool IsInputAValidCommand(string input)
        {
            bool isInputValid = false;

            if (input == "quit" || input == "help" || input == "reset" || input == "newton" || input == "list")
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
