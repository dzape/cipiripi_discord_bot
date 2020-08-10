using cipiripi_discord_bot.Data;
using Discord;
using Discord.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace cipiripi_discord_bot.Modules.Commands
{
    public class wtp_command : ModuleBase
    {
        [Command("wtp")] // what to play
        //[RequireUserPermission(GuildPermission.KickMembers)]
        public async Task AskForGmameCipiripi()
        {
            //Select random game from json and output title and genres.
            string json = "https://static.nvidiagrid.net/supported-public-game-list/gfnpc.json?JSON";

            HttpClient client = new HttpClient();

            var result = await client.GetAsync(json);

            var str = await result.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<List<GamesData>>(str);

            Random rnd = new Random();
            GamesData item = obj[rnd.Next(0, obj.Count)];

            // I like using StringBuilder to build out the reply
            var sb = new StringBuilder();
            // let's use an embed for this one!
            var embed = new EmbedBuilder();

            // we can get lots of information from the Context that is passed into the commands
            // here I'm setting up the preface with the user's name and a comma
            sb.AppendLine($" {Context.User.Username},");
            sb.AppendLine();

            // build out our reply with the handy StringBuilder
            embed.WithColor(new Color(0, 255, 0));
            sb.AppendLine($"Hey { Context.User.Username } you should play ```{item.ToString()}```");

            // now we can assign the description of the embed to the contents of the StringBuilder we created
            embed.Description = sb.ToString();

            // this will reply with the embed
            await ReplyAsync(null, false, embed.Build());
        }
    }
}
