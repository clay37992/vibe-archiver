using System.Diagnostics;

namespace VibeArchiver;

public partial class MainForm : Form
{
    private List<ArchiveEntry> _entries = new();
    private List<ArchiveEntry> _filteredEntries = new();
    private ArchiveEntry? _selected;

    public MainForm()
    {
        InitializeComponent();
        SetupEvents();
        LoadData();
        UpdateRightPanel(false);
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        splitContainer.SplitterDistance = 720;
    }

    private void SetupEvents()
    {
        AllowDrop = true;
        DragEnter += OnDragEnter;
        DragDrop += OnDragDrop;

        listArchives.SelectedIndexChanged += OnListSelect;
        listArchives.DrawItem += OnDrawListItem;
        btnSave.Click += OnSave;
        btnRemove.Click += OnRemove;
        btnDelete.Click += OnRemove;
        btnOpenFolder.Click += OnOpenFolder;
        btnAddFolder.Click += OnAddFolder;
        txtSearch.TextChanged += OnSearchChanged;
        btnOpenLinks.Click += OnOpenLinks;
    }

    // ─── FEATURE 4.3: Add Folder via folder picker dialog ───
    private void OnAddFolder(object? sender, EventArgs e)
    {
        using var dialog = new FolderBrowserDialog
        {
            Description = "Select a project folder to archive",
            UseDescriptionForTitle = true,
            ShowNewFolderButton = false
        };

        if (dialog.ShowDialog() != DialogResult.OK)
            return;

        var path = dialog.SelectedPath;

        bool alreadyExists = _entries.Any(x =>
            string.Equals(x.FolderPath, path, StringComparison.OrdinalIgnoreCase));

        if (alreadyExists)
        {
            MessageBox.Show("This folder is already in your archive.", "Vibe Archiver",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        AddEntryForPath(path);
    }

    // ─── FEATURE 1.1: Open folder in File Explorer ───
    private void OnOpenFolder(object? sender, EventArgs e)
    {
        if (_selected == null) return;

        if (Directory.Exists(_selected.FolderPath))
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = _selected.FolderPath,
                UseShellExecute = true
            });
        }
        else
        {
            MessageBox.Show(
                "This folder no longer exists on disk.\n\n" + _selected.FolderPath,
                "Folder Not Found",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }

    // ─── FEATURE 2.4: Open Links in browser ───
    private void OnOpenLinks(object? sender, EventArgs e)
    {
        var text = txtLinks.Text.Trim();
        if (string.IsNullOrEmpty(text)) return;

        var urls = text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        foreach (var url in urls)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch
            {
                MessageBox.Show(
                    $"Could not open link:\n{url}\n\nMake sure it starts with http:// or https://",
                    "Invalid Link",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }

    // ─── FEATURE 1.2: Search / filter ───
    private void OnSearchChanged(object? sender, EventArgs e)
    {
        ApplyFilter();
    }

    private void ApplyFilter()
    {
        var query = txtSearch.Text.Trim();

        if (string.IsNullOrEmpty(query))
        {
            _filteredEntries = new List<ArchiveEntry>(_entries);
        }
        else
        {
            _filteredEntries = _entries.Where(entry =>
                entry.FolderName.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                entry.Notes.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                entry.Category.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                entry.TechStack.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                entry.LastChange.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                entry.Priority.Contains(query, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }

        RefreshList();
    }

    private void OnDragEnter(object? sender, DragEventArgs e)
    {
        if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop))
            e.Effect = DragDropEffects.Copy;
        else
            e.Effect = DragDropEffects.None;
    }

    private void OnDragDrop(object? sender, DragEventArgs e)
    {
        if (e.Data == null || e.Data.GetData(DataFormats.FileDrop) is not string[] paths || paths.Length == 0)
            return;

        var path = paths[0];

        if (!Directory.Exists(path))
        {
            MessageBox.Show("Please drop a folder, not a file.", "Vibe Archiver",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        bool alreadyExists = _entries.Any(x =>
            string.Equals(x.FolderPath, path, StringComparison.OrdinalIgnoreCase));

        if (alreadyExists)
        {
            MessageBox.Show("This folder is already in your archive.", "Vibe Archiver",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var result = MessageBox.Show(
            $"Archive this folder?\n\n{path}",
            "Confirm Archive",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (result != DialogResult.Yes)
            return;

        AddEntryForPath(path);
    }

    private void AddEntryForPath(string path)
    {
        var entry = new ArchiveEntry
        {
            FolderPath = path,
            FolderName = Path.GetFileName(path),
            ArchivedOn = DateTime.Now,
            PercentDone = 0,
            Priority = "Low",
            Category = "Uncategorized"
        };

        _entries.Add(entry);
        SaveData();
        ApplyFilter();
        SelectEntry(entry);
    }

    private void OnListSelect(object? sender, EventArgs e)
    {
        if (listArchives.SelectedIndex < 0 || listArchives.SelectedIndex >= _filteredEntries.Count)
        {
            _selected = null;
            UpdateRightPanel(false);
            return;
        }

        _selected = _filteredEntries[listArchives.SelectedIndex];
        PopulateRightPanel(_selected);
        UpdateRightPanel(true);
    }

    // ─── FEATURE 3.1: Color-coded priorities in the list ───
    private void OnDrawListItem(object? sender, DrawItemEventArgs e)
    {
        if (e.Index < 0 || e.Index >= _filteredEntries.Count) return;

        e.DrawBackground();

        // Draw separator line between items
        if (e.Index > 0)
        {
            using var sepPen = new Pen(Color.FromArgb(60, 60, 60), 2.5f);
            e.Graphics.DrawLine(sepPen, e.Bounds.Left + 4, e.Bounds.Top, e.Bounds.Right - 4, e.Bounds.Top);
        }

        var entry = _filteredEntries[e.Index];

        // Priority color indicator
        Color priorityColor = entry.Priority switch
        {
            "High" => Color.FromArgb(220, 60, 60),
            "Medium" => Color.FromArgb(230, 170, 30),
            "Low" => Color.FromArgb(80, 180, 80),
            _ => Color.FromArgb(150, 150, 150)
        };

        // Draw colored priority dot
        int dotSize = 10;
        int dotX = e.Bounds.Left + 8;
        int dotY = e.Bounds.Top + (e.Bounds.Height - dotSize) / 2;
        using (var dotBrush = new SolidBrush(priorityColor))
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.FillEllipse(dotBrush, dotX, dotY, dotSize, dotSize);
        }

        // Draw entry text (with category)
        var displayText = $"{entry.FolderName}  -  {entry.PercentDone}%";
        if (entry.Category != "Uncategorized" && !string.IsNullOrEmpty(entry.Category))
            displayText = $"{entry.FolderName}  [{entry.Category}]  -  {entry.PercentDone}%";

        var font = e.Font ?? listArchives.Font;
        using var brush = new SolidBrush(e.ForeColor);
        var textRect = new Rectangle(e.Bounds.Left + 24, e.Bounds.Top + 4, e.Bounds.Width - 30, e.Bounds.Height - 4);
        var sf = new StringFormat { LineAlignment = StringAlignment.Center, Trimming = StringTrimming.EllipsisCharacter };
        e.Graphics.DrawString(displayText, font, brush, textRect, sf);

        e.DrawFocusRectangle();
    }

    private void PopulateRightPanel(ArchiveEntry entry)
    {
        lblFolderPathValue.Text = entry.FolderPath;
        lblArchivedOnValue.Text = entry.ArchivedOn.ToString("MMM dd, yyyy  HH:mm");
        txtLastChange.Text = entry.LastChange;
        numPercent.Value = entry.PercentDone;
        comboPriority.SelectedItem = entry.Priority;
        comboCategory.SelectedItem = entry.Category;
        txtNotes.Text = entry.Notes;
        txtTechStack.Text = entry.TechStack;
        txtLinks.Text = entry.Links;
    }

    private void UpdateRightPanel(bool hasSelection)
    {
        lblDropZone.Visible = !hasSelection;
        lblFolderPath.Visible = hasSelection;
        lblFolderPathValue.Visible = hasSelection;
        btnOpenFolder.Visible = hasSelection;
        lblArchivedOn.Visible = hasSelection;
        lblArchivedOnValue.Visible = hasSelection;
        lblLastChange.Visible = hasSelection;
        txtLastChange.Visible = hasSelection;
        lblPercent.Visible = hasSelection;
        numPercent.Visible = hasSelection;
        lblPriority.Visible = hasSelection;
        comboPriority.Visible = hasSelection;
        lblCategory.Visible = hasSelection;
        comboCategory.Visible = hasSelection;
        lblNotes.Visible = hasSelection;
        txtNotes.Visible = hasSelection;
        lblTechStack.Visible = hasSelection;
        txtTechStack.Visible = hasSelection;
        lblLinks.Visible = hasSelection;
        txtLinks.Visible = hasSelection;
        btnOpenLinks.Visible = hasSelection;
        btnSave.Visible = hasSelection;
        btnRemove.Visible = hasSelection;
    }

    private void OnSave(object? sender, EventArgs e)
    {
        if (_selected == null) return;

        _selected.LastChange = txtLastChange.Text.Trim();
        _selected.PercentDone = (int)numPercent.Value;
        _selected.Priority = comboPriority.SelectedItem?.ToString() ?? "Low";
        _selected.Category = comboCategory.SelectedItem?.ToString() ?? "Uncategorized";
        _selected.Notes = txtNotes.Text.Trim();
        _selected.TechStack = txtTechStack.Text.Trim();
        _selected.Links = txtLinks.Text.Trim();

        SaveData();
        ApplyFilter();
        MessageBox.Show("Saved.", "Vibe Archiver", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void OnRemove(object? sender, EventArgs e)
    {
        if (_selected == null) return;

        var result = MessageBox.Show(
            $"Remove \"{_selected.FolderName}\" from the archive?\n\nThe actual folder on disk will NOT be deleted.",
            "Confirm Remove",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (result != DialogResult.Yes)
            return;

        _entries.Remove(_selected);
        _selected = null;
        SaveData();
        ApplyFilter();
        UpdateRightPanel(false);
    }

    private void RefreshList()
    {
        var previouslySelected = _selected;
        listArchives.Items.Clear();

        foreach (var entry in _filteredEntries)
            listArchives.Items.Add(entry.FolderName);

        // Re-select the previously selected entry if it's still in the filtered list
        if (previouslySelected != null)
        {
            var idx = _filteredEntries.IndexOf(previouslySelected);
            if (idx >= 0)
                listArchives.SelectedIndex = idx;
        }
    }

    private void SelectEntry(ArchiveEntry entry)
    {
        var idx = _filteredEntries.IndexOf(entry);
        if (idx >= 0)
            listArchives.SelectedIndex = idx;
    }

    private void LoadData()
    {
        _entries = DataStore.Load();
        _filteredEntries = new List<ArchiveEntry>(_entries);
        RefreshList();
    }

    private void SaveData()
    {
        DataStore.Save(_entries);
    }
}
