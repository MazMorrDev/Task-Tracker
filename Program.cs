// See https://aka.ms/new-console-template for more information

using TaskTracker;


ConsoleColor fontColor = ConsoleColor.DarkCyan;
CommandUtils.WriteWithColor("Welcome to TaskTracker " + CommandUtils.GoodEmoji, fontColor);
CommandUtils.WriteWithColor("Type help to get information about commands " + CommandUtils.HelpEmoji, fontColor);
while (true)
{
    string input = (Console.ReadLine() ?? "").Trim().ToLower();

    if (input == "exit")
    {
        CommandUtils.WriteWithColor("Thx for using TaskTracker " + CommandUtils.DoneEmoji, ConsoleColor.DarkGreen);
        Console.ResetColor();
        return;
    }

    CommandExecuter.ExecuteCommand(input);

}


