using Data;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace cipiripi_discord_bot.Commands
{
    public class WeatherCommand
    {
        // GET api/values
        [Command("weather")]
        public async Task GetWeather(CommandContext ctx, string name)
        {
            string owm_key = "";
            string json = $"https://api.openweathermap.org/data/2.5/weather?q={name}&appid={owm_key}";

            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(json);

                var str = await result.Content.ReadAsStringAsync();

                var obj = JsonConvert.DeserializeObject<WeatherData>(str);

                var msg = ($" \n :white_sun_rain_cloud:  Hey { ctx.User.Username } here is some info about the weather in {obj.Name} \n Temp : {obj.Main.Temp * 1 - 273.15} °C ." +
                 $"\n Wind Speed : {obj.Wind.Speed} m/s ." + 
                 $"\n Cloudiness : {obj.Clouds.All} % .");

                var embed = new DiscordEmbedBuilder
                {
                    Description = msg,
                };
                await ctx.RespondAsync(embed: embed).ConfigureAwait(false);
            }
        }
    }
}
