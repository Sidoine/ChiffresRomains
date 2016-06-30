using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiffresRomains
{
    class ChiffresRomains
    {
        static Dictionary<int, string> symbols = new Dictionary<int, string>
                                              {
            {  1, "I"},
            { 5, "V" },
            { 10, "X" },
            { 50, "L" },
            {
                100, "C"
            },
            { 500, "D" },
            { 1000, "M" }
        };

        private static Dictionary<char, int> invert; 

        static ChiffresRomains()
        {
            invert = symbols.ToDictionary(x => x.Value[0], x => x.Key);
        }

        public int ConvertToDigits(string roman)
        {
            int result = 0;
            for (var i = 0; i < roman.Length; i++)
            {
                int value = invert[roman[i]];
                if (i < roman.Length - 1)
                {
                    int next = invert[roman[i + 1]];
                    if (next > value) result -= value;
                    else result += value;
                }
                else
                {
                    result += value;
                }
            } 
            return result;
        }

        public string ConvertToRoman(int nombre)
        {
            if (nombre <= 0 || nombre > 3000)
            {
                throw new InvalidOperationException();
            }

            var result = new StringBuilder();
            var orderedSymbols = symbols.OrderByDescending(x => x.Key).ToList();
            foreach (var symbol in orderedSymbols)
            {
                var quotient = nombre / symbol.Key;
                if (quotient > 3 && CanSubstract(symbol.Key))
                {
                    // do stuff
                    nombre += symbol.Key;
                    result.Append(symbol.Value);
                    result.Append(ConvertToRoman(nombre));
                    return result.ToString();
                }
                else
                {
                    nombre = nombre % symbol.Key;
                    for (var i = 0; i < quotient; i++)
                        result.Append(symbol.Value);

                    if (CanSubstract(symbol.Key) && nombre > 1 && nombre >= 9 * symbol.Key / 10)
                    {
                        result.Append(symbols[symbol.Key / 10]);
                        result.Append(symbols[symbol.Key]);
                        nombre -= symbol.Key * 9 / 10;
                    }
                }
            }
            return result.ToString();
        }

        private bool CanSubstract(int key)
        {
            return key == 1 || key == 10 || key == 100 || key == 1000;
        }


    }
}
