using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellarManager
{
    internal class Tui
    {
        private ILogic _logic;

        public Tui(ILogic logic)
        {
            _logic = logic;
        }

        internal void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== GESTIONE CANTINA ===");
                Console.WriteLine("1. Aggiungi birra");
                Console.WriteLine("2. Aggiungi vino");
                Console.WriteLine("3. Visualizza tutte le bevande");
                Console.WriteLine("0. Esci");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddBeer();
                        break;
                    case "2":
                        AddWine();
                        break;
                    case "3":
                        ShowAllBeverages();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Scelta non valida!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void AddBeer()
        {
            Console.Clear();
            Console.WriteLine("=== AGGIUNGI BIRRA ===");

            Console.Write("Nome: ");
            var name = Console.ReadLine();

            Console.Write("Prezzo: ");
            decimal.TryParse(Console.ReadLine(), out decimal price);

            Console.Write("Quantità in stock: ");
            int.TryParse(Console.ReadLine(), out int stock);

            Console.Write("Produttore: ");
            var producer = Console.ReadLine();

            Console.Write("Grado alcolico: ");
            double.TryParse(Console.ReadLine(), out double alcoholContent);

            Console.Write("Stile (IPA, Lager, etc.): ");
            var beerType = Console.ReadLine();

            Console.Write("IBU (livello di amaro): ");
            int.TryParse(Console.ReadLine(), out int ibu);

            try
            {
                _logic.AddBeer(name, price, stock, producer, alcoholContent, beerType, ibu);
                Console.WriteLine("Birra aggiunta con successo!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
            }

            Console.ReadKey();
        }

        private void AddWine()
        {
            Console.Clear();
            Console.WriteLine("=== AGGIUNGI VINO ===");

            Console.Write("Nome: ");
            var name = Console.ReadLine();

            Console.Write("Prezzo: ");
            decimal.TryParse(Console.ReadLine(), out decimal price);

            Console.Write("Quantità in stock: ");
            int.TryParse(Console.ReadLine(), out int stock);

            Console.Write("Produttore: ");
            var producer = Console.ReadLine();

            Console.Write("Grado alcolico: ");
            double.TryParse(Console.ReadLine(), out double alcoholContent);

            Console.Write("Tipo (Rosso, Bianco, etc.): ");
            var wineType = Console.ReadLine();

            Console.Write("Annata: ");
            int.TryParse(Console.ReadLine(), out int vintage);

            Console.Write("Regione: ");
            var region = Console.ReadLine();

            try
            {
                _logic.AddWine(name, price, stock, producer, alcoholContent, wineType, vintage, region);
                Console.WriteLine("Vino aggiunto con successo!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
            }

            Console.ReadKey();
        }

        private void ShowAllBeverages()
        {
            Console.Clear();
            Console.WriteLine("=== ELENCO BEVANDE ===");

            try
            {
                var beverages = _logic.GetAllBeverages();

                if (!beverages.Any())
                {
                    Console.WriteLine("Nessuna bevanda presente.");
                }
                else
                {
                    foreach (var beverage in beverages)
                    {
                        Console.WriteLine(beverage.ToString());
                        Console.WriteLine("-----------------------");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore nel caricamento: {ex.Message}");
            }

            Console.WriteLine("\nPremere un tasto per continuare...");
            Console.ReadKey();
        }
    }
}
