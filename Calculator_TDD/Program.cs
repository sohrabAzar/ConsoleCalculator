using System;
using System.Collections.Generic;
using System.Text;
using CalculatorClassLibrary;

namespace Calculator_TDD
{

    public class Program
    {
        static Program()
        {
            // Bind Event handlers
            Commands.OnListCommandCalled += ListCommandEventHandler;
            Commands.OnQuitCommandCalled += QuitCommandEventHandler;
        }

        static void Main(string[] args)
        {
            
            string userInput;

            Commands.IntroduceProgram();
            
            while (!quit)
            {
                // Get Input and validate, only process if data is valid
                do
                {
                    ShowConsolePromot(Core.PreviousInputType);
                    userInput = Console.ReadLine();
                    ValidateUserInput(userInput);

                } while (!InputValidator.IsUserInputValidMath(userInput));

                // Process data based on what was entered
                // Command processing
                if (Commands.EnteredACommand)
                {
                    Commands.ExecuteCommand();
                    Commands.EnteredACommand = false;    // set false so you can go to normal operations after command executed
                }
                // Operations and numbers processing
                else
                {
                    switch (Core.GetCurrentInputType())
                    {
                        case Enumrations.InputType.Operation:
                            Core.PreviousInputType = Enumrations.InputType.Operation;
                            Core.SetOperationType(userInput);
                            break;
                        case Enumrations.InputType.Number:
                            Core.PreviousInputType = Enumrations.InputType.Number;
                            Core.CalculateResult();
                            DisplayResult();
                            break;
                    }
                }
            }
        }

        #region **** MEMBERS ****
        // used to exit program main while loop  
        private static bool quit = false;                                       
        #endregion

        #region **** EVENT HANDLERS ****
        private static void ListCommandEventHandler()
        {
            DisplayMemory();
        }
        private static void QuitCommandEventHandler()
        {
            quit = true;
        }
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
            if (Core.LastOperationType != Enumrations.OperationType.none)
            {
                Console.Write("= " + Core.Result);

                switch (Core.LastOperationType)
                {
                    case Enumrations.OperationType.convertCelsiusToFarenhit:
                        Console.WriteLine("F\n");
                        Memory.ResetConsole();
                        break;
                    case Enumrations.OperationType.convertFarenhitToCelsius:
                        Console.WriteLine("C\n");
                        Memory.ResetConsole();
                        break;
                    default:
                        Console.WriteLine("\n");
                        break;
                }

                //// if temp conversion operation reset calculrator. This can be taken out as well if you want to continue using the result
                //if (Core.LastOperationType == Enumrations.OperationType.convertCelsiusToFarenhit || Core.LastOperationType == Enumrations.OperationType.convertFarenhitToCelsius)
                //{

                //}             
            }
        }

        #region COMMANDS
        private static void DisplayMemory()
        {
            StringBuilder display = Memory.BuildMemory();
            Console.WriteLine(display + "\n");
        }

        #region PROCESS USER INPUT
        private static void ValidateUserInput(string input)
        {
            // check if input is command, if yes then set input type, if no then check if input is valid
            if (InputValidator.IsInputAValidCommand(input))
            {
                Commands.EnteredACommand = true; // set to ture so that in main a command is executed instead of normal operations
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

        #endregion

        #endregion




    }
}
