using System;

namespace Calculator_TDD
{
    public class Program
    {
        public static InputType lastInputType = InputType.Operation;

        static void Main(string[] args)
        {
            ShowConsolePromot(lastInputType);

            //Get user input
            string userInput = Console.ReadLine();

            switch (lastInputType)
            {
                case InputType.Number:
                    /// entering operation
                    // check if input is valid, if yes then move forward if not ask to enter again
                    // Set opration type based on what sign was entered
                    break;
                case InputType.Operation:
                    /// entering number
                    // check if input is valid, if yes then move forward if not ask to enter again
                    // if valid
                    // if first input then set result to it
                    // else based on what operation type that was entered is do operation on result
                    break;
                default:
                    break;
            }
        }

        #region MEMBERS
        public enum InputType
        {
            Number,
            Operation,
        }

        enum OperationType
        {
            none,
            add,
            reduce,
            multiple,
            devide,
            convertCelsiusToFarenhit,
            convertFarenhitToCelsius
        }

        enum SpecialCommand
        {
            quit,
            help,
            list,
            reset
        }
        #endregion

        #region METHODS
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
        #endregion

    }
}
