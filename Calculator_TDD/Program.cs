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
        /// <summary>
        /// Event handler to display memory on list command
        /// </summary>
        private static void ListCommandEventHandler()
        {
            StringBuilder display = Memory.BuildMemory();
            Console.WriteLine(display + "\n");
        }
        /// <summary>
        /// Event handler to quit program
        /// </summary>
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
                // Entering Operation
                case Enumrations.InputType.Number:
                    Console.Write("OPERATION >");
                    break;

                // Enetering Numbers
                case Enumrations.InputType.Operation:

                    // If operation is temp then show console as temp otherwise number
                    switch (Core.LastOperationType)
                    {
                        case Enumrations.OperationType.convertCelsiusToFarenhit:
                            Console.Write("CELSIUS >");
                            break;
                        case Enumrations.OperationType.convertFarenhitToCelsius:
                            Console.Write("FARENHIT >");
                            break;
                        default:
                            Console.Write("NUMBER >");
                            break;
                    }
                
                    break;
            }
        }

        /// <summary>
        /// Used to show results on console after each operation is entered
        /// </summary>
        private static void DisplayResult()
        {
            // Write result on console
            // Check for first uder entry, done since first user entry should not show any results
            bool firstInput = Core.IsFirstUserInput();
            Console.Write(Core.GetCalculationResultForUIDisplay());
            if (!firstInput) 
            { 
                Console.WriteLine("\n"); 
            }
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
                    // If operation is temp then show console as temp otherwise number
                    switch (Core.LastOperationType)
                    {
                        case Enumrations.OperationType.convertCelsiusToFarenhit:
                            Console.WriteLine("ENTER A VALID CELSIUS VALUE\n");
                            break;
                        case Enumrations.OperationType.convertFarenhitToCelsius:
                            Console.WriteLine("ENTER A VALID FARENHEIT VALUE\n");
                            break;
                        default:
                            Console.WriteLine($"ENTER A VALID {Core.GetCurrentInputType()} \n");
                            break;
                    }
                    
                }
            }

        }
        #endregion

        #endregion






    }
}
