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

    public static void PrintTable(List<Task> tasks)
    {
        var maxDescLength = tasks.Max(t => t.Description.Length);
        maxDescLength = Math.Max(maxDescLength, "Descripción".Length);

        // Encabezado
        var header = string.Format(
            "{0,-5} {1,-" + maxDescLength + "} {2,-12} {3,-20}",
            "ID", "Descripción", "Estado", "Creado"
        );
        WriteWithColor("\n" + header + "\n", ConsoleColor.Blue);


        foreach (var task in tasks)
        {
            var id = task.Id;
            var description = task.Description;
            var status = task.Status;
            var createdAt = task.CreatedDate;
            string statusString = "";

            if (status == TaskStatus.ToDo)
            {
                statusString = "To Do";
            }
            else if (status == TaskStatus.InProgress)
            {
                statusString = "In Progress";
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if (status == TaskStatus.Completed)
            {
                statusString = "Completed";
                Console.ForegroundColor = ConsoleColor.Green;
            }

            Console.WriteLine("{0,-5} {1,-" + maxDescLength + "} {2,-12} {3,-20}", id, description, statusString, createdAt.ToString("g"));
            Console.ResetColor();
            WriteWithColor(new string('-', header.Length) + "\n", ConsoleColor.Blue);

        }

    }

}
