namespace DiscordAutoSpam
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Threading.Tasks;
    using Discord.Commands;
    using DiscordAutoSpam.Common;

    public class Program : ModuleBase<SocketCommandContext>
    {
        [Command("Спам")]
        [Alias("sp")]
        public async Task Spam(int countSpamMessage = 0)
        {
            Stopwatch sw = new ();
            Random randomString = new ();

            if (countSpamMessage != 0)
            {
                sw.Start();

                string path = "/DiscordAutoSpam/SpamText.txt"; // link to the spam file
                string[] spamString;

                spamString = File.ReadAllLines(path);

                for (int i = 0; i < countSpamMessage; i++)
                {
                    int index = randomString.Next(0, spamString.Length);
                    var embed = new BotEmbedBuilder()
                        .WithDescription(spamString[index])
                        .Build();
                    await this.ReplyAsync(embed: embed);
                }

                var reportEmbed = new BotEmbedBuilder()
                    .WithDescription($"Было написано спам-сообщений: {countSpamMessage}")
                    .Build();
                var message = await this.ReplyAsync(embed: reportEmbed);

                await Task.Delay(2500);
                await message.DeleteAsync();

                sw.Stop();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Rprt: ");
                Console.ResetColor();
                Console.WriteLine($"{countSpamMessage} spam messages were written in {sw.ElapsedMilliseconds} ms");
            }
            else
            {
                var embed = new BotEmbedBuilder()
                    .WithDescription("Некорректный ввод. Повторите попытку и введите необходимое количество спам-сообщений.")
                    .Build();
                await this.ReplyAsync(embed: embed);
            }
        }
    }
}
