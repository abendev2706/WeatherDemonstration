using System;
using System.Collections.Generic;

namespace WeatherShared
{
    public class Notice
    {
        public string? copyright { get; set; }
        public string? copyright_url { get; set; }
        public string? disclaimer_url { get; set; }
        public string? feedback_url { get; set; }
    }

    public class Header
    {
        public string? refresh_message { get; set; }
        public string? ID { get; set; }
        public string? main_ID { get; set; }
        public string? name { get; set; }
        public string? state_time_zone { get; set; }
        public string? time_zone { get; set; }
        public string? product_name { get; set; }
        public string? state { get; set; }
    }

    public class Data
    {
        public int sort_order { get; set; }
        public int wmo { get; set; }
        public object? name { get; set; }
        public object? history_product { get; set; }
        public object? local_date_time { get; set; }
        public object? local_date_time_full { get; set; }
        public object? aifstime_utc { get; set; }
        public object? lat { get; set; }
        public object? lon { get; set; }
        public object? apparent_t { get; set; }
        public object? cloud { get; set; }
        public object? cloud_base_m { get; set; }
        public object? cloud_oktas { get; set; }
        public object? cloud_type { get; set; }
        public object? cloud_type_id { get; set; }
        public object? delta_t { get; set; }
        public object? gust_kmh { get; set; }
        public object? gust_kt { get; set; }
        public object? air_temp { get; set; }
        public object? dewpt { get; set; }
        public object? press { get; set; }
        public object? press_msl { get; set; }
        public object? press_qnh { get; set; }
        public object? press_tend { get; set; }
        public object? rain_trace { get; set; }
        public object? rel_hum { get; set; }
        public object? sea_state { get; set; }
        public object? swell_dir_worded { get; set; }
        public object? swell_height { get; set; }
        public object? swell_period { get; set; }
        public object? vis_km { get; set; }
        public object? weather { get; set; }
        public object? wind_dir { get; set; }
        public object? wind_spd_kmh { get; set; }
        public object? wind_spd_kt { get; set; }
    }

    public class Observations
    {
        public List<Notice>? notice { get; set; }
        public List<Header>? header { get; set; }
        public List<Data>? data { get; set; }
    }

    public class RawData
    {
        public Observations? observations { get; set; }
    }
}
