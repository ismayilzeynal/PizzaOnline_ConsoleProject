using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Exceptions
{
    class InvalidInputException:Exception
    {
        public InvalidInputException()
        {
            Console.WriteLine("Invalid input");
        }
    }
}
