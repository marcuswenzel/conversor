
namespace Planet.Converter.Currency.Domain.Abstracts
{
    public interface ICurrencyService
    {
        Entities.Currency GetAllConversionFromCurrency(string baseCurrency);

        float ConvertCurrencyBaseOnEURO(string currencyConversion);

        float ConvertCurrency(string baseCurrency, string currencyConversion);
    }
}
