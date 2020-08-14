using cipiripi_discord_bot.Commands;
using cipiripi_discord_bot.Data;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace cipiripi_discord_bot
{
    public class Bot
    {
        public DiscordClient _client { get; private set; }
        public CommandsNextModule _commands { get; private set; }
       
        public async Task RunAsync()
        {
            var json = string.Empty;

            using (var fs = File.OpenRead("config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
            json = await sr.ReadToEndAsync().ConfigureAwait(false);

            var configJson = JsonConvert.DeserializeObject<ConfigJson>(json);

            var config = new DiscordConfiguration
            {
                Token = configJson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                LogLevel = LogLevel.Debug,
                UseInternalLogHandler = true
            };

            _client = new DiscordClient(config);

            _client.Ready += ClientReady;

            var commandsConfig = new CommandsNextConfiguration
            {
                StringPrefix = configJson.Prefix,
                EnableDms = false,
                EnableMentionPrefix = false,
                EnableDefaultHelp = true
            };

            _commands = _client.UseCommandsNext(commandsConfig);

            _commands.RegisterCommands<random_game>();
            _commands.RegisterCommands<timer_command>();
            _commands.RegisterCommands<WeatherCommand>();
            _commands.RegisterCommands<basic_commands>();

            await _client.ConnectAsync();
            await Task.Delay(-1);
        }

        private Task ClientReady(ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
