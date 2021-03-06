﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorClassLibrary
{
    public class Memory
    {
        #region MEMBERS
        // varibles needed for the list command 
        // used to save user input and calculation internally so they can be shown later 
        public static List<string> Memory_userInputs { get; set; }
        public static List<double> Memory_results { get; set; }
        #endregion

        static Memory()
        {
            // Instantiate properties
            Memory_userInputs = new List<string>();
            Memory_results = new List<double>();
        }

        #region METHODS
        private static void AppanedResultToDisplay(StringBuilder display, ref int j)
        {
            display.Append(" = " + Memory_results[j].ToString());
            j += 1;
        }
        public static void SaveInputToMemory(string input)
        {
            Memory_userInputs.Add(input);
        }
        public static void SaveResultToMemory(double result)
        {
            Memory_results.Add(result);
        }
        public static StringBuilder BuildMemory()
        {

            StringBuilder display = new StringBuilder();   // Used to create a displayable version of memory 
            bool TempConversion = false;                   // Used to handle special commands
            int j = 0;                                     // Index to manually keep track of the memory_results list
            int x = 0;                                     // Index to know where to add paranthesis to keep formulas math correct with list command

            for (int i = 0; i < Memory.Memory_userInputs.Count; i++)
            {
                // Handeling temp conversion
                // If temp conversion is entered, break line and show it on a seperate line
                if (Memory_userInputs[i] == "C" || Memory_userInputs[i] == "F")
                {
                    TempConversion = true;

                    AppanedResultToDisplay(display, ref j);
                    display.AppendLine();
                    display.Append(Memory_userInputs[i]);
                    display.Append(Memory_userInputs[i + 1]);
                    AppanedResultToDisplay(display, ref j);
                    string unit = (Memory_userInputs[i] == "C") ? "F" : "C";
                    display.Append(unit);
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
                    if (Memory_userInputs[i] == "*" || Memory_userInputs[i] == "/")
                    {
                        display.Insert(x, "(");
                        display.Append(")");
                    }

                    // append input to display list
                    display.Append(Memory_userInputs[i]);


                    // Show results for the final line
                    if (i == Memory_userInputs.Count - 1)
                    {
                        display.Append(" = " + Core.Result);
                    }
                }
            }

            return display;
        }

        public static void ResetMemory()
        {
            Memory_results.Clear();
            Memory_userInputs.Clear();
        }
        public static void ResetConsole()
        {
            Core.Result = 0;
            Core.PreviousInputType = Enumrations.InputType.Operation;
            Core.LastOperationType = Enumrations.OperationType.none;
        }
        #endregion

    }
}
