using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterLib.Values
{
    internal class Speed : IValue
    {
        private string _name = "Скорость";

        public string GetName()
        {
            return _name;
        }

        private Dictionary<string, double> _coefList = new Dictionary<string, double>()
        {
            { "микрометры",         0.000001 },
            { "милиметры",          0.001 },
            { "сантиметры",         0.01 },
            { "дециметры",          0.1 },
            { "метры",              1 },
            { "километры",          1000 }
        };

        public Dictionary<string, double> GetCoefDict()
        {
            return _coefList;
        }
    }
}
