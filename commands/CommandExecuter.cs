namespace TaskTracker;

public class CommandExecuter
{
    public static void ExecuteCommand(string input)
    {
        switch (input)
        {
            case "help":
                Console.Write($"'help' : List all the commands.\n" +
                              "'create <description>' : Create a new task. Ex: create 'Buy rice'\n" +
                              "'edit <id> <description>' : Edit an existent task. Ex: edit 1 'Buy 20kg of rice'\n" +
                              "'delete <id>' : Delete a task. Ex: delete 1\n" +
                              "'update -p <id>' : Marca una tarea como 'In Progress'. Ex: update -p 1\n" +
                              "'update -c <id>' : Mark a task as completed. Ex: update -c -1\n" +
                              "'list' : List all tasks.\n" +
                              "'list -h' : List all To Do tasks.\n" +
                              "'list -p' : List all in progress tasks.\n" +
                              "'list -c' : List all completed tasks.\n" +
                              "'exit' : Close TaskTracker.\n");
                break;
            case "create":
                
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
