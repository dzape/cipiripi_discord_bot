using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace cipiripi_discord_bot.Data
{
    class WeatherData
    {
        [DataMember]
        public string date { get; set; }
       
        [DataMember]
        public long temp { get; set; }
        
        [DataMember]
        public string text { get; set; }

        public override string ToString()
        {
            return $" Temperature (in deg. C): " + (temp - 32) * 0.55 + " Weather State: " + text + "Applicable Time " + date; ;
        }
    }
}
