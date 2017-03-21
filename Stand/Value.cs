using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualStand
{
    /// <summary>
    /// Класс для передачи значений на портах внутрь элементов.
    /// Содержит Dictionary из пар название порта - значение.
    /// </summary>
    class Value
    {
        Dictionary<string, List<bool>> values;
        public Value()
        {
            values = new Dictionary<string, List<bool>>();
        }

        public List<bool> this[string s]
        {
            get
            {
                return values[s];
            }
            set
            {
                values[s] = value;
            }
        }

        public static List<bool> StrToArray(string s, int radix)
        {
            List<bool> list = new List<bool>();
            if (s == "")
                for (int i = 0; i < 4; ++i)
                    list.Add(false);
            else if (s[s.Length - 1] == 'b')
                for (int i = s.Length - 2, j = 0; j < radix; --i, ++j)
                    if (i >= 0)
                        list.Insert(0, s[i] == '1');
                    else
                        list.Insert(0, false);
            else if(s[0] == '0' && s.Length > 1 && (s[1] == 'x' || s[1] == 'X'))
                for (int i = s.Length - 1, j = 0; j < radix; --i)
                    for (int k = 3; k >= 0 && j < radix; --k, ++j)
                        if (i >= 0)
                            list.Insert(0, CharToArray(s[i])[k]);
                        else
                            list.Insert(0, false);
            else
            {
                long num = Convert.ToInt64(s);
                for (int i = 0; i < radix; ++i, num >>= 1)
                    list.Insert(0, (num & 1) == 1);
            }
            return list;
        }

        public static List<bool> CharToArray(char c)
        {
            int number = Convert.ToInt32("" + c, 16);
            List<bool> bin = new List<bool>(4);
            bin[0] = (number & 8) != 0;
            bin[1] = (number & 4) != 0;
            bin[2] = (number & 2) != 0;
            bin[3] = (number & 1) != 0;
            return bin;
        }
    }
}
