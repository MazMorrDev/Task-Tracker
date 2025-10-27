namespace TaskTracker;

public class CommandExecuter
{
    readonly TaskService _taskService = new();
    public void ExecuteCommand(string input)
    {
        switch (input)
        {
            case "help":
                TaskService.ShowHelp();
                break;
            case "create":
                _taskService.CreateTask(input);
                break;
            case "edit":
                break;
            case "delete":
                break;
            case "update":
                break;
            case "list":
                break;
            default:
                Console.WriteLine("Please write an existing command, type 'help' for information");
                break;
        }
    }

}
