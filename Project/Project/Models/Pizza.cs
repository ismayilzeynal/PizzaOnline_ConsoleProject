using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models
{
    class Pizza
    {
        //ctor
        public Pizza(string name,float price, List<string> ingridients)
        {
            _id++;
            Id = _id;
            Name = name;
            Price = price;
            Ingridients = ingridients;
        }

        //fields
        private static int _id;
        private string _name;
        private List<string> _ingridients;
        private float _price;

        //props
        public int Count { get; set; }
        public int Id { get; set; }
        public string Name 
        { 
            get =>_name;
            set
            {
                if (Validation.NameValidation(value))
                    _name = value;
            } 
        }

        public float Price { 
            get => _price; 
            set 
            { 
                if (value > 0) 
                    _price = value; 
            } 
        }

        public List<string> Ingridients 
        { 
            get=>_ingridients;
            set 
            {
                if (value != null)
                _ingridients = value;
            }
        }

        public void Print()
        {
            Console.WriteLine($"- {Id}.  \nName: {Name} \nPrice: {Price}");
            Console.WriteLine("Ingridients: ");
            foreach (string ingr in Ingridients)
            {
                Console.WriteLine($"   - {ingr}");
            }
        }
        
    }
}
