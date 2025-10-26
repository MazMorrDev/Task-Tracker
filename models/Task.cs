namespace TaskTracker;

public class Task(int id, string description)
{
    private int Id { get; set; } = id;
    private string Description { get; set; } = description;
    private TaskStatus Status { get; set; }
    private DateTime CreatedDate { get; set; }
}
