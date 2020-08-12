using Discord;
using Discord.Commands;
using System.Text;
using System.Threading.Tasks;

namespace cipiripi_discord_bot.Modules
{
    public class hello_command : ModuleBase
    {
        [Command("hi")]
        [RequireUserPermission(GuildPermission.KickMembers)]
        public async Task HelloCommand()
        {
            // initialize empty string builder for reply
            var sb = new StringBuilder();

            // get user info from the Context
            var user = Context.User;
            
            // build out the reply
            sb.AppendLine($"Hi {user.Username} nice to meet u ^^");

            // send simple string reply
            await ReplyAsync(sb.ToString());
        }
    }
}
