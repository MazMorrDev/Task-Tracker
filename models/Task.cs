namespace TaskTracker;

public class Task(int id, string description)
{
    public int Id { get; set; } = id;
    public string Description { get; set; } = description;
    public TaskStatus Status { get; set; }
    public DateTime CreatedDate { get; set; }
}
