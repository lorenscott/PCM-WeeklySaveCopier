using System.Text.Json;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private ListViewColumnSorter lvwColumnSorter;
        private FileSystemWatcher? _watcher;
        private bool _isInitializing;

        private static readonly string SettingsPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "PCM-WeeklySaveCopier", "settings.json");

        public Form1()
        {
            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();
            listView1.ListViewItemSorter = lvwColumnSorter;

            // COPY button: render a Segoe MDL2 copy icon alongside the text
            btnCopy.Image = RenderMdl2Glyph("\uE8C8", 14, Color.White);
            btnCopy.TextImageRelation = TextImageRelation.ImageBeforeText;

            // Tooltips
            var tt = new ToolTip { AutoPopDelay = 6000, InitialDelay = 400, ReshowDelay = 200 };
            tt.SetToolTip(cboVersion, "Select the installed PCM version to work with");
            tt.SetToolTip(txtSourceFolder, "Weekly Saves folder — .cdb files listed below come from here");
            tt.SetToolTip(txtDestFolder, "Active game database folder — the selected save will be copied here");
            tt.SetToolTip(btnOpenSource, "Open source folder in Explorer");
            tt.SetToolTip(btnOpenDest, "Open destination folder in Explorer");
            tt.SetToolTip(btnCopy, "Copy the selected weekly save to the active game database folder");
            tt.SetToolTip(listView1, "Select a save file to restore, then click COPY");
        }

        // Renders a single Segoe MDL2 Assets glyph onto a transparent bitmap.
        private static Bitmap RenderMdl2Glyph(string glyph, int size, Color color)
        {
            var bmp = new Bitmap(size, size, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            using var g = Graphics.FromImage(bmp);
            g.Clear(Color.Transparent);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            using var font = new Font("Segoe MDL2 Assets", size * 0.8f, GraphicsUnit.Pixel);
            using var brush = new SolidBrush(color);
            var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            g.DrawString(glyph, font, brush, new RectangleF(0, 0, size, size), sf);
            return bmp;
        }

        // ── Settings ────────────────────────────────────────────────────────────

        private class AppSettings
        {
            public string SourceFolder { get; set; } = "";
            public string DestFolder { get; set; } = "";
            public string SelectedPcmVersion { get; set; } = "";
            public int WindowLeft { get; set; } = -1;
            public int WindowTop { get; set; } = -1;
            public int WindowWidth { get; set; } = 0;
            public int WindowHeight { get; set; } = 0;
            public bool WindowMaximized { get; set; }
        }

        private AppSettings LoadSettings()
        {
            try
            {
                if (File.Exists(SettingsPath))
                    return JsonSerializer.Deserialize<AppSettings>(File.ReadAllText(SettingsPath)) ?? new AppSettings();
            }
            catch { }
            return new AppSettings();
        }

        private void SaveSettings()
        {
            try
            {
                var bounds = WindowState == FormWindowState.Normal ? Bounds : RestoreBounds;
                var settings = new AppSettings
                {
                    SourceFolder = txtSourceFolder.Text,
                    DestFolder = txtDestFolder.Text,
                    SelectedPcmVersion = cboVersion.SelectedItem?.ToString() ?? "",
                    WindowLeft = bounds.Left,
                    WindowTop = bounds.Top,
                    WindowWidth = bounds.Width,
                    WindowHeight = bounds.Height,
                    WindowMaximized = WindowState == FormWindowState.Maximized,
                };
                Directory.CreateDirectory(Path.GetDirectoryName(SettingsPath)!);
                File.WriteAllText(SettingsPath, JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true }));
            }
            catch { }
        }

        // ── PCM path detection ───────────────────────────────────────────────────

        private static string? FindSteamSubfolder(string pcmFolder, string subDir)
        {
            string path = Path.Combine(pcmFolder, subDir);
            if (!Directory.Exists(path)) return null;
            return Directory.GetDirectories(path).FirstOrDefault();
        }

        private string? GetAutoDetectedPath(string subDir)
        {
            if (cboVersion.SelectedItem == null) return null;
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string pcmFolder = Path.Combine(appData, cboVersion.SelectedItem.ToString()!);
            return FindSteamSubfolder(pcmFolder, subDir);
        }

        private void PopulateVersionDropdown()
        {
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var versions = Directory.GetDirectories(appData, "Pro Cycling Manager 20*")
                .Select(Path.GetFileName)
                .OrderByDescending(v => v)
                .ToList();

            cboVersion.Items.Clear();
            foreach (var v in versions)
                cboVersion.Items.Add(v!);
        }

        private void SetPcmVersion(string versionName)
        {
            if (cboVersion.Items.Count == 0) return;
            int idx = cboVersion.Items.IndexOf(versionName);
            cboVersion.SelectedIndex = idx >= 0 ? idx : 0;
        }

        private void ApplyVersionPaths()
        {
            var src = GetAutoDetectedPath("WeeklySaves");
            if (src != null) txtSourceFolder.Text = src;

            var dst = GetAutoDetectedPath("Cloud");
            if (dst != null) txtDestFolder.Text = dst;
        }

        // ── FileSystemWatcher ────────────────────────────────────────────────────

        private void SetupWatcher(string path)
        {
            _watcher?.Dispose();
            _watcher = null;
            if (!Directory.Exists(path)) return;

            _watcher = new FileSystemWatcher(path, "*.cdb")
            {
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite,
                EnableRaisingEvents = true
            };
            _watcher.Created += OnSourceFolderChanged;
            _watcher.Deleted += OnSourceFolderChanged;
            _watcher.Renamed += OnSourceFolderChanged;
        }

        private void OnSourceFolderChanged(object sender, FileSystemEventArgs e)
        {
            listView1.Invoke(RefreshList);
        }

        // ── Core UI logic ────────────────────────────────────────────────────────

        private void RefreshList()
        {
            listView1.Items.Clear();

            if (!Directory.Exists(txtSourceFolder.Text))
            {
                MessageBox.Show("The specified folder does not exist.", "Folder Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSourceFolder.Focus();
                return;
            }

            foreach (FileInfo fi in new DirectoryInfo(txtSourceFolder.Text).GetFiles("*.cdb"))
            {
                listView1.Items.Add(new ListViewItem(new[] { fi.Name, fi.LastWriteTime.ToString("s"), fi.Length.ToString() }));
            }

            lvwColumnSorter.SortColumn = 1;
            lvwColumnSorter.Order = SortOrder.Descending;
            listView1.Sort();
        }

        private static void OpenFolderInExplorer(string path)
        {
            if (Directory.Exists(path))
                System.Diagnostics.Process.Start("explorer.exe", path);
        }

        // ── Form events ──────────────────────────────────────────────────────────

        private void Form1_Load(object sender, EventArgs e)
        {
            _isInitializing = true;

            var settings = LoadSettings();

            // Restore window bounds
            if (settings.WindowWidth > 0 && settings.WindowHeight > 0)
            {
                var bounds = new Rectangle(settings.WindowLeft, settings.WindowTop, settings.WindowWidth, settings.WindowHeight);
                if (Screen.AllScreens.Any(s => s.WorkingArea.IntersectsWith(bounds)))
                    SetBounds(bounds.X, bounds.Y, bounds.Width, bounds.Height);
            }
            if (settings.WindowMaximized)
                WindowState = FormWindowState.Maximized;

            // Populate version dropdown and select saved (or latest) version
            PopulateVersionDropdown();
            SetPcmVersion(settings.SelectedPcmVersion);

            // Source: use saved path if it still exists, otherwise auto-detect
            if (!string.IsNullOrEmpty(settings.SourceFolder) && Directory.Exists(settings.SourceFolder))
                txtSourceFolder.Text = settings.SourceFolder;
            else
            {
                var src = GetAutoDetectedPath("WeeklySaves");
                if (src != null) txtSourceFolder.Text = src;
            }

            // Dest: use saved path if it still exists, otherwise auto-detect
            if (!string.IsNullOrEmpty(settings.DestFolder) && Directory.Exists(settings.DestFolder))
                txtDestFolder.Text = settings.DestFolder;
            else
            {
                var dst = GetAutoDetectedPath("Cloud");
                if (dst != null) txtDestFolder.Text = dst;
            }

            _isInitializing = false;

            SetupWatcher(txtSourceFolder.Text);
            RefreshList();
            listView1.Focus();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            SaveSettings();
            _watcher?.Dispose();
            btnCopy.Image?.Dispose();
            base.OnFormClosing(e);
        }

        private void cboVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isInitializing) return;
            ApplyVersionPaths();
            SetupWatcher(txtSourceFolder.Text);
            RefreshList();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;

            string s = listView1.SelectedItems[0].SubItems[0].Text;

            // Strip the first 3 dash-separated prefix segments; keep the rest as the suggested file name
            int dashCount = 0;
            int i = s.Length - 1;
            while (i >= 0)
            {
                if (s[i] == '-' && ++dashCount == 3) break;
                i--;
            }
            txtNewFileName.Text = dashCount == 3 ? s[(i + 1)..] : s;
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                lvwColumnSorter.Order = lvwColumnSorter.Order == SortOrder.Ascending
                    ? SortOrder.Descending
                    : SortOrder.Ascending;
            }
            else
            {
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }
            listView1.Sort();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sourceFile = Path.Combine(txtSourceFolder.Text, listView1.SelectedItems[0].SubItems[0].Text);
            string destFile = Path.Combine(txtDestFolder.Text, txtNewFileName.Text);

            if (File.Exists(destFile))
            {
                var result = MessageBox.Show(
                    $"{txtNewFileName.Text} already exists in the destination. Overwrite?",
                    "Confirm Overwrite",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (result != DialogResult.Yes) return;
            }

            File.Copy(sourceFile, destFile, true);

            if (File.Exists(destFile))
                MessageBox.Show($"{txtNewFileName.Text} copied!");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            bool valid = txtNewFileName.TextLength >= 5 && txtNewFileName.Text.EndsWith(".cdb", StringComparison.OrdinalIgnoreCase);
            btnCopy.Enabled = valid;
            btnCopy.BackColor = valid
                ? Color.FromArgb(0, 120, 212)
                : Color.FromArgb(100, 130, 160);
        }

        private void txtSourceFolder_Leave(object sender, EventArgs e)
        {
            SetupWatcher(txtSourceFolder.Text);
            RefreshList();
        }

        private void txtDestFolder_Leave(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtDestFolder.Text))
            {
                MessageBox.Show("The specified folder does not exist.", "Folder Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDestFolder.Focus();
            }
        }

        private void btnOpenSource_Click(object sender, EventArgs e) => OpenFolderInExplorer(txtSourceFolder.Text);
        private void btnOpenDest_Click(object sender, EventArgs e) => OpenFolderInExplorer(txtDestFolder.Text);

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            using var pen = new Pen(Color.FromArgb(0, 120, 212), 2);
            e.Graphics.DrawLine(pen, 0, panel1.Height - 1, panel1.Width, panel1.Height - 1);
        }
        private void label1_Click(object sender, EventArgs e) { }
        private void txtSourceFolder_TextChanged(object sender, EventArgs e) { }
    }
}
