using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace cipiripi_discord_bot.Commands
{
    public class basic_commands
    {
        [Command("hi")]
        [Description("Takes your username, mentions u in the chat and 👋 to u .")]
        public async Task Hi(CommandContext ctx)
        {
            var msg = ($"👋 Hi, {ctx.User.Mention}!");

            var embed = new DiscordEmbedBuilder
            { 
                Description = msg,
            };
           
            embed.WithColor(new DiscordColor(0x03ecfc));
           
            await ctx.RespondAsync(embed: embed).ConfigureAwait(false);
        }

        [Command("randomnum")]
        [Description("Random number is given to u 🎲.U set min and max num. ex. !randomnum 1 6")]
        public async Task Random(CommandContext ctx, int min, int max)
        {   
            var rnd = new Random();
            var msg = ($"🎲 Your random number is: {rnd.Next(min, max)}");
            
            var embed = new DiscordEmbedBuilder
            {
                Description = msg,
            };

            embed.WithColor(new DiscordColor(0x1567E6)); //0x03ecfc
            await ctx.RespondAsync(embed: embed).ConfigureAwait(false);
        }

        [Command("art"), Description("Art.")]
        public async Task Art(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();

            var embed = new DiscordEmbedBuilder
            {
                Title = "Art",
                ImageUrl = "http://i.imgur.com/VkmmmQd.png"
            };

            embed.WithColor(new DiscordColor(0x1567E6));

            await ctx.RespondAsync(embed: embed);
        }

        [Command("poll"), Description("Run a poll with reactions.")]
        public async Task Poll(CommandContext ctx, [Description("How long should the poll last.")] TimeSpan duration, [Description("What options should people have.")] params DiscordEmoji[] options)
        {
            // first retrieve the interactivity module from the client
            var interactivity = ctx.Client.GetInteractivityModule();
            var poll_options = options.Select(xe => xe.ToString());

            // then let's present the poll
            var embed = new DiscordEmbedBuilder
            {
                Title = "Poll time!",
                Description = string.Join(" ", poll_options)
            };
            var msg = await ctx.RespondAsync(embed: embed);

            // add the options as reactions
            for (var i = 0; i < options.Length; i++)
                await msg.CreateReactionAsync(options[i]);

            // collect and filter responses
            var poll_result = await interactivity.CollectReactionsAsync(msg, duration);
            var results = poll_result.Reactions.Where(xkvp => options.Contains(xkvp.Key))
                .Select(xkvp => $"{xkvp.Key}: {xkvp.Value}");

            // and finally post the results
            await ctx.RespondAsync(string.Join("\n", results));
        }
    }
}
