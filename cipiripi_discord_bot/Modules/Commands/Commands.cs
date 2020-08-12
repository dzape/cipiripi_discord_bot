using cipiripi_discord_bot.Data;
using Discord;
using Discord.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace cipiripi_discord_bot.Modules
{
    // for commands to be available, and have the Context passed to them, we must inherit ModuleBase
    public class ExampleCommands : ModuleBase
    {
        [Command("Who are u ?")]
        public async Task WhoAreUCommand()
        {
            // initialize empty string builder for reply
            var sb = new StringBuilder();

            // get user info from the Context
            var user = Context.User;
            var client = Context.Client;
            var embed = new EmbedBuilder();

            // build out the reply
            embed.WithColor(new Color(0, 255, 0));
            sb.AppendLine($"Hmmm how can i say this to u {user.Username} i am bot who can read and write a lot of ones and zeros ^^. My name is {client.CurrentUser} ");

            // send simple string reply
            await ReplyAsync(sb.ToString());
        }

        [Command("cipiripi")]
        [Alias("ask")]
        [RequireUserPermission(GuildPermission.KickMembers)]
        public async Task AskCipiripi([Remainder] string args = null)
        {
            // I like using StringBuilder to build out the reply
            var sb = new StringBuilder();
            // let's use an embed for this one!
            var embed = new EmbedBuilder();

            // now to create a list of possible replies
            var replies = new List<string>
            {

                // add our possible replies
                "CSGO",
                "GTA5",
                "LEAGUE OF LEGENDS",
                "VALORANT"
            };

            // time to add some options to the embed (like color and title)
            embed.WithColor(new Color(0, 255, 0));
            //embed.Title = "Welcome to the amg !";

            // we can get lots of information from the Context that is passed into the commands
            // here I'm setting up the preface with the user's name and a comma
            sb.AppendLine($"{Context.User.Username},");
            sb.AppendLine();

            // let's make sure the supplied question isn't null 
            if (args == null)
            {
                // if no question is asked (args are null), reply with the below text
                sb.AppendLine("Sorry, can't answer a question you didn't ask!");
            }
            else
            {
                // if we have a question, let's give an answer!
                // get a random number to index our list with (arrays start at zero so we subtract 1 from the count)
                var answer = replies[new Random().Next(replies.Count - 1)];

                // build out our reply with the handy StringBuilder
                sb.AppendLine($"You asked: [**{args}**]...");
                sb.AppendLine();
                sb.AppendLine($"...your answer is [**{answer}**]");

                // bonus - let's switch out the reply and change the color based on it
                switch (answer)
                {
                    case "CSGO":
                        {
                            embed.WithColor(new Color(0, 255, 0));
                            break;
                        }
                    case "GTA5":
                        {
                            embed.WithColor(new Color(255, 0, 0));
                            break;
                        }
                    case "LEAGUE OF LEGENDS":
                        {
                            embed.WithColor(new Color(255, 255, 0));
                            break;
                        }
                    case "VALORANT":
                        {
                            embed.WithColor(new Color(255, 0, 255));
                            break;
                        }
                }
            }

            // now we can assign the description of the embed to the contents of the StringBuilder we created
            embed.Description = sb.ToString();

            // this will reply with the embed
            await ReplyAsync(null, false, embed.Build());
        }

        [Command("info")]
        [Alias("title")]
        [RequireUserPermission(GuildPermission.KickMembers)]
        public async Task GameInfo()
        {
            //Select random game from json and output title and genres.
            string json = "https://static.nvidiagrid.net/supported-public-game-list/gfnpc.json?JSON";

            HttpClient client = new HttpClient();

            var result = await client.GetAsync(json);

            var str = await result.Content.ReadAsStringAsync();

            List<GamesData> obj = JsonConvert.DeserializeObject<List<GamesData>>(str);

            //var title = new GamesData();

            //string jsonString;
            //jsonString = JsonSerializer.Serialize();

        }



    }
}