using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Exceptions
{
    class AbnormalValueException:Exception
    {
        public AbnormalValueException()
        {
            Console.WriteLine("value is outside the given conditions");
        }
    }
}
