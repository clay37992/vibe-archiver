namespace VibeArchiver;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        splitContainer = new SplitContainer();
        leftPanel = new Panel();
        lblTitle = new Label();
        lblDropHint = new Label();
        txtSearch = new TextBox();
        listArchives = new ListBox();
        btnAddFolder = new Button();
        btnDelete = new Button();
        rightPanel = new Panel();
        lblFolderPath = new Label();
        lblFolderPathValue = new Label();
        btnOpenFolder = new Button();
        lblLastChange = new Label();
        txtLastChange = new TextBox();
        lblPercent = new Label();
        numPercent = new NumericUpDown();
        lblPriority = new Label();
        comboPriority = new ComboBox();
        lblCategory = new Label();
        comboCategory = new ComboBox();
        lblNotes = new Label();
        txtNotes = new TextBox();
        lblTechStack = new Label();
        txtTechStack = new TextBox();
        lblLinks = new Label();
        txtLinks = new TextBox();
        btnOpenLinks = new Button();
        btnSave = new Button();
        btnRemove = new Button();
        lblArchivedOn = new Label();
        lblArchivedOnValue = new Label();
        lblDropZone = new Label();

        ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
        splitContainer.Panel1.SuspendLayout();
        splitContainer.Panel2.SuspendLayout();
        splitContainer.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numPercent).BeginInit();
        SuspendLayout();

        // splitContainer
        splitContainer.Dock = DockStyle.Fill;
        splitContainer.SplitterDistance = 720;
        splitContainer.FixedPanel = FixedPanel.Panel1;
        

        // leftPanel
        leftPanel.Dock = DockStyle.Fill;
        leftPanel.Padding = new Padding(12);
        leftPanel.BackColor = Color.FromArgb(245, 245, 245);

        // lblTitle
        lblTitle.Text = "Vibe Archiver";
        lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        lblTitle.Dock = DockStyle.Top;
        lblTitle.Height = 40;
        lblTitle.TextAlign = ContentAlignment.MiddleLeft;
        lblTitle.ForeColor = Color.FromArgb(30, 30, 30);

        // lblDropHint
        lblDropHint.Text = "Drag & drop a folder here to archive it";
        lblDropHint.Font = new Font("Segoe UI", 8.5F);
        lblDropHint.Dock = DockStyle.Top;
        lblDropHint.Height = 22;
        lblDropHint.TextAlign = ContentAlignment.MiddleCenter;
        lblDropHint.ForeColor = Color.FromArgb(130, 130, 130);

        // txtSearch (FEATURE 1.2 - Search bar)
        txtSearch.Dock = DockStyle.Top;
        txtSearch.Font = new Font("Segoe UI", 9.5F);
        txtSearch.PlaceholderText = "\U0001F50D  Search projects...";
        txtSearch.BorderStyle = BorderStyle.FixedSingle;
        txtSearch.Height = 28;
        txtSearch.BackColor = Color.White;
        txtSearch.ForeColor = Color.FromArgb(50, 50, 50);
        txtSearch.Margin = new Padding(0, 4, 0, 4);

        // listArchives
        listArchives.Dock = DockStyle.Fill;
        listArchives.Font = new Font("Segoe UI", 9.5F);
        listArchives.BorderStyle = BorderStyle.None;
        listArchives.BackColor = Color.FromArgb(245, 245, 245);
        listArchives.IntegralHeight = false;
        listArchives.DrawMode = DrawMode.OwnerDrawFixed;
        listArchives.ItemHeight = 32;

        // btnAddFolder (FEATURE 4.3 - Add Folder button)
        btnAddFolder.Text = "+ Add Folder";
        btnAddFolder.Dock = DockStyle.Bottom;
        btnAddFolder.Height = 34;
        btnAddFolder.FlatStyle = FlatStyle.Flat;
        btnAddFolder.FlatAppearance.BorderSize = 0;
        btnAddFolder.BackColor = Color.FromArgb(60, 60, 60);
        btnAddFolder.ForeColor = Color.White;
        btnAddFolder.Cursor = Cursors.Hand;
        btnAddFolder.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

        // btnDelete
        btnDelete.Text = "Remove Selected";
        btnDelete.Dock = DockStyle.Bottom;
        btnDelete.Height = 34;
        btnDelete.FlatStyle = FlatStyle.Flat;
        btnDelete.FlatAppearance.BorderSize = 0;
        btnDelete.BackColor = Color.FromArgb(220, 220, 220);
        btnDelete.ForeColor = Color.FromArgb(80, 80, 80);
        btnDelete.Cursor = Cursors.Hand;
        btnDelete.Font = new Font("Segoe UI", 9F);

        // rightPanel
        rightPanel.Dock = DockStyle.Fill;
        rightPanel.Padding = new Padding(24, 20, 24, 20);
        rightPanel.AutoScroll = true;
        rightPanel.BackColor = Color.White;

        // lblDropZone
        lblDropZone.Text = "Drop a folder here";
        lblDropZone.Font = new Font("Segoe UI", 14F);
        lblDropZone.Dock = DockStyle.Fill;
        lblDropZone.TextAlign = ContentAlignment.MiddleCenter;
        lblDropZone.ForeColor = Color.FromArgb(180, 180, 180);

        // lblFolderPath
        lblFolderPath.Text = "Folder:";
        lblFolderPath.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblFolderPath.Location = new Point(24, 20);
        lblFolderPath.AutoSize = true;
        lblFolderPath.ForeColor = Color.FromArgb(50, 50, 50);

        // lblFolderPathValue
        lblFolderPathValue.Text = "";
        lblFolderPathValue.Font = new Font("Segoe UI", 9F);
        lblFolderPathValue.Location = new Point(24, 44);
        lblFolderPathValue.Size = new Size(340, 22);
        lblFolderPathValue.ForeColor = Color.FromArgb(100, 100, 100);
        lblFolderPathValue.AutoEllipsis = true;

        // btnOpenFolder (FEATURE 1.1 - Open Folder button)
        btnOpenFolder.Text = "Open Folder";
        btnOpenFolder.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        btnOpenFolder.Location = new Point(370, 40);
        btnOpenFolder.Size = new Size(100, 28);
        btnOpenFolder.FlatStyle = FlatStyle.Flat;
        btnOpenFolder.FlatAppearance.BorderSize = 1;
        btnOpenFolder.FlatAppearance.BorderColor = Color.FromArgb(100, 100, 100);
        btnOpenFolder.BackColor = Color.FromArgb(245, 245, 245);
        btnOpenFolder.ForeColor = Color.FromArgb(50, 50, 50);
        btnOpenFolder.Cursor = Cursors.Hand;

        // lblArchivedOn
        lblArchivedOn.Text = "Archived:";
        lblArchivedOn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblArchivedOn.Location = new Point(24, 74);
        lblArchivedOn.AutoSize = true;
        lblArchivedOn.ForeColor = Color.FromArgb(50, 50, 50);

        // lblArchivedOnValue
        lblArchivedOnValue.Text = "";
        lblArchivedOnValue.Font = new Font("Segoe UI", 9F);
        lblArchivedOnValue.Location = new Point(24, 98);
        lblArchivedOnValue.Size = new Size(400, 22);
        lblArchivedOnValue.ForeColor = Color.FromArgb(100, 100, 100);

        // lblLastChange
        lblLastChange.Text = "Last Change";
        lblLastChange.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblLastChange.Location = new Point(24, 134);
        lblLastChange.AutoSize = true;
        lblLastChange.ForeColor = Color.FromArgb(50, 50, 50);

        // txtLastChange
        txtLastChange.Font = new Font("Segoe UI", 9.5F);
        txtLastChange.Location = new Point(24, 158);
        txtLastChange.Size = new Size(400, 27);
        txtLastChange.BorderStyle = BorderStyle.FixedSingle;

        // lblPercent
        lblPercent.Text = "Completion %";
        lblPercent.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblPercent.Location = new Point(24, 196);
        lblPercent.AutoSize = true;
        lblPercent.ForeColor = Color.FromArgb(50, 50, 50);

        // numPercent
        numPercent.Font = new Font("Segoe UI", 9.5F);
        numPercent.Location = new Point(24, 220);
        numPercent.Size = new Size(120, 27);
        numPercent.Minimum = 0;
        numPercent.Maximum = 100;
        numPercent.BorderStyle = BorderStyle.FixedSingle;

        // lblPriority
        lblPriority.Text = "Priority";
        lblPriority.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblPriority.Location = new Point(24, 258);
        lblPriority.AutoSize = true;
        lblPriority.ForeColor = Color.FromArgb(50, 50, 50);

        // comboPriority
        comboPriority.Font = new Font("Segoe UI", 9.5F);
        comboPriority.Location = new Point(24, 282);
        comboPriority.Size = new Size(160, 27);
        comboPriority.DropDownStyle = ComboBoxStyle.DropDownList;
        comboPriority.Items.AddRange(new object[] { "Low", "Medium", "High" });
        comboPriority.FlatStyle = FlatStyle.Flat;

        // lblCategory (FEATURE 2.1 - Project Type / Category)
        lblCategory.Text = "Category";
        lblCategory.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblCategory.Location = new Point(200, 258);
        lblCategory.AutoSize = true;
        lblCategory.ForeColor = Color.FromArgb(50, 50, 50);

        // comboCategory (FEATURE 2.1 - Project Type / Category)
        comboCategory.Font = new Font("Segoe UI", 9.5F);
        comboCategory.Location = new Point(200, 282);
        comboCategory.Size = new Size(180, 27);
        comboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
        comboCategory.Items.AddRange(new object[] {
            "Uncategorized", "Game", "Website", "App", "Script",
            "Library", "School", "Art", "Music", "Tutorial", "Other"
        });
        comboCategory.FlatStyle = FlatStyle.Flat;

        // lblNotes
        lblNotes.Text = "Notes";
        lblNotes.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblNotes.Location = new Point(24, 320);
        lblNotes.AutoSize = true;
        lblNotes.ForeColor = Color.FromArgb(50, 50, 50);

        // txtNotes
        txtNotes.Font = new Font("Segoe UI", 9.5F);
        txtNotes.Location = new Point(24, 344);
        txtNotes.Size = new Size(400, 80);
        txtNotes.Multiline = true;
        txtNotes.ScrollBars = ScrollBars.Vertical;
        txtNotes.BorderStyle = BorderStyle.FixedSingle;

        // lblTechStack (FEATURE 2.2 - Tech Stack / Language)
        lblTechStack.Text = "Tech Stack / Language";
        lblTechStack.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblTechStack.Location = new Point(24, 434);
        lblTechStack.AutoSize = true;
        lblTechStack.ForeColor = Color.FromArgb(50, 50, 50);

        // txtTechStack (FEATURE 2.2 - Tech Stack / Language)
        txtTechStack.Font = new Font("Segoe UI", 9.5F);
        txtTechStack.Location = new Point(24, 458);
        txtTechStack.Size = new Size(400, 27);
        txtTechStack.BorderStyle = BorderStyle.FixedSingle;

        // lblLinks (FEATURE 2.4 - Links Field)
        lblLinks.Text = "Links";
        lblLinks.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblLinks.Location = new Point(24, 496);
        lblLinks.AutoSize = true;
        lblLinks.ForeColor = Color.FromArgb(50, 50, 50);

        // txtLinks (FEATURE 2.4 - Links Field)
        txtLinks.Font = new Font("Segoe UI", 9.5F);
        txtLinks.Location = new Point(24, 520);
        txtLinks.Size = new Size(400, 27);
        txtLinks.BorderStyle = BorderStyle.FixedSingle;
        txtLinks.PlaceholderText = "URLs separated by newlines";

        // btnOpenLinks (FEATURE 2.4 - Open Links button)
        btnOpenLinks.Text = "Open Links";
        btnOpenLinks.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        btnOpenLinks.Location = new Point(434, 520);
        btnOpenLinks.Size = new Size(90, 27);
        btnOpenLinks.FlatStyle = FlatStyle.Flat;
        btnOpenLinks.FlatAppearance.BorderColor = Color.FromArgb(100, 100, 100);
        btnOpenLinks.FlatAppearance.BorderSize = 1;
        btnOpenLinks.BackColor = Color.FromArgb(245, 245, 245);
        btnOpenLinks.ForeColor = Color.FromArgb(50, 50, 50);
        btnOpenLinks.Cursor = Cursors.Hand;

        // btnSave
        btnSave.Text = "Save Changes";
        btnSave.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnSave.Location = new Point(24, 560);
        btnSave.Size = new Size(180, 36);
        btnSave.FlatStyle = FlatStyle.Flat;
        btnSave.FlatAppearance.BorderSize = 0;
        btnSave.BackColor = Color.FromArgb(60, 60, 60);
        btnSave.ForeColor = Color.White;
        btnSave.Cursor = Cursors.Hand;

        // btnRemove
        btnRemove.Text = "Remove from Archive";
        btnRemove.Font = new Font("Segoe UI", 9F);
        btnRemove.Location = new Point(214, 560);
        btnRemove.Size = new Size(210, 36);
        btnRemove.FlatStyle = FlatStyle.Flat;
        btnRemove.FlatAppearance.BorderSize = 0;
        btnRemove.BackColor = Color.FromArgb(235, 235, 235);
        btnRemove.ForeColor = Color.FromArgb(120, 40, 40);
        btnRemove.Cursor = Cursors.Hand;

        // Assemble left panel
        leftPanel.Controls.Add(listArchives);
        leftPanel.Controls.Add(txtSearch);
        leftPanel.Controls.Add(lblDropHint);
        leftPanel.Controls.Add(lblTitle);
        leftPanel.Controls.Add(btnAddFolder);
        leftPanel.Controls.Add(btnDelete);

        // Assemble right panel (add controls in reverse for proper stacking)
        rightPanel.Controls.Add(btnSave);
        rightPanel.Controls.Add(btnRemove);
        rightPanel.Controls.Add(txtLinks);
        rightPanel.Controls.Add(btnOpenLinks);
        rightPanel.Controls.Add(lblLinks);
        rightPanel.Controls.Add(txtTechStack);
        rightPanel.Controls.Add(lblTechStack);
        rightPanel.Controls.Add(txtNotes);
        rightPanel.Controls.Add(lblNotes);
        rightPanel.Controls.Add(comboCategory);
        rightPanel.Controls.Add(lblCategory);
        rightPanel.Controls.Add(comboPriority);
        rightPanel.Controls.Add(lblPriority);
        rightPanel.Controls.Add(numPercent);
        rightPanel.Controls.Add(lblPercent);
        rightPanel.Controls.Add(txtLastChange);
        rightPanel.Controls.Add(lblLastChange);
        rightPanel.Controls.Add(lblArchivedOnValue);
        rightPanel.Controls.Add(lblArchivedOn);
        rightPanel.Controls.Add(btnOpenFolder);
        rightPanel.Controls.Add(lblFolderPathValue);
        rightPanel.Controls.Add(lblFolderPath);
        rightPanel.Controls.Add(lblDropZone);

        // splitContainer panels
        splitContainer.Panel1.Controls.Add(leftPanel);
        splitContainer.Panel2.Controls.Add(rightPanel);

        Controls.Add(splitContainer);

        // Form
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(860, 560);
        MinimumSize = new Size(700, 480);
        Text = "Vibe Archiver";
        StartPosition = FormStartPosition.CenterScreen;
        WindowState = FormWindowState.Maximized;
        BackColor = Color.White;

        ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
        splitContainer.Panel1.ResumeLayout(false);
        splitContainer.Panel2.ResumeLayout(false);
        splitContainer.Panel2.PerformLayout();
        splitContainer.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)numPercent).EndInit();
        ResumeLayout(false);
    }

    private SplitContainer splitContainer;
    private Panel leftPanel;
    private Panel rightPanel;
    private Label lblTitle;
    private Label lblDropHint;
    private TextBox txtSearch;
    private ListBox listArchives;
    private Button btnAddFolder;
    private Button btnDelete;
    private Label lblDropZone;
    private Label lblFolderPath;
    private Label lblFolderPathValue;
    private Button btnOpenFolder;
    private Label lblArchivedOn;
    private Label lblArchivedOnValue;
    private Label lblLastChange;
    private TextBox txtLastChange;
    private Label lblPercent;
    private NumericUpDown numPercent;
    private Label lblPriority;
    private ComboBox comboPriority;
    private Label lblCategory;
    private ComboBox comboCategory;
    private Label lblNotes;
    private TextBox txtNotes;
    private Label lblTechStack;
    private TextBox txtTechStack;
    private Label lblLinks;
    private TextBox txtLinks;
    private Button btnOpenLinks;
    private Button btnSave;
    private Button btnRemove;
}
