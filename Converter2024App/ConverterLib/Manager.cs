using System.Reflection;

namespace ConverterLib
{
    public class Manager
    {
        public Manager()
        {
            SetValuesList();
        }
        private static List<IValue> _physicValuesList = new List<IValue>();

        /// <summary>
        /// 
        /// </summary>
        private static void SetValuesList()
        {
            Assembly asm = Assembly.LoadFrom("ConverterLib.dll");           // создание сборки из библиотеки классов
            Type[] types = asm.GetTypes();                                  // выгрузка классов в массив
            foreach (Type type in types)                                    // перебираем классы и интерфейсы
            {
                if ((type.IsInterface == false)
                    && (type.IsAbstract == false)
                    && (type.Name != ("AnyValue"))                          // добавил, чтобы исключить базовый класс
                    && (type.GetInterface("IValue") != null))               // не добавляем абстрактные классы и интерфейсы
                {
                    IValue value = (IValue)Activator.CreateInstance(type);
                    _physicValuesList.Add(value);                           // подгружаем этот класс в писок величин                        
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<string> GetPhysicValuesList()
        {
            
            List<string> values = new List<string>();

            foreach (var value in _physicValuesList)
            {
                values.Add(value.GetName());
            }
            return values;
        }
        private IValue _value;


        private void SetIValue(string physicValue)
        {
            foreach (var value in _physicValuesList)
            {
                if (value.GetName() == physicValue)
                {
                    _value = value;
                }
            }
        }

        public List<string> GetMeasureList(string physicValue)
        {
            SetIValue(physicValue);
            List<string> measures = new List<string>();

            foreach (var i in _value.GetCoefDict())
            {
                measures.Add(i.Key);
            }
            return measures;
        }

        public double GetConvertedValue(double num, string valueName, string from, string to)
        {
            SetIValue(valueName);
            num *= _value.GetCoefDict()[from];
            num /= _value.GetCoefDict()[to];
            return num;
        }


    }
}