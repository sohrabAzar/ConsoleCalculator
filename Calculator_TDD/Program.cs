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
                    ShowConsolePromot(Core.previousInputType);
                    userInput = Console.ReadLine();
                    ValidateUserInput(userInput);

                } while (!InputValidator.IsUserInputValidMath(userInput));

                // Process data based on what was entered
                // Command processing
                if (Commands.enteredACommand)
                {
                    ExecuteCommand();
                    Commands.enteredACommand = false;    // set false so you can go to normal operations after command executed
                }
                // Operations and numbers processing
                else
                {
                    switch (Core.GetCurrentInputType())
                    {
                        case Enumrations.InputType.Operation:
                            Core.previousInputType = Enumrations.InputType.Operation;
                            Core.SetOperationType(userInput);
                            break;
                        case Enumrations.InputType.Number:
                            Core.previousInputType = Enumrations.InputType.Number;
                            Core.CalculateResult();
                            DisplayResult();
                            break;
                    }
                }
            }
        }
      
        #region **** MEMBERS ****
        private static bool quit = false;                                       // used to exit program main while loop  
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
         private static void DisplayResult()
        {
            if (Core.lastOperationType != Enumrations.OperationType.none)
            {
                Console.WriteLine("= " + Core.result + "\n");

                // if temp conversion operation reset calculrator. This can be taken out as well if you want to continue using the result
                if (Core.lastOperationType == Enumrations.OperationType.convertCelsiusToFarenhit || Core.lastOperationType == Enumrations.OperationType.convertFarenhitToCelsius)
                {
                    Memory.ResetConsole();
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
                    Memory.Reset();
                    break;

                case Enumrations.SpecialCommand.newton:
                    Commands.Newton();
                    break;
                default:
                    break;
            }
        }
        private static void DisplayMemory()
        {
            StringBuilder display = Memory.BuildMemory();
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
                Commands.enteredACommand = true; // set to ture so that in main a command is executed instead of normal operations
                Commands.SetCommandType(input);
            }
            // if input not command, check if valid math (numbers and signs), if so add it to memory, if not ask again
            else
            {              
                if (InputValidator.IsUserInputValidMath(input))
                {
                    Memory.SaveInputToMemory(input);
                }
                else
                {
                    Console.WriteLine($"enter a valid {Core.GetCurrentInputType()} \n");
                }
            }

        }
        #endregion


    }
}
