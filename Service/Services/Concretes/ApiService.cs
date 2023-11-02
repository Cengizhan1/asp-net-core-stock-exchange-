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
                        string dateTime = item.Key;
                        JObject values = (JObject)item.Value;

                        float open = float.Parse(values["1. open"].ToString());
                        float high = float.Parse(values["2. high"].ToString());
                        float low = float.Parse(values["3. low"].ToString());
                        float close = float.Parse(values["4. close"].ToString());
                        float volume = float.Parse(values["5. volume"].ToString());

                        DateTime parsedDateTime = DateTime.ParseExact(dateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

                        Price price = new Price
                        {
                            open = open,
                            high = high,
                            low = low,
                            close = close,
                            volume = volume,
                            DateTime = parsedDateTime
                        };

                        await priceService.AddPrice(price);

                    }

                   // Console.WriteLine(data["Time Series (5min)"]["2023-11-01 19:55:00"]["4. close"]);

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
