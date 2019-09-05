using Planet.Converter.Currency.Domain.Abstracts;
using Planet.Converter.Currency.Service.Proxies;
using Planet.Converter.Currency.Service.Wrappers;
using Planet.Converter.Currency.Service.Helpers;
using System;

namespace Planet.Converter.Currency.Service.Externals.API
{
    public class DataFixerIOAPIService : ICurrencyService
    {
        private readonly string BaseAddressAPI;

        public DataFixerIOAPIService()
        {
            this.BaseAddressAPI = Properties.Settings.Default.BaseAddressAPI;
        }

        public Domain.Entities.Currency GetAllConversionFromCurrency(string baseCurrency)
        {
            var currencyWrapper = DataFixerIOAPIProxi.GetCurrency<DataFixerIOAPIWrapper>(this.BaseAddressAPI);

            return currencyWrapper.ToCurrency();
        }

        public float ConvertCurrencyBaseOnEURO(string currencyConversion)
        {
            var currencyWrapper = DataFixerIOAPIProxi.GetCurrency<DataFixerIOAPIWrapper>(this.BaseAddressAPI);

            if (currencyWrapper.Rates.TryGetValue(currencyConversion, out float currency))
                return currency;

            return currency;
        }

        public float ConvertCurrency(string baseCurrency, string currencyConversion)
        {
            // I coudn't use baseCurrency because API is restrict... is a real world I use it to change the base currency
            // I culd't use the attribute in URL "&base=GBP", so I calculate based on EUR
            var currencyWrapper = DataFixerIOAPIProxi.GetCurrency<DataFixerIOAPIWrapper>(this.BaseAddressAPI);

            float currency = 0;
            if (baseCurrency == "EUR")
            {
                if (currencyWrapper.Rates.TryGetValue(currencyConversion, out currency))
                    return currency;
            }
            else
            {
                if (currencyWrapper.Rates.TryGetValue(baseCurrency, out float currencyFromBaseOnEURO))
                {
                    if (currencyWrapper.Rates.TryGetValue(currencyConversion, out float currencyToBaseOnEURO))
                    {
                        /*
                            Sample of Calculation:

                            1 EUR = 0,90 GBP
                            1 EUR = 1,11 USD

                            1 EUR = 0,90 GBP = 1,11 USD

                            0,90 GBP = 1,11 USD
                            1 GBP    = X USD 

                            1 GBP = 1,23 USD
                        */

                        return (float)Math.Round(currencyToBaseOnEURO / currencyFromBaseOnEURO, 6);
                    }
                }
            }

            return currency;
        }
    }
}