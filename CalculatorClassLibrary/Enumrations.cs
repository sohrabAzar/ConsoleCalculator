using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorClassLibrary
{
    public static class Enumrations
    {
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
    }

    

}
