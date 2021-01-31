using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorClassLibrary
{
    public class Commands
    {
        #region MEMBERS
        // used to process special commands in main
        public static bool EnteredACommand { get; set; }
        // used for keeping track of which special command was entered
        public static Enumrations.SpecialCommand Command { get; set; } = Enumrations.SpecialCommand.none;        
        #endregion

        #region EVENTS
        //Delegate to call list command in main
        public delegate void ListCommand();
        public static event ListCommand OnListCommandCalled;

        //Delegate to call quit command in main
        public delegate void QuitCommand();
        public static event QuitCommand OnQuitCommandCalled;
        #endregion

        #region METHODS
        public static void ExecuteCommand()
        {
            switch (Command)
            {
                case Enumrations.SpecialCommand.none:
                    break;

                case Enumrations.SpecialCommand.quit:
                    if (OnQuitCommandCalled != null)
                    {
                        OnQuitCommandCalled();
                    }
                    else
                    {
                        // Throw execption when Event is not hooked up so program crashes and developers addresses it before release
                        throw new NullReferenceException("Event for showing list of operations is not hooked up in any subscriber, must hook it up in the project that is consuming this library");
                    }
                    break;

                case Enumrations.SpecialCommand.help:
                    Console.Clear();
                    Commands.IntroduceProgram();
                    break;

                case Enumrations.SpecialCommand.list:
                    if (OnListCommandCalled != null)
                    {
                        OnListCommandCalled();
                    }
                    else
                    {
                        // Throw execption when Event is not hooked up so program crashes and developers addresses it before release
                        throw new NullReferenceException("Event for showing list of operations is not hooked up in any subscriber, must hook it up in the project that is consuming this library");
                    }
                    //try
                    //{
                    //    OnListCommandCalled();
                    //}
                    //catch (NullReferenceException ex)
                    //{
                    //    Console.WriteLine(ex.Message);
                    //    Console.WriteLine("Event for showing list of operations is not hooked up in any subscriber, must hook it up in the project that is consuming this library");
                    //    Console.WriteLine(ex.StackTrace);
                    //}
                    break;

                case Enumrations.SpecialCommand.reset:
                    Console.Clear();
                    Reset();
                    break;

                case Enumrations.SpecialCommand.newton:
                    Commands.Newton();
                    break;
                default:
                    break;
            }
        }
        public static void SetCommandType(string input)
        {


            foreach (Enumrations.SpecialCommand val in Enum.GetValues(typeof(Enumrations.SpecialCommand)))
            {
                if (input == val.ToString())
                {
                    Command = val;
                }
            }
        }
        #region commands
        private static void Reset()
        {
            Memory.ResetMemory();
            Memory.ResetConsole();
        }
        #region newton
        public static void Newton()
        {
            double m;
            double a;

            Memory.ResetConsole();

            Console.WriteLine("\nm(mass) * a(acceleration) = F(force)");
            
            GetNewtonsLawInput("m", out m);
            GetNewtonsLawInput("a", out a);

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
        public static void IntroduceProgram()
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
        #endregion
        #endregion







    }
}
