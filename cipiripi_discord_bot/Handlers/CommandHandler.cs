using System;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;

namespace DSharpPlus_Example_Bot.Handlers
{
    public static class CommandContextExtensions
    {
        public static async Task<DiscordMessage> RespondWithDmAsync(this CommandContext commandContext, string content = null, bool isTTS = false, DiscordEmbed embed = null)
        {
            if (commandContext == null)
                throw new InvalidOperationException("CommandContext can't be null");
            return await (commandContext.Member != null ? commandContext.Member.SendMessageAsync(content, isTTS, embed) : commandContext.RespondAsync(content, isTTS, embed));
        }
    }
}