using Entity.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Service.Services.Abstraction;
using System;
using System.Globalization;
using System.Net.Http; // HttpClient eklenmiş
using System.Threading.Tasks;

namespace Service.Services.Concretes
{
    internal class ApiService : IApiService
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly IPriceService priceService;

        public ApiService(IPriceService priceService)
        {
            this.priceService = priceService;
        }

        public async Task GetData()
        {
            string apiUrl = "https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol=IBM&interval=5min&apikey=demo";

            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    dynamic data = JsonConvert.DeserializeObject(content);
                    JObject timeSeries = data["Time Series (5min)"];

                    foreach (var item in timeSeries)
                    {
                        JObject values = (JObject)item.Value;
                        Price price = new Price
                        {
                            open = float.Parse(values["1. open"].ToString()),
                            high = float.Parse(values["2. high"].ToString()),
                            low = float.Parse(values["3. low"].ToString()),
                            close = float.Parse(values["4. close"].ToString()),
                            volume = float.Parse(values["5. volume"].ToString()),
                            DateTime = DateTime.ParseExact(item.Key, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                        };
                        await priceService.AddPrice(price);
                    }
                }
                else
                {
                    Console.WriteLine("Hata: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
            }
        }
    }
}
