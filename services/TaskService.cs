namespace TaskTracker;

public class TaskService
{

    private readonly List<Task> _tasks;
    private readonly DataJsonService _dataJsonService;
    private readonly CommandUtils _commandUtils;

    public TaskService()
    {
        _commandUtils = new CommandUtils();
        _dataJsonService = new DataJsonService();
        _tasks = _dataJsonService.Load();
    }

    public void CreateTask(string description)
    {
        int nextId = _tasks.Count != 0 ? _tasks.Max(t => t.Id) + 1 : 1;

        Task newTask = new(nextId, description);
        _tasks.Add(newTask);
        SaveChanges();
        CommandUtils.WriteWithColor($"La tarea '{description}' se ha creado. Id: {newTask.Id}. {CommandUtils.GoodEmoji} \n", ConsoleColor.Green);
    }

    public void EditTask(int id, string newDescription)
    {
        Task? task = _tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
        {
            CommandUtils.WriteWithColor($"Task with id {id} not found. {CommandUtils.EmptyEmoji}\n", ConsoleColor.Red);
            return;
        }

        string oldDescription = task.Description;
        task.Description = newDescription;
        SaveChanges();
        CommandUtils.WriteWithColor($"Task {id} updated from '{oldDescription}' to '{newDescription}'. {CommandUtils.GoodEmoji}\n", ConsoleColor.Green);
    }

    public void DeleteTask(int id)
    {
        Task? task = _tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
        {
            CommandUtils.WriteWithColor($"Task with id {id} not found. {CommandUtils.EmptyEmoji}\n", ConsoleColor.Red);
            return;
        }

        string description = task.Description;
        _tasks.Remove(task);
        SaveChanges();
        CommandUtils.WriteWithColor($"Task '{description}' deleted successfully. {CommandUtils.GoodEmoji}\n", ConsoleColor.Green);
    }

    public void UpdateTaskToInProgress(int id)
    {
        Task? task = _tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
        {
            CommandUtils.WriteWithColor($"Task with id {id} not found. {CommandUtils.EmptyEmoji}\n", ConsoleColor.Red);
            return;
        }

        string description = task.Description;
        task.Status = TaskStatus.InProgress;
        SaveChanges();
        CommandUtils.WriteWithColor($"Task status with id: '{id}' and description '{description}' was succesfully updated to In Progress {CommandUtils.InprogressEmoji}", ConsoleColor.DarkGreen);
    }

    public void UpdateTaskToCompleted(int id)
    {
        Task? task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            CommandUtils.WriteWithColor($"Task with id {id} not found. {CommandUtils.EmptyEmoji}\n", ConsoleColor.Red);
            return;
        }

        string description = task.Description;
        task.Status = TaskStatus.Completed;
        SaveChanges();
        CommandUtils.WriteWithColor($"Task '{description}' marked as 'Completed'{CommandUtils.DoneEmoji}\n", ConsoleColor.Green);
    }

    public void ListAllTasks()
    {
        if (_tasks.Count == 0)
        {
            CommandUtils.WriteWithColor($"No tasks found. {CommandUtils.EmptyEmoji}\n", ConsoleColor.Yellow);
            return;
        }
        CommandUtils.PrintTable(_tasks);
    }

    public void ListToDoTasks()
    {
        var toDoTasks = _tasks.Where(t => t.Status == TaskStatus.ToDo).ToList();
        if (toDoTasks.Count == 0)
        {
            CommandUtils.WriteWithColor($"No To Do tasks found. {CommandUtils.EmptyEmoji}\n", ConsoleColor.Yellow);
            return;
        }
        CommandUtils.PrintTable(toDoTasks);
    }

    public void ListInProgressTasks()
    {
        var inProgressTasks = _tasks.Where(t => t.Status == TaskStatus.InProgress).ToList();
        if (inProgressTasks.Count == 0)
        {
            CommandUtils.WriteWithColor( $"No In Progress tasks found. {CommandUtils.EmptyEmoji}\n", ConsoleColor.Yellow);
            return;
        }
        CommandUtils.PrintTable(inProgressTasks);
    }

    public void ListCompletedTasks()
    {
        var completedTasks = _tasks.Where(t => t.Status == TaskStatus.Completed).ToList();
        if (completedTasks.Count == 0)
        {
            CommandUtils.WriteWithColor($"No completed tasks found. {CommandUtils.EmptyEmoji}\n", ConsoleColor.Yellow);
            return;
        }
        CommandUtils.PrintTable(completedTasks);
    }

    public static void ShowHelp()
    {
        CommandUtils.WriteWithColor(
            $"'help' : List all the commands.\n" +
            "'create <description>' : Create a new task. Ex: create 'Buy rice'\n" +
            "'edit <id> <description>' : Edit an existent task. Ex: edit 1 'Buy 20kg of rice'\n" +
            "'delete <id>' : Delete a task. Ex: delete 1\n" +
            "'update -p <id>' : Mark a task as 'In Progress'. Ex: update -p 1\n" +
            "'update -c <id>' : Mark a task as completed. Ex: update -c 1\n" +
            "'list' : List all tasks.\n" +
            "'list -h' : List all To Do tasks.\n" +
            "'list -p' : List all in progress tasks.\n" +
            "'list -c' : List all completed tasks.\n" +
            "'exit' : Close TaskTracker.\n", ConsoleColor.Cyan);
    }

    public void SaveChanges()
    {
        _dataJsonService.Save(_tasks);

    }

}
