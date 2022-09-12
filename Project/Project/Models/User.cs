using Project.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models
{
    class User
    {
        //ctor
        public User(string username, string password, string name, string surname)
        {
            _id++;
            Id = _id;
            Username = username;
            Password = password;
            Name = name;
            Surname = surname;
        }

        //fields
        private static int _id;
        private string _username;
        private string _password;
        private bool _isAdmin;
        private string _name;
        private string _surname;

        //props
        public int Id { get; set; }
        public bool IsAdmin { get => _isAdmin; set { _isAdmin = value; } }
        public string Username
        {
            get => _username;
            set
            {
                if (Validation.UsernameValidation(value))
                    _username = value;
            }
        }

        public string Password 
        { 
            get => _password;
            set 
            {
                if(value == "admin")
                    _password = value;
                else if (Validation.PasswordValidation(value))   
                    _password = value;
            }
        }

        public string Name 
        { 
            get => _name; 
            set 
            {
                if (Validation.NameValidation(value))       
                    _name = value;
            } 
        }
        public string Surname
        {
            get => _surname;
            set
            {
                if (Validation.NameValidation(value))
                    _surname = value;
            }
        }
        public void Print()
        {
            Console.WriteLine($"- {Id}.  \nName: {Name} \nUsername: {Username} \nIs admin: {IsAdmin}");
        }



    }
}
