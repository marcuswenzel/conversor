
namespace Planet.Converter.Currency.Domain.Abstracts
{
    public interface ICurrencyService
    {
        Entities.Currency GetAllConversionFromCurrency(string baseCurrency);

        float ConvertCurrency(string baseCurrency, string currencyConversion);
    }
}
