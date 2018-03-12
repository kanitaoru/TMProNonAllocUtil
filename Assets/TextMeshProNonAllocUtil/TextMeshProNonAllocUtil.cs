using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Kani.TMPro
{
    public static class NumberToCharArrayExtentions
    {
        public static int GetDigitsSize(this int self)
        {
            if (self == 0) return 1;
            return (int)System.Math.Log10(self) + 1;
        }

        public static int ToCharsNonAlloc(this int self, char[] output, int start = 0)
        {
            const int zero = '0';

            bool negative = System.Math.Sign(self) == -1;

            if (negative)
            {
                output[start] = '-';
                start++;
                self *= -1;
            }

            int digitsNum = self.GetDigitsSize();

            for (int i = digitsNum - 1; i >= 0; --i)
            {
                int digit = self % 10;
                output[start + i] = (char)(digit + zero);
                self /= 10;
            }

            if (negative)
            {
                digitsNum++;
            }

            return digitsNum;
        }
    }

    public static class TMPNonAllocUtil
    {
        public static char[] _chars = new char[20];

        public static void Expand(int size)
        {
            if (size > _chars.Length)
            {
                _chars = new char[size];
                Debug.LogFormat("Expand chars container => {0}", size);
            }
        }

        public static void SetCharNonAlloc(this TMP_Text text, int number, string unit = null)
        {
            var length = number.ToCharsNonAlloc(_chars);

            if (!string.IsNullOrEmpty(unit))
            {
                _chars[length] = unit[0];
                length++;
            }

            text.SetCharArray(_chars, 0, length);
        }
    }
}
