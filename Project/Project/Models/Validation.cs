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
            if (UName.Length > 2 && UName.Length < 17)
                return true;
            return false;
        }

        public static bool PasswordValidation(string pass)
        {
            if (pass.Length > 5 && pass.Length < 17 && ContainingSymbols.IsContainDigit(pass) && ContainingSymbols.IsContainLowercase(pass) && ContainingSymbols.IsContainUppercase(pass))
                return true;
            else
                return false;
        }
        public static bool NameValidation(string name)
        {
            if (name.Length > 2 && name.Length < 37)
                return true;
            return false;
        }

    }
}
