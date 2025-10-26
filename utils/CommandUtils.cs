namespace TaskTracker;

public class CommandUtils
{
    public const string GoodEmoji = "(๑╹ᵕ╹๑)⸝*";
    public const string HelpEmoji = "ദ്ദി(˵ •̀ᴗ- ˵) ✧";
    public const string ErrorEmoji = "( ꩜ ᯅ ꩜;)";
    public const string InprogressEmoji = "ദ്ദി(ᗜˬᗜ)";
    public const string DoneEmoji = "✧｡٩(ˊᗜˋ )و✧*｡";
    public const string EmptyEmoji = "( ╹ -╹)?";

    public static void WriteWithColor(String input, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(input);
        Console.ResetColor();
    }

}
