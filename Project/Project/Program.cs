using Newtonsoft.Json;
using Project.Exceptions;
using Project.Extensions;
using Project.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            int choise;
            User u;
            
            LoginPage.FirstMenu(out choise);
            if (choise == 2)
                LoginPage.Register();
            else if (choise == 1)
                LoginPage.Login();
            else if (choise == 0)
                goto ExitLabel;
            else
                throw new AbnormalValueException();  


            









            /*-------------------------------------------------------------------------*/
            ExitLabel:
            AdditionalProcesses.End();
        }

    }

}
