using Planet.Converter.Currency.Domain.Abstracts;

namespace Planet.Converter.Currency.Service
{
    public class CurrencyService
    {
        private readonly ICurrencyService Service;

        public CurrencyService(ICurrencyService service)
        {
            this.Service = service;
        }

        public Domain.Entities.Currency GetAllConversionFromCurrency(string baseCurrency)
        {
            return this.Service.GetAllConversionFromCurrency(baseCurrency);
        }

        public float ConvertCurrency(string baseCurrency, string currencyConversion)
        {
            return this.Service.ConvertCurrency(baseCurrency, currencyConversion);
        }
    }
}
