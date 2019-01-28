using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySystemConverter
{
    public class DecimalSystem : INumberSystem
    {
        public string Value { get { return String.Join("", this.ValueBinary); } }

        public string Result { get { return ResultDecimal.ToString(); } }

        public int ResultDecimal { get; set; }  

        public Stack<int> ValueBinary { get; set; }

        public DecimalSystem(Stack<int> value)
        {
            this.ValueBinary = new Stack<int>(value);
            this.ConvertValue();
        }
        
        public void ConvertValue()
        {
            int result = 0;
            var value = new Stack<int>(this.ValueBinary);
            int count = value.Count;
            for (int i = 0; i < count; i++)
            {
                int val = value.Pop();
                result += val * Convert.ToInt32(Math.Pow(2, i));
            }

            this.ResultDecimal = result;
        }
    }
}
