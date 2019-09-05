using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Planet.Converter.Currency.Service;
using Planet.Converter.Currency.Service.Externals.API;

namespace Planet.Converter.Currency.Test
{
    [TestClass]
    public class ServiceTest
    {
        [TestMethod]
        public void GetAllConversionFromEuro()
        {
            // DEPENDENCY INJECTION (Constructor Injection)
            CurrencyService service = new CurrencyService(new DataFixerIOAPIService());

            var ratesEUR = service.GetAllConversionFromCurrency("EUR");

            Assert.IsNotNull(ratesEUR);
        }

        [TestMethod]
        public void GetBRLValueBaseOnEuro()
        {
            // DEPENDENCY INJECTION (Constructor Injection)
            CurrencyService service = new CurrencyService(new DataFixerIOAPIService());

            var ratesEURToBRL = service.ConvertCurrency("EUR", "BRL");

            Assert.IsTrue(ratesEURToBRL > 0);
        }

        [TestMethod]
        public void CurrencyConversionEUR_to_USD()
        {
            // DEPENDENCY INJECTION (Constructor Injection)
            CurrencyService service = new CurrencyService(new DataFixerIOAPIService());

            var ratesEURToUSD = service.ConvertCurrency("EUR", "USD");

            Assert.IsTrue(ratesEURToUSD > 0);
        }

        [TestMethod]
        public void CurrencyConversionGBP_to_USD()
        {
            // DEPENDENCY INJECTION (Constructor Injection)
            CurrencyService service = new CurrencyService(new DataFixerIOAPIService());

            // I culd't use the attribute in URL "&base=GBP", so I calculate based on EUR

            // Get all rates base on EURO
            var ratesEUR = service.GetAllConversionFromCurrency("EUR");

            // Get rate from GBP base on EURO
            var rateEURToGBP = ratesEUR.Rates.Find(x => x.CurrencyConversion.Equals("GBP"));
            Assert.IsNotNull(rateEURToGBP);
            Assert.IsTrue(rateEURToGBP.Value > 0);

            // Get rate from USD base on EURO
            var rateEURToUSD = ratesEUR.Rates.Find(x => x.CurrencyConversion.Equals("USD"));
            Assert.IsNotNull(rateEURToUSD);
            Assert.IsTrue(rateEURToUSD.Value > 0);

            /*
                Calculation:

                1 EUR = 0,90 GBP
                1 EUR = 1,11 USD

                1 EUR = 0,90 GBP = 1,11 USD

                0,90 GBP = 1,11 USD
                1 GBP    = X USD 

                1 GBP = 1,23 USD
            */

            var rateGBPToUSD = Math.Round(rateEURToUSD.Value / rateEURToGBP.Value, 5);

            Assert.IsTrue(rateGBPToUSD > 0);
        }
    }
}
