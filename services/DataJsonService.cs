using System.Text.Json;

namespace TaskTracker;

public class DataJsonService
{
    private readonly string _dataFilePath;

    public DataJsonService()
    {
        var projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
        var dataDir = Path.Combine(projectRoot, "data");

        if (!Directory.Exists(dataDir))
            Directory.CreateDirectory(dataDir);

        _dataFilePath = Path.Combine(dataDir, "data.json");
    }

    public List<Task> Load()
    {
        if (!File.Exists(_dataFilePath))
            return [];

        string json = File.ReadAllText(_dataFilePath);

        
        if (string.IsNullOrWhiteSpace(json))
            return [];

        try
        {
            return JsonSerializer.Deserialize<List<Task>>(json) ?? [];
        }
        catch (JsonException)
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("El archivo data.json está dañado o no tiene formato válido. Se reiniciará. ദ്ദി(ᗜˬᗜ)");
            Console.ResetColor();
            return [];
        }
    }

    public void Save(List<Task>? tasks)
    {
        string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_dataFilePath, json);
    }
}
