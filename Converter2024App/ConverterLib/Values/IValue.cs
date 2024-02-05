using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterLib
{
    internal interface IValue
    {
        public Dictionary<string, double> GetCoefDict();
        public string GetName();
    }
}
