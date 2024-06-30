using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace WeatherShared
{
    static class RawDataExtensions
    {
        public static Data CreateByObservationName(this Data dataPoint, string observation_name)
        {
            switch (observation_name)
            {
                case "local_date_time": return new Data { local_date_time = dataPoint.local_date_time }; 
                case "local_date_time_full": return new Data { local_date_time_full = dataPoint.local_date_time_full }; 
                case "aifstime_utc": return new Data { aifstime_utc = dataPoint.aifstime_utc };
                case "lat": return new Data { lat = dataPoint.lat };
                case "lon": return new Data { lon = dataPoint.lon };
                case "apparent_t": return new Data { apparent_t = dataPoint.apparent_t };
                case "cloud": return new Data { cloud = dataPoint.cloud };
                case "cloud_base_m": return new Data { cloud_base_m = dataPoint.cloud_base_m }; 
                case "cloud_oktas": return new Data { cloud_oktas = dataPoint.cloud_oktas };
                case "cloud_type": return new Data { cloud_type = dataPoint.cloud_type };
                case "cloud_type_id": return new Data { cloud_type_id = dataPoint.cloud_type_id };
                case "delta_t": return new Data { delta_t = dataPoint.delta_t };
                case "gust_kmh": return new Data { gust_kmh = dataPoint.gust_kmh };
                case "gust_kt": return new Data { gust_kt = dataPoint.gust_kt };
                case "air_temp": return new Data { air_temp = dataPoint.air_temp };
                case "dewpt": return new Data { dewpt = dataPoint.dewpt }; 
                case "press": return new Data { press = dataPoint.press }; 
                case "press_msl": return new Data { press_msl = dataPoint.press_msl }; 
                case "press_qnh": return new Data { press_qnh = dataPoint.press_qnh }; 
                case "press_tend": return new Data { press_tend = dataPoint.press_tend }; 
                case "rain_trace": return new Data { rain_trace = dataPoint.rain_trace }; 
                case "rel_hum": return new Data { rel_hum = dataPoint.rel_hum };
                case "sea_state": return new Data { sea_state = dataPoint.sea_state }; 
                case "swell_dir_worded": return new Data { swell_dir_worded = dataPoint.swell_dir_worded }; 
                case "swell_height": return new Data { swell_height = dataPoint.swell_height }; 
                case "swell_period": return new Data { swell_period = dataPoint.swell_period }; 
                case "vis_km": return new Data { vis_km = dataPoint.vis_km }; 
                case "weather": return new Data { weather = dataPoint.weather }; 
                case "wind_dir": return new Data { wind_dir = dataPoint.wind_dir }; 
                case "wind_spd_kmh": return new Data { wind_spd_kmh = dataPoint.wind_spd_kmh };
                case "wind_spd_kt": return new Data { wind_spd_kt = dataPoint.wind_spd_kt }; 
                default:
                    return new Data();
                    
            }
        }
    }
}
