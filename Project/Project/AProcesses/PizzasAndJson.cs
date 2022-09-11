using Newtonsoft.Json;
using Project.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Project.AProcesses
{
    static class PizzasAndJson
    {
        static string PizzaPath = "C:\\Users\\asus\\OneDrive\\Desktop\\Code Academy\\Console Project\\Project\\Project\\Files\\Products.json";
        public static List<Pizza> ReadFromJson()
        {
            List<Pizza> pizzas = new List<Pizza>();
            using (StreamReader sr = new StreamReader(PizzaPath))
            {
                pizzas = JsonConvert.DeserializeObject<List<Pizza>>(sr.ReadToEnd());
            }
            return pizzas;
        }

        public static void AddToJson(Pizza p)
        {
            List<Pizza> pizzas = ReadFromJson();
            int MaxId = 1;
            foreach (Pizza pizza in pizzas)
            {
                if (pizza.Id > MaxId)
                    MaxId = pizza.Id;
            }
            p.Id = MaxId + 1;
            pizzas.Add(p);

            using (StreamWriter sw = new StreamWriter(PizzaPath))
            {
                sw.Write(JsonConvert.SerializeObject(pizzas));
            }
        }
    }
}
