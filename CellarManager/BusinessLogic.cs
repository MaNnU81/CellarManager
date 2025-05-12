using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellarManager.model;

namespace CellarManager
{
    internal class BusinessLogic : ILogic
    {
        private IStorage _storage;
        public List<Beverage> Beverages { get; set; }

        public BusinessLogic(IStorage storage)
        {
            _storage = storage;
            Beverages = _storage.LoadAllBeverages() ?? new List<Beverage>();
        }

        public void AddBeer(string name, decimal price, int stock, string producer,
                          double alcoholContent, string beerType, int ibu)
        {
            var beer = new Beer(
                name: name,
                price: price,
                stock: stock,
                producer: producer,
                alcoholContent: alcoholContent,
                beerType: beerType,
                ibu: ibu
            );
            Beverages.Add(beer);
            _storage.SaveAllBeverages(Beverages);
        }

        public void AddWine(string name, decimal price, int stock, string producer,
                          double alcoholContent, string wineType, int vintage, string region)
        {
            var wine = new Wine(
                name: name,
                price: price,
                stock: stock,
                producer: producer,
                alcoholContent: alcoholContent,
                wineType: wineType,
                vintage: vintage,
                region: region
            );
            Beverages.Add(wine);
            _storage.SaveAllBeverages(Beverages);
        }

        public List<Beverage> GetAllBeverages()
        {
            return Beverages;
        }
    }
}
