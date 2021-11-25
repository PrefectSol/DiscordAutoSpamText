using System;
using System.IO;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace DiscordAutoSpam
{
    class Program : ModuleBase
    {
        [Command("Спам")]
        public async Task Spam(int countSpamMessage = 0)
        {
            if (countSpamMessage != 0)
            {
                Console.WriteLine("Запуск спама...");

                string fileName = "~/SpamText.txt"; // link to the spam file
                Random myRandom = new Random();
                string[] myString;

                myString = File.ReadAllLines(fileName);

                for (int i = 0; i < countSpamMessage; i++)
                {
                    int index = myRandom.Next(0, myString.Length);
                    var builder = new EmbedBuilder()
                        .WithColor(new Color(215, 85, 39))
                        .WithDescription(myString[index]);
                    var embed = builder.Build();
                    await Context.Channel.SendMessageAsync(null, false, embed);
                }
                var builder2 = new EmbedBuilder()
                    .WithColor(new Color(215, 85, 39))
                    .WithDescription($"Было написано спам-сообщений: {countSpamMessage}");
                Console.WriteLine($"Было написано спам-сообщений: {countSpamMessage}");
                var embed2 = builder2.Build();
                var message = await Context.Channel.SendMessageAsync(null, false, embed2);

                await Task.Delay(2500);
                await message.DeleteAsync();
            }
            else
            {
                var builder = new EmbedBuilder()
                    .WithColor(new Color(215, 85, 39))
                    .WithDescription("Некорректный ввод. Повторите попытку и введите необходимое количество спам-сообщений");
                var embed = builder.Build();
                await Context.Channel.SendMessageAsync(null, false, embed);
            }
        }
    }
}
