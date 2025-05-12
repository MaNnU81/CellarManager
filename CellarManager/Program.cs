namespace CellarManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var storage = new CsvStorage();
            var logic = new BusinessLogic(storage);
            var ui = new Tui(logic);
            ui.Start();
        }
    }
}
