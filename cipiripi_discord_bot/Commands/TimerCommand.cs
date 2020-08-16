using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace cipiripi_discord_bot.Commands
{
    public class TimerCommand
    {
        [Command("timer")]
        public async Task TimeToStretch(CommandContext ctx,int time)
        {
            while(true)
            {
                Task.Delay(time * 60000).Wait();

                await ctx.RespondAsync($"Heey @everyone lets have a streatch . Stay streatcht-up p.s {ctx.Client.CurrentUser}");
            }
        }
    }
}
