using DSharpPlus;

namespace beginnerbot
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            DotNetEnv.Env.TraversePath().Load();

            string botToken = Environment.GetEnvironmentVariable("BOT_TOKEN");
            if (string.IsNullOrEmpty(botToken)) //check if token is there
            {
                Console.WriteLine("Bot token does not exist.");
                Environment.Exit(1);
            }

            DiscordClientBuilder builder = DiscordClientBuilder.CreateDefault(botToken, DiscordIntents.All);

            builder.ConfigureEventHandlers
            (
                b => b.HandleMessageCreated(async (s, e) =>
                {
                    if (e.Message.Content.ToLower().StartsWith("ping"))
                    {
                        await e.Message.RespondAsync("pong!");
                    }
                })
            );

            await builder.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}