using System;
using Planet.Converter.Currency.Service;
using Planet.Converter.Currency.Service.Externals.API;

namespace Planet.Converter.UI.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nCurrency Conversion...\n");

            CurrencyService service = new CurrencyService(new DataFixerIOAPIService());

            Console.WriteLine($"\nEUR to USD: {service.ConvertCurrency("EUR", "USD")}\n");

            Console.WriteLine($"\nEUR to GBP: {service.ConvertCurrencyBaseOnEURO("GBP")}\n");

            Console.WriteLine($"\nEUR to USD: {service.ConvertCurrency("GBP", "USD")}\n");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
