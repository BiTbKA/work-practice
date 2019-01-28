using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BinarySystemConverter
{
    public static class Converter
    {
        public static DecimalSystem ConvertToDecimal(Stack<int> value)
        {
            return new DecimalSystem(value);
        }

        public static DecimalSystem ConvertToDecimal(string value)
        {
            return ConvertToDecimal(ParseStringToStack(value));
        }

        public static BinarySystem ConvertToBinary(int value)
        {
            return new BinarySystem(value);
        }

        public static Stack<int> ParseStringToStack(string input)
        {
            var regEx = new Regex("^[10]+$");
            if (!regEx.IsMatch(input))
                throw new Exception("Please enter the binary number");

            var result = new Stack<int>();

            for (int i = 0; i < input.Count(); i++)
            {
                result.Push(Int16.Parse(input[i].ToString()));
            }

            return result;
        }
    }
}
