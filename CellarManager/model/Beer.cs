using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellarManager.model
{
    public class Beer : Beverage
    {
        public string BeerType { get; set; }
        public int Ibu { get; set; }

        public Beer(string name, decimal price, int stock, string producer,
                   double alcoholContent, string beerType, int ibu)
                   : base(name, price, stock, producer, alcoholContent)
        {
            BeerType = beerType;
            Ibu = ibu;
        }

        public override string ToString()
        {
            return $"[BIRRA] {Name} ({BeerType}), {AlcoholContent}% alc., IBU: {Ibu}\n" +
                   $"Produttore: {Producer}, Prezzo: {Price:C}, Stock: {Stock}";
        }
    }
}
