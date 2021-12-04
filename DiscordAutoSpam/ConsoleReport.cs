namespace DiscordAutoSpam
{
    using System;

    /// <summary>
    /// Report to the console.
    /// </summary>
    internal class ConsoleReport
    {
        public static void Report(string text)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Rprt: ");
            Console.ResetColor();
            Console.WriteLine(text);
        }
    }
}
