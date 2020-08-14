using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace cipiripi_discord_bot.Commands
{
    public class timer_command
    {
        [Command("timer")]
        public async Task TimeToStretch(CommandContext ctx)
        {
            while(true)
            {
                Task.Delay(10000).Wait();

                await ctx.RespondAsync($"Heey @everyone lets have a streatch . Stay streatcht-up p.s {ctx.Client.CurrentUser}");
            }
        }
    }
}
