using System;
using System.Collections.Generic;
using Planet.Converter.Currency.Domain.ValueObjects;

namespace Planet.Converter.Currency.Domain.Entities
{
    public class Currency
    {
        public Currency()
        {
            this.Rates = new List<Rate>();
        }

        public DateTime Data { get; set; }

        public string CurrencyBase { get; set; }

        public List<Rate> Rates { get; set; }
    }
}
