using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorClassLibrary
{
    public class Commands
    {
        public static bool enteredACommand = false;                            // used to process special commands in main

        public static Enumrations.SpecialCommand command = Enumrations.SpecialCommand.none;            // used for keeping track of which special command was entered
       
        public static void SetCommandType(string input)
        {
            foreach (Enumrations.SpecialCommand val in Enum.GetValues(typeof(Enumrations.SpecialCommand)))
            {
                if (input == val.ToString())
                {
                    command = val;
                }
            }
        }

        public static void Newton()
        {
            double m;
            double a;

            Memory.ResetConsole();

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
    }
}
