namespace VibeArchiver;

public class ArchiveEntry
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string FolderPath { get; set; } = "";
    public string FolderName { get; set; } = "";
    public string LastChange { get; set; } = "";
    public int PercentDone { get; set; }
    public string Priority { get; set; } = "Low";
    public string Notes { get; set; } = "";
    public string Category { get; set; } = "Uncategorized";
    public string TechStack { get; set; } = "";
    public string Links { get; set; } = "";
    public DateTime ArchivedOn { get; set; } = DateTime.Now;
}
