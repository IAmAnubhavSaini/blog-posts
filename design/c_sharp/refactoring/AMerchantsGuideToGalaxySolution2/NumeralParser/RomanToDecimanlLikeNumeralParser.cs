﻿using System;
using Languages;

namespace NumeralParser
{
    public class RomanToDecimanlLikeNumeralParser<T> where T : IProvideLanguage, new()
    {
        private readonly T Language = new T();

        int GetValue(string input, int pos)
        {
            return pos < input.Length ? Language.ConversionData[input[pos]] : 0;
        }

        int GetNextValue(string input, int pos)
        {
            return (pos < input.Length - 1) ? Language.ConversionData[input[pos + 1]] : 0;
        }

        public int ParseNumber(string input)
        {
            CheckSanity(input);
            var value = 0;
            var tmpValue = 0;
            try
            {
                int i;
                for (i = 0; i < input.Length; ++i, tmpValue = 0)
                {
                    var currentValue = GetValue(input, i);
                    var nextValue = GetNextValue(input, i);

                    if (nextValue != 0)
                    {
                        if (currentValue > nextValue)
                        {
                            tmpValue += currentValue;
                            value += tmpValue;
                            continue;
                        }
                        if (currentValue == nextValue)
                        {
                            tmpValue += (currentValue * 2);
                            ++i;
                            value += tmpValue;
                        }
                        if (currentValue < nextValue)
                        {
                            tmpValue -= currentValue;
                            tmpValue += nextValue;
                            value += tmpValue;
                            ++i;
                        }

                    }
                    else // if !next
                    {
                        if (i == input.Length - 1)
                        {
                            value += currentValue;
                        }
                    }
                }
            }
            catch (NullReferenceException nrex)
            {
                Console.WriteLine("Something is not initialized. Was there any error in input?");
                Console.WriteLine("Exception : " + nrex.Message);
            }
            return value;

        }

        private void CheckSanity(string input)
        {
            foreach(var action in Language.SanityRules())
            {
                action(input);
            }
        }
    }
}
