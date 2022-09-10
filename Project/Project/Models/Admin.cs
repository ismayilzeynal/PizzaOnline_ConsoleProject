using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models
{
    class Admin:User
    {
        public Admin(string username, string password, string name, string surname):base(username, password, name, surname)
        {

        }
    }
}
