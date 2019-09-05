using System.Collections.Generic;
using Newtonsoft.Json;

namespace Planet.Converter.Currency.Service.Wrappers
{
    public class DataFixerIOAPIWrapper
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("rates")]
        public IDictionary<string, float> Rates { get; set; }
    }
}
