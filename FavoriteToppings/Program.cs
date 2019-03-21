using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FavoriteToppings
{
    class Program
    {
        static void Main(string[] args)
        {
            var allThePizzas = File.ReadAllText(@"../../../pizzas.json");
            List<Pizza> allTheOrders = JsonConvert.DeserializeObject<List<Pizza>>(allThePizzas);

            //Convert the pizzas
            var convertedPizzas = allTheOrders.Select(x => x.ToString());

            //Group the pizzas
            var groupedPizzas = convertedPizzas.GroupBy(x => x);

            //Order them descending
            var orderedPizzas = groupedPizzas.OrderByDescending(x => x.Count());

            //Assign them to key-value-pairs
            var keyedPizzas = orderedPizzas.Select(x => new { x.Key, Quantity = x.Count() });

            //The top 20 orders
            var gimmeTwenty = keyedPizzas.Take(20);

            foreach (var pizza in gimmeTwenty)
            {
                Console.WriteLine($"{pizza.Key} has been ordered {pizza.Quantity} times.");
            }

            Console.ReadKey();
        }
    }
};