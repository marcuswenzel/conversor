using System;
using Planet.Converter.Currency.Service.Wrappers;

namespace Planet.Converter.Currency.Service.Helpers
{
    internal static class DataFixerIOAPIToCurrency
    {
        public static Domain.Entities.Currency ToCurrency(this DataFixerIOAPIWrapper dataFixerIOAPIWrapper)
        {
            var currency = new Domain.Entities.Currency();
            currency.CurrencyBase = dataFixerIOAPIWrapper.Base;

            if (DateTime.TryParse(dataFixerIOAPIWrapper.Date, out DateTime date))
                currency.Data = date;

            foreach (var rate in dataFixerIOAPIWrapper.Rates)
            {
                currency.Rates.Add(new Domain.ValueObjects.Rate()
                {
                    CurrencyConversion = rate.Key,
                    Value = rate.Value
                });
            }

            return currency;
        }
    }
}