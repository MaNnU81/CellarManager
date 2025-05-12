using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellarManager.model;

namespace CellarManager
{
    internal interface ILogic
    {
        public void AddBeer(string name, decimal price, int stock, string producer,
                          double alcoholContent, string beerType, int ibu);

        public void AddWine(string name, decimal price, int stock, string producer,
                          double alcoholContent, string wineType, int vintage, string region);

        public List<Beverage> GetAllBeverages();
    }
}
