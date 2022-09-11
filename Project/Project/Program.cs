﻿using Newtonsoft.Json;
using Project.AProcesses;
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
            User u=null;
            
            LoginPage.FirstMenu(out choise);
            if (choise == 2)
                u = LoginPage.Register();
            else if (choise == 1)
                u = LoginPage.Login();
            else if (choise == 0)
                AdditionalProcesses.Exit();
            else
                throw new AbnormalValueException();

            MainMenu.Menu(u);
            



            




            /*-------------------------------------------------------------------------*/
            //ExitLabel:
            //AdditionalProcesses.End();
        }

    }

}
