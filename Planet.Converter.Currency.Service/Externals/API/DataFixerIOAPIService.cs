using Planet.Converter.Currency.Domain.Abstracts;
using Planet.Converter.Currency.Service.Proxies;
using Planet.Converter.Currency.Service.Wrappers;
using Planet.Converter.Currency.Service.Helpers;

namespace Planet.Converter.Currency.Service.Externals.API
{
    public class DataFixerIOAPIService : ICurrencyService
    {
        private readonly string BaseAddressAPI;
        public DataFixerIOAPIService()
        {
            this.BaseAddressAPI = "http://data.fixer.io/api/latest?access_key=6b06980b7d316e8ae74e0272660b4f77&format=1";
        }

        public Domain.Entities.Currency GetAllConversionFromCurrency(string baseCurrency)
        {
            var currencyWrapper = DataFixerIOAPIProxi.GetCurrency<DataFixerIOAPIWrapper>(this.BaseAddressAPI);

            return currencyWrapper.ToCurrency();
        }

        public float ConvertCurrency(string baseCurrency, string currencyConversion)
        {
            var currencyWrapper = DataFixerIOAPIProxi.GetCurrency<DataFixerIOAPIWrapper>(this.BaseAddressAPI);

            float currency;
            if (currencyWrapper.Rates.TryGetValue(currencyConversion, out currency))
                return currency;

            return currency;
        }
    }
}
