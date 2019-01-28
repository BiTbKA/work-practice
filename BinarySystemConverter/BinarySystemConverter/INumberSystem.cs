using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySystemConverter
{
    public interface INumberSystem
    {
        string Value { get; }

        string Result { get; }

        void ConvertValue();
    }
}
