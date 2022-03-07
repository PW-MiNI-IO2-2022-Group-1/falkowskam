using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public static class StringCalculator
    {
        public static int CalculateString (string s)
        {
            List<string> separators = new List<string> { ",", "\n" };

            if (string.IsNullOrWhiteSpace(s))
                return 0;

            if(s.StartsWith("//"))
            {
                if(s.ElementAt(2) == '[') separators.Add(s.Substring(3, s.IndexOf(']') - 3));
                else separators.Add(s.ElementAt(2).ToString());
                s = s.Split('\n', 2)[1].ToString();
            }

            int[] numbers = s.Split(separators.ToArray(), StringSplitOptions.None).Select(str => Int32.Parse(str)).Where(number => number <= 1000).ToArray();

            if (numbers.Any(number => number < 0))
                throw new ArgumentException("Negative number");

            return 0;
        }
    }
}
