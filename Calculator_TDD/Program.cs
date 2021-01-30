using System;
using System.Collections.Generic;
using System.Text;
using CalculatorClassLibrary;

namespace Calculator_TDD
{
    public class Program
    {
        static void Main(string[] args)
        {
            string userInput;

            Commands.IntroduceProgram();
            
            while (!quit)
            {
                // Get Input and validate, only process if data is valid
                do
                {
                    ShowConsolePromot(previousInputType);
                    userInput = Console.ReadLine();
                    ValidateUserInput(userInput);

                } while (!InputValidator.IsUserInputValidMath(userInput, enteredACommand, previousInputType, ref currentEnteredNumber));

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
                        case Enumrations.InputType.Operation:
                            previousInputType = Enumrations.InputType.Operation;
                            Core.SetOperationType(userInput, ref lastOperationType);
                            break;
                        case Enumrations.InputType.Number:
                            previousInputType = Enumrations.InputType.Number;
                            Core.CalculateResult(currentEnteredNumber, ref result, lastOperationType);
                            DisplayResult();
                            break;
                    }
                }
            }
        }
      
        #region **** MEMBERS ****


        public static Enumrations.InputType previousInputType = Enumrations.InputType.Operation;
        public static Enumrations.OperationType lastOperationType = Enumrations.OperationType.none;
        public static double result = 0;                                        // keeps track of the calculation results
        public static double currentEnteredNumber = 0;                          // keeps track of the enetered number, was added during refactoring process number func to avoid doing same thing in validate and calculate funcs

        private static bool quit = false;                                       // used to exit program main while loop
        private static Enumrations.SpecialCommand command = Enumrations.SpecialCommand.none;            // used for keeping track of which special command was entered
        private static bool enteredACommand = false;                            // used to process special commands in main

        // varibles needed for the list command 
        // used to save user input and calculation internally so they can be shown later 
        public static List<string> memory_userInputs = new List<string>();
        public static List<double> memory_results = new List<double>();

        #endregion

        #region **** METHODS ****

        private static void ShowConsolePromot(Enumrations.InputType lastInputType)
        {
            switch (lastInputType)
            {
                case Enumrations.InputType.Number:
                    Console.Write("OPERATION >");
                    break;
                case Enumrations.InputType.Operation:
                    Console.Write("NUMBER >");
                    break;
            }
        }

        private static Enumrations.InputType GetCurrentInputType()
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

        private static void DisplayResult()
        {
            if (lastOperationType != Enumrations.OperationType.none)
            {
                Console.WriteLine("= " + result + "\n");

                // if temp conversion operation reset calculrator. This can be taken out as well if you want to continue using the result
                if (lastOperationType == Enumrations.OperationType.convertCelsiusToFarenhit || lastOperationType == Enumrations.OperationType.convertFarenhitToCelsius)
                {
                    Memory.ResetConsole(out result, out previousInputType, out lastOperationType);
                }             
            }
        }

        #region ** COMMANDS **

        private static void ExecuteCommand()
        {
            switch (Commands.command)
            {
                case Enumrations.SpecialCommand.none:
                    break;

                case Enumrations.SpecialCommand.quit:
                    quit = true;
                    break;

                case Enumrations.SpecialCommand.help:
                    Console.Clear();
                    Commands.IntroduceProgram();
                    break;

                case Enumrations.SpecialCommand.list:
                    DisplayMemory();
                    break;

                case Enumrations.SpecialCommand.reset:
                    Console.Clear();
                    Memory.Reset(out result, out previousInputType, out lastOperationType);
                    break;

                case Enumrations.SpecialCommand.newton:
                    Commands.Newton(out result, out previousInputType, out lastOperationType);
                    break;
                default:
                    break;
            }
        }
        #region list
        private static void DisplayMemory()
        {
            StringBuilder display = Memory.BuildMemory(result);
            Console.WriteLine(display + "\n");
        }

        #endregion
        #endregion
       
        #region ** PROCESS USER INPUT **
        private static void ValidateUserInput(string input)
        {
            // check if input is command, if yes then set input type, if no then check if input is valid
            if (InputValidator.IsInputAValidCommand(input))
            {
                enteredACommand = true; // set to ture so that in main a command is executed instead of normal operations
                Commands.SetCommandType(input);
            }
            // if input not command, check if valid math (numbers and signs), if so add it to memory, if not ask again
            else
            {              
                if (InputValidator.IsUserInputValidMath(input, enteredACommand, previousInputType, ref currentEnteredNumber))
                {
                    Memory.SaveInputToMemory(input);
                }
                else
                {
                    Console.WriteLine($"enter a valid {GetCurrentInputType()} \n");
                }
            }

        }
        #endregion
        #endregion

    }
}
