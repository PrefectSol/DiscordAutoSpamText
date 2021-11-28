namespace DiscordAutoSpam.Common
{
    using Discord;

    /// <summary>
    /// themes for embed.
    /// </summary>
    internal class BotEmbedBuilder : EmbedBuilder
    {
        public BotEmbedBuilder()
        {
            this.WithColor(new Color(215, 85, 39));
        }
    }
}
