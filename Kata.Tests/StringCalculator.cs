using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.Tests
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            int result = 0;
            List<string> delimiters = new List<string>(){",", "\n"};

            if (numbers.Length == 0)
            {
                return 0;
            }

            if (numbers.Length > 2 && numbers.Substring(0, 2) == "//")
            {
                int posOfFirstNewLine = numbers.IndexOf("\n");
                var substring = numbers.Substring(2, posOfFirstNewLine - 2);

                var delims = substring.Split(new char[] { '[', ']' });

                foreach (var delim in delims)
                {
                    if (delim != "")
                        delimiters.Add(delim);
                }

                numbers = numbers.Substring(posOfFirstNewLine + 1, numbers.Length - posOfFirstNewLine -1);
            }

            string[] splitnumbers = numbers.Split(delimiters.ToArray(), StringSplitOptions.None);
            
            if (splitnumbers.Length == 1)
            {
                result = int.Parse(numbers);

                if (result < 0)
                    throw new ArgumentException(string.Format("negatives not allowed: {0}", result));

                if (result > 1000)
                    return 0;

                return result;
            }

            List<string> negatives = new List<string>();

            for (int i = 0; i < splitnumbers.Length; i++)
            {
                int number = 0;
                int.TryParse(splitnumbers[i], out number);

                if (number < 0)
                    negatives.Add(splitnumbers[i]);

                if (number <= 1000)
                    result += number;
            }

            if (negatives.Count > 0)
                throw new ArgumentException(string.Format("Negatives not allowed: {0}", string.Join(",", negatives)));

            return result;

        }
    }
}
