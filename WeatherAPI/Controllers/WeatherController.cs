using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using WeatherShared;

namespace WeatherAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    public class WeatherController : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger;

        public WeatherController(ILogger<WeatherController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// default path, call GetWeather for adeliade airport
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetWeather")]
        public async Task<RawData> GetWeather()
        {
            return await GetWeather(94672);
        }

        /// <summary>
        /// Retreives all observation data for the given WMO, if the WMO is invalid, return the data for adeliade airport
        /// </summary>
        /// <param name="wmd"></param>
        /// <returns></returns>
        [HttpGet("GetWeather/{wmd:int?}")]
        public async Task<RawData> GetWeather(int? wmd)
        {
            //replace this with a call to the database and use an extension to translate the database model to the observations model for deploying in a production environment
            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync($"http://www.bom.gov.au/fwo/IDS60801/IDS60801.{wmd}.json");
                if (!response.IsSuccessStatusCode)
                    response = await client.GetAsync($"http://www.bom.gov.au/fwo/IDS60801/IDS60801.94672.json");

                var s = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<RawData>(s);
                return result;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("GetDataPoint")]
        public async Task<RawData> GetDataPoint([FromBody] DataPointRequest model)
        {
            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync($"http://www.bom.gov.au/fwo/IDS60801/IDS60801.{model.wmd}.json");
                if (!response.IsSuccessStatusCode)
                    response = await client.GetAsync($"http://www.bom.gov.au/fwo/IDS60801/IDS60801.94672.json");
                
                var s = await response.Content.ReadAsStringAsync();
                var allData = JsonSerializer.Deserialize<RawData>(s);
                RawData result = new();
                result.observations = new Observations();
                //token error handling
                if (allData != null && allData.observations != null && allData.observations.data != null)
                {   
                    result.observations.notice = allData.observations.notice;
                    result.observations.header = allData.observations.header;
                    result.observations.data = new List<Data>();
                    
                    if (!String.IsNullOrEmpty(model.timestamp))
                    {
                        //find the observation that occured at or just before the given time
                        DateTime d = DateTime.ParseExact(model.timestamp, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
                        var oldestData = allData.observations.data.OrderByDescending(q => q.local_date_time_full.ToString()).ToList();
                        int index = 0;
                        while (DateTime.ParseExact(oldestData[index].local_date_time_full.ToString(), "yyyyMMddHHmmss", CultureInfo.InvariantCulture) > d)
                            index++;
                        result.observations.data.Add(oldestData[index].CreateByObservationName(model.observation_name));
                    }
                    else
                    {
                        foreach (var dataPoint in allData.observations.data)
                        {
                            result.observations.data.Add(dataPoint.CreateByObservationName(model.observation_name));
                        }
                    }
                }
                return result;
            }
        }
    }
}
