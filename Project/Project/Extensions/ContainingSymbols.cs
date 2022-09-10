using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Extensions
{
    static class ContainingSymbols
    {
        public static bool IsContainDigit(string str)
        {
            foreach (char ch in str)
            {
                if (ch > 47 && ch < 58)
                    return true;
            }
            return false;
        }

        public static bool IsContainLowercase(string str)
        {
            foreach (char ch in str)
            {
                if (ch > 96 && ch < 123)
                    return true;
            }
            return false;
        }

        public static bool IsContainUppercase(string str)
        {
            foreach (char ch in str)
            {
                if (ch > 64 && ch < 91)
                    return true;
            }
            return false;
        }

    }
}
