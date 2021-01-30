using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorClassLibrary
{
    public class Memory
    {
        // varibles needed for the list command 
        // used to save user input and calculation internally so they can be shown later 
        public static List<string> memory_userInputs = new List<string>();
        public static List<double> memory_results = new List<double>();

        public static void SaveInputToMemory(string input)
        {
            memory_userInputs.Add(input);
        }

        public static void ResetMemory()
        {
            memory_results.Clear();
            memory_userInputs.Clear();
        }

        public static void SaveResultToMemory(double result)
        {
            memory_results.Add(result);
        }

        public static StringBuilder BuildMemory(double result)
        {

            StringBuilder display = new StringBuilder();   // Used to create a displayable version of memory 
            bool TempConversion = false;                   // Used to handle special commands
            int j = 0;                                     // Index to manually keep track of the memory_results list
            int x = 0;                                     // Index to know where to add paranthesis to keep formulas math correct with list command

            for (int i = 0; i < Memory.memory_userInputs.Count; i++)
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

        public static void ResetConsole(out double result, out Enumrations.InputType previousInputType, out Enumrations.OperationType lastOperationType)
        {
            result = 0;
            previousInputType = Enumrations.InputType.Operation;
            lastOperationType = Enumrations.OperationType.none;
        }

        public static void Reset(out double result, out Enumrations.InputType previousInputType, out Enumrations.OperationType lastOperationType)
        {
            ResetMemory();
            ResetConsole(out result, out previousInputType, out lastOperationType);
        }
    }
}
