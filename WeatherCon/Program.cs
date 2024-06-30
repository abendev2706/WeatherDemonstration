using System.Globalization;
using System.Net.Http.Headers;
using System.Text.Json;
using WeatherShared;

namespace WeatherCon
{
    internal class Program
    {
        static string GetAverage(int wmd)
        {
            //api call for data
            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (HttpResponseMessage response = client.GetAsync($"https://localhost:7213/api/GetWeather/{wmd}").Result)     //update URL for deployed production server here
                {
                    //token error handling
                    if (!response.IsSuccessStatusCode)
                        return "0.0";
                    var s = response.Content.ReadAsStringAsync().Result;
                    var allData = JsonSerializer.Deserialize<RawData>(s);
                    double result = 0;
                    int divsor = 0;
                    DateTime seventyTwoHours = DateTime.Now - new TimeSpan(72,0,0);
                    //token error handling
                    if (allData != null && allData.observations != null && allData.observations.data != null)
                    {
                        foreach (var item in allData.observations.data)
                        {
                            if (DateTime.ParseExact(item.local_date_time_full.ToString(), "yyyyMMddHHmmss", CultureInfo.InvariantCulture) > seventyTwoHours)
                            {
                                result += double.Parse(item.air_temp.ToString());
                                divsor++;
                            }
                        }
                    }
                    return string.Format("{0:0.0}", result/divsor);
                }
            }
            //average calculation
        }
        
        static void Main(string[] args)
        {
            int wmd = 94672;
            if (args.Length == 1)
            {
                Int32.TryParse(args[0], out wmd);
            }

            Console.WriteLine($"{GetAverage(wmd)}");
            Console.ReadLine();
        }
    }
}
