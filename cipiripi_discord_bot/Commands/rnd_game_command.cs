using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using cipiripi_discord_bot.Data;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using Newtonsoft.Json;

namespace cipiripi_discord_bot.Commands
{
    public class random_game
    {
        [Command("wtp")]
        [Description("Selects a game from db set from 700+ games and gives u info about it.")]
        public async Task RandomGame(CommandContext ctx)
        {
            string json = "https://static.nvidiagrid.net/supported-public-game-list/gfnpc.json?JSON";

            HttpClient client = new HttpClient();

            var result = await client.GetAsync(json);

            var str = await result.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<List<GamesData>>(str);

            Random rnd = new Random();
            GamesData item = obj[rnd.Next(0, obj.Count)];

            var msg = ($" \n 🎮 Hey { ctx.User.Username } you should try ```{item.ToString()}```"); 

            var embed = new DiscordEmbedBuilder
            {
                Description = msg,
            };

            await ctx.RespondAsync(embed: embed);
        }
    }
}
