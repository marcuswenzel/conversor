using Microsoft.VisualStudio.TestTools.UnitTesting;
using Planet.Converter.Currency.Service;
using Planet.Converter.Currency.Service.Externals.API;

namespace Planet.Converter.Currency.Test
{
    [TestClass]
    public class ServiceTest
    {
        [TestMethod]
        public void GetRateValueBaseOnEuroToBRL()
        {
            // DEPENDENCY INJECTION (Constructor Injection)
            CurrencyService service = new CurrencyService(new DataFixerIOAPIService());

            var ratesEURToBRL = service.ConvertCurrencyBaseOnEURO("BRL");

            Assert.IsTrue(ratesEURToBRL > 0);
        }

        [TestMethod]
        public void CurrencyConversionEUR_to_USD()
        {
            // Get a rate for EUR to USD

            // DEPENDENCY INJECTION (Constructor Injection)
            CurrencyService service = new CurrencyService(new DataFixerIOAPIService());

            var ratesEURToUSD = service.ConvertCurrency("EUR", "USD");

            Assert.IsTrue(ratesEURToUSD > 0);
        }

        [TestMethod]
        public void GetRateValueBaseOnEuroToGBP()
        {
            // Get a rate for EUR to GBP

            // DEPENDENCY INJECTION (Constructor Injection)
            CurrencyService service = new CurrencyService(new DataFixerIOAPIService());

            var ratesEURToGBP = service.ConvertCurrencyBaseOnEURO("GBP");

            Assert.IsTrue(ratesEURToGBP > 0);
        }

        [TestMethod]
        public void CurrencyConversionGBP_to_USD()
        {
            // Get a rate for GBP to USD

            // DEPENDENCY INJECTION (Constructor Injection)
            CurrencyService service = new CurrencyService(new DataFixerIOAPIService());

            var rateGBPToUSD = service.ConvertCurrency("GBP", "USD");

            Assert.IsTrue(rateGBPToUSD > 0);
        }
    }
}
