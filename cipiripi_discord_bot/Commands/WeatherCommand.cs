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
            string owm_key = "a50e2aff21f6864e4b65258a3b3ea856";
            string json = $"https://api.openweathermap.org/data/2.5/weather?q={name}&appid={owm_key}";

            using (var client = new HttpClient()) // limit the number of instances you create in the lifetime of your application because socket exhaustion is a thing
            {
                var result = await client.GetAsync(json);

                var str = await result.Content.ReadAsStringAsync();

                var obj = JsonConvert.DeserializeObject<WeatherData>(str);

                var msg = ($" \n :white_sun_rain_cloud:  Hey { ctx.User.Username } here is some info about the weather in {obj.Name} ! " + obj.ToString());

                var embed = new DiscordEmbedBuilder
                {
                    Description = msg,
                };
                await ctx.RespondAsync(embed: embed).ConfigureAwait(false);
            }
        }
    }
}
