using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellarManager.model;

namespace CellarManager
{
    internal class CsvStorage : IStorage
    {
        private readonly string _filePath = "beverages.csv";

        public List<Beverage> LoadAllBeverages()
        {
            var beverages = new List<Beverage>();

            if (!File.Exists(_filePath))
                return beverages;

            try
            {
                var lines = File.ReadAllLines(_filePath);

                foreach (var line in lines.Skip(1)) // Skip header
                {
                    var values = line.Split(';');

                    if (values[0] == "Beer")
                    {
                        beverages.Add(new Beer(
                            name: values[1],
                            price: decimal.Parse(values[2]),
                            stock: int.Parse(values[3]),
                            producer: values[4],
                            alcoholContent: double.Parse(values[5]),
                            beerType: values[6],
                            ibu: int.Parse(values[7])
                        ));
                    }
                    else if (values[0] == "Wine")
                    {
                        beverages.Add(new Wine(
                            name: values[1],
                            price: decimal.Parse(values[2]),
                            stock: int.Parse(values[3]),
                            producer: values[4],
                            alcoholContent: double.Parse(values[5]),
                            wineType: values[6],
                            vintage: int.Parse(values[7]),
                            region: values[8]
                        ));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore nel caricamento dei dati: {ex.Message}");
            }

            return beverages;
        }

        public void SaveAllBeverages(List<Beverage> beverages)
        {
            try
            {
                var lines = new List<string>
                {
                    // Header
                    "Type;Name;Price;Stock;Producer;AlcoholContent;BeerType/WineType;IBU/Vintage;Region"
                };

                foreach (var beverage in beverages)
                {
                    if (beverage is Beer beer)
                    {
                        lines.Add(
                            $"Beer;{beer.Name};{beer.Price};{beer.Stock};{beer.Producer};" +
                            $"{beer.AlcoholContent};{beer.BeerType};{beer.Ibu};"
                        );
                    }
                    else if (beverage is Wine wine)
                    {
                        lines.Add(
                            $"Wine;{wine.Name};{wine.Price};{wine.Stock};{wine.Producer};" +
                            $"{wine.AlcoholContent};{wine.WineType};{wine.Vintage};{wine.Region}"
                        );
                    }
                }

                File.WriteAllLines(_filePath, lines);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore nel salvataggio dei dati: {ex.Message}");
            }
        }
    }
}
