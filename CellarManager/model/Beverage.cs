using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellarManager.model
{
    public class Beverage
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Producer { get; set; }
        public double AlcoholContent { get; set; }

        public Beverage(string name, decimal price, int stock, string producer, double alcoholContent)
        {
            Name = name;
            Price = price;
            Stock = stock;
            Producer = producer;
            AlcoholContent = alcoholContent;
        }
    }
}
