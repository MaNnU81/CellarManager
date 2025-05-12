using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellarManager.model
{
    public class Wine : Beverage
    {
        public string WineType { get; set; }
        public int Vintage { get; set; }
        public string Region { get; set; }

        public Wine(string name, decimal price, int stock, string producer,
                   double alcoholContent, string wineType, int vintage, string region)
                   : base(name, price, stock, producer, alcoholContent)
        {
            WineType = wineType;
            Vintage = vintage;
            Region = region;
        }

        public override string ToString()
        {
            return $"[VINO] {Name} ({WineType}, {Vintage}), {Region}, {AlcoholContent}% alc.\n" +
                   $"Produttore: {Producer}, Prezzo: {Price:C}, Stock: {Stock}";
        }
    }
}
