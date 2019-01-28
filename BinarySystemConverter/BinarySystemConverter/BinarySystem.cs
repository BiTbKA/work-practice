using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySystemConverter
{
    public class BinarySystem : INumberSystem
    {
        public string Value { get { return ValueDecimal.ToString(); } }

        public string Result { get { return String.Join("", this.ResultBinary); } }

        public Stack<int> ResultBinary { get; set; }

        public int ValueDecimal { get; set; }

        public BinarySystem(int value)
        {
            this.ValueDecimal = value;
            this.ConvertValue();
        }
                
        public void ConvertValue()
        {
            int value = this.ValueDecimal;
            var result = new Stack<int>();

            while (value > 0)
            {
                if (value % 2 == 0)
                {
                    result.Push(0);
                }
                else result.Push(1);

                value /= 2;
            }

            result.Reverse();
            this.ResultBinary = result;
        }
    }
}
