using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace cipiripi_discord_bot.Modules.Commands
{
    public class timer_command : ModuleBase
    {
        [Command("timer")]
        public async Task TimeToStretch()
        {
            var sb = new StringBuilder();
            Timer t = new Timer();

            t = new Timer (18000);
            t.Elapsed += PollUpdates; //PollUpdates; //async ( sender, e ) => await HandleTimer();
            t.Start();

            await ReplyAsync();
        }

        public async void PollUpdates(object sender, ElapsedEventArgs e)
        {
            var sb = new StringBuilder();

            // initialize empty string builder for reply
            var embed = new EmbedBuilder();
            var client = Context.Client;

            embed.WithColor(new Color(0, 255, 0));
            sb.AppendLine($"Heey @everyone lets have a streatch . Stay streatcht-up p.s {client.CurrentUser}");

            await ReplyAsync(sb.ToString());
        }
    }
}
