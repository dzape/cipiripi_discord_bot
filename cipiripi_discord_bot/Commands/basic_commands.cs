using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Threading.Tasks;

namespace cipiripi_discord_bot.Commands
{
    public class basic_commands
    {
        [Command("hi")]
        [Description("Takes your username, mentions u in the chat and 👋 to u .")]
        public async Task Hi(CommandContext ctx)
        {
            await ctx.RespondAsync($"👋 Hi, {ctx.User.Mention}!");
        }

        [Command("randomnum")]
        [Description("Random number is given to u 🎲.U set min and max num. ex. !randomnum 1 6")]
        public async Task Random(CommandContext ctx, int min, int max)
        {
            var rnd = new Random();
            await ctx.RespondAsync($"🎲 Your random number is: {rnd.Next(min, max)}");
        }
    }
}
