using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterLib
{
    internal class Time : IValue
    {
        private string _name = "Время";

        public string GetName()
        {
            return _name;
        }

        private Dictionary<string, double> _coefList = new Dictionary<string, double>()
        {
            { "милисекунды",    0.001 },
            { "секунды",        1 },
            { "минуты",         60 },
            { "часы",           60*60 }
        };

        public Dictionary<string, double> GetCoefDict()
        {
            return _coefList;
        }
    }
}
