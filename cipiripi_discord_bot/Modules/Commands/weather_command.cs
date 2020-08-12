using cipiripi_discord_bot.Data;
using Discord.Commands;
using MySql.Data.MySqlClient.Memcached;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using cipiripi_discord_bot.Data;
using Discord;

namespace cipiripi_discord_bot.Modules.Commands
{
    public class weather_command : ModuleBase
    {
        
        [Command("Weather")]
        //[Alias("city")]
        public async Task Weather()
        {
            string json = "https://query.yahooapis.com/v1/public/yql?q=select%20item%20from%20weather.forecast%20where%20woeid%20in%20(2295414%20)&format=json";

            HttpClient client = new HttpClient();

            StringBuilder sb = new StringBuilder();

            var result = await client.GetAsync(json);

            var str = await result.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<List<WeatherData>>(str);
            
            //GetWeather(client).Wait();

        }

        //public async Task<String> GetWeather(HttpClient cons)
        //{
        //    using (cons)
        //    {

        //        var embed = new EmbedBuilder();

        //        StringBuilder sb = new StringBuilder();

        //        HttpResponseMessage res = await cons.GetAsync("");

        //        res.EnsureSuccessStatusCode();

        //        if (res.IsSuccessStatusCode)
        //        {
        //            string weather = await res.Content.ReadAsStringAsync();

        //            JObject jobj = JObject.Parse(weather);
        //            JToken jToken = jobj.First;
        //            string WeatherData = jToken.First["results"]["channel"]["item"]["condition"].ToString();
        //            WeatherData report = Newtonsoft.Json.JsonConvert.DeserializeObject<WeatherData>(WeatherData);
        //            Console.WriteLine("\n");

        //            embed.Description = sb.ToString();
        //        }
        //        await ReplyAsync(null, false, embed.Build());
        //    }
        }
    } 



//Console.WriteLine("Weather Station: Hyderabad");
//Console.WriteLine("Temperature Details");
//Console.WriteLine("-----------------------------------------------------------");
//Console.WriteLine("Temperature (in deg. C): " + (report.temp - 32) * 0.55);// Converted from Fahrenheit to Celsius  
//Console.WriteLine("Weather State: " + report.text);
//Console.WriteLine("Applicable Time: " + report.date);
//Console.ReadLine();

//HttpClient client = new HttpClient();
//client.BaseAddress = new Uri("https://query.yahooapis.com/v1/public/yql?q=select%20item%20from%20weather.forecast%20where%20woeid%20in%20(2295414%20)&format=json");

//client.DefaultRequestHeaders.Accept.Clear();  
//    Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));  
