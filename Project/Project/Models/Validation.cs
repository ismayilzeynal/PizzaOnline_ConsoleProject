using System;
using System.Collections.Generic;
using System.Text;
using Project.Extensions;

namespace Project.Models
{
    static class Validation
    {
        public static bool UsernameValidation(string UName)
        {
            Console.Clear();
            if (UName.Length > 2 && UName.Length < 17)
                return true;
            return false;
        }

        public static bool PasswordValidation(string pass)
        {
            Console.Clear();
            if (pass.Length > 5 && pass.Length < 17 && ContainingSymbols.IsContainDigit(pass) && ContainingSymbols.IsContainLowercase(pass) && ContainingSymbols.IsContainUppercase(pass))
                return true;
            else
                return false;
        }

        public static bool NameValidation(string name)
        {
            Console.Clear();
            if (name.Length > 2 && name.Length < 37)
                return true;
            return false;
        }

        




    }
}
