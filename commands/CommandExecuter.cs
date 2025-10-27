namespace TaskTracker;

public class CommandExecuter
{
    private readonly TaskService _taskService = new();

    public void Process(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            WriteError("Input cannot be empty.");
            return;
        }

        var args = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var command = args.Length > 0 ? args[0].ToLowerInvariant() : string.Empty;

        ExecuteCommand(command, args);
    }

    public void ExecuteCommand(string command, string[] args)
    {
        switch (command)
        {
            case "help":
                TaskService.ShowHelp();
                break;
            case "create":
                ExecuteCreate(args);
                break;
            case "edit":
                ExecuteEdit(args);
                break;
            case "delete":
                ExecuteDelete(args);
                break;
            case "update":
                ExecuteUpdate(args);
                break;
            case "list":
                ExecuteList(args);
                break;
            case "exit":
                ExecuteExit();
                break;
            default:
                WriteError($"Unknown command '{command}'. Type 'help' for available commands.");
                break;
        }
    }

    private void ExecuteCreate(string[] args)
    {
        if (args.Length < 2)
        {
            WriteError("Description is required. Usage: create 'description'");
            return;
        }

        var description = ExtractDescription(args, 1);
        _taskService.CreateTask(description);
    }

    private void ExecuteEdit(string[] args)
    {
        if (args.Length < 3 || !int.TryParse(args[1], out int taskId))
        {
            WriteError("Invalid syntax. Usage: edit <id> 'description'");
            return;
        }

        var newDescription = ExtractDescription(args, 2);
        _taskService.EditTask(taskId, newDescription);
    }

    private void ExecuteDelete(string[] args)
    {
        if (args.Length != 2 || !int.TryParse(args[1], out int taskId))
        {
            WriteError("Invalid syntax. Usage: delete <id>");
            return;
        }

        _taskService.DeleteTask(taskId);
    }

    private void ExecuteUpdate(string[] args)
    {
        if (args.Length != 3 || !int.TryParse(args[2], out int taskId))
        {
            WriteError("Invalid syntax. Usage: update -p <id> OR update -c <id>");
            return;
        }

        var option = args[1];
        switch (option)
        {
            case "-p":
                _taskService.UpdateTaskToInProgress(taskId);
                break;
            case "-c":
                _taskService.UpdateTaskToCompleted(taskId);
                break;
            default:
                WriteError("Invalid option. Use: update -p <id> OR update -c <id>");
                break;
        }
    }

    private void ExecuteList(string[] args)
    {
        switch (args.Length)
        {
            case 1:
                _taskService.ListAllTasks();
                break;
            case 2:
                HandleListWithFilter(args[1]);
                break;
            default:
                WriteError("Invalid syntax. Usage: list OR list -h|-p|-c");
                break;
        }
    }

    private void HandleListWithFilter(string filter)
    {
        switch (filter)
        {
            case "-h":
                _taskService.ListToDoTasks();
                break;
            case "-p":
                _taskService.ListInProgressTasks();
                break;
            case "-c":
                _taskService.ListCompletedTasks();
                break;
            default:
                WriteError("Invalid option. Use: list -h, list -p, or list -c");
                break;
        }
    }

    private void ExecuteExit()
    {
        WriteWithColor("Goodbye! Thanks for using TaskTracker.", ConsoleColor.Green);
        Environment.Exit(0);
    }

    private string ExtractDescription(string[] args, int startIndex)
    {
        var descriptionParts = args.Skip(startIndex);
        var combinedDescription = string.Join(" ", descriptionParts);
        return combinedDescription.Trim('\'', '"').Trim();
    }

    private void WriteError(string message)
    {
        WriteWithColor($"Error: {message}", ConsoleColor.Red);
    }

    private void WriteWithColor(string message, ConsoleColor color)
    {
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ForegroundColor = originalColor;
    }
}