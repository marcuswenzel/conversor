using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace Planet.Converter.Currency.Service.Proxies
{
    public class DataFixerIOAPIProxi
    {
        public static T GetCurrency<T>(string url) where T : class
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = client.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        // Calling '.Result', reading is synchronous
                        string responseString = response.Content.ReadAsStringAsync().Result;

                        return JsonConvert.DeserializeObject<T>(responseString);
                    }
                    else
                        throw new Exception("Error reading data from API");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in external API", ex);
            }
        }
    }
}
