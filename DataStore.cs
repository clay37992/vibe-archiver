using System.Text.Json;

namespace VibeArchiver;

public static class DataStore
{
    private static readonly string DataDir = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "VibeArchiver");

    private static readonly string DataFile = Path.Combine(DataDir, "archive.json");

    public static List<ArchiveEntry> Load()
    {
        if (!File.Exists(DataFile))
            return new List<ArchiveEntry>();

        var json = File.ReadAllText(DataFile);
        return JsonSerializer.Deserialize<List<ArchiveEntry>>(json) ?? new List<ArchiveEntry>();
    }

    public static void Save(List<ArchiveEntry> entries)
    {
        Directory.CreateDirectory(DataDir);
        var json = JsonSerializer.Serialize(entries, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(DataFile, json);
    }
}
