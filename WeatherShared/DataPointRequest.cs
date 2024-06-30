using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherShared
{
    public class DataPointRequest
    {
        public int wmd {  get; set; }
        public string observation_name { get; set; }
        public string? timestamp { get; set; }
    }
}
