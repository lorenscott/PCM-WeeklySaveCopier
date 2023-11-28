namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private ListViewColumnSorter lvwColumnSorter;

        public Form1()
        {
            InitializeComponent();

            // Create an instance of a ListView column sorter and assign it
            // to the ListView control.
            lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
         }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void RefreshList()
        {
            DateTime dDateTime;
            long lLen;

            ListViewItem lvi;
            listView1.Items.Clear();

            // Check if the directory exists
            if (!Directory.Exists(txtSourceFolder.Text))
            {
                MessageBox.Show("The specified folder does not exist.", "Folder Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSourceFolder.Focus();
                return; // Exit the function if the folder doesn't exist
            }

            DirectoryInfo dinfo = new DirectoryInfo(txtSourceFolder.Text);
            FileInfo[] smFiles = dinfo.GetFiles("*.cdb");
            foreach (FileInfo fi in smFiles)
            {
                dDateTime = fi.CreationTime;
                lLen = fi.Length;

                lvi = new ListViewItem(new string[] { fi.Name, dDateTime.ToString("s"), lLen.ToString() });
                listView1.Items.Add(lvi);
            }

            // Set the initial sort to be on the second column (Date), descending.
            lvwColumnSorter.SortColumn = 1;
            lvwColumnSorter.Order = SortOrder.Descending;
            listView1.Sort();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            string userName = Environment.UserName;
            string subFolderName = "LorenScott"; // TO-DO: Figure out how to dynamically set this at run-time
            string basePath = @"C:\Users\";

            // Construct the path dynamically
            string fullPath = Path.Combine(basePath, $"{userName}\\AppData\\Roaming\\Pro Cycling Manager 2023\\WeeklySaves\\{subFolderName}");

            // Set the Text property of txtSourceFolder
            txtSourceFolder.Text = fullPath;

            RefreshList();
  
            // Give focus to the list of file names
            listView1.Focus();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count == 0)
                return;

            string s = this.listView1.SelectedItems[0].SubItems[0].Text;
            int i;
            int count = 0;

            for (i = s.Length - 1; i >= 0; i--)
            {

                if (s[i] == '-')
                {
                    count++;
                    if (count == 3)
                    {
                        break;
                    }
                }
            }

            txtNewFileName.Text = s.Substring(i + 1, s.Length - i - 1);
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listView1.Sort();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Use Path class to manipulate source and destination file names and directory paths.
            string sourceFile = System.IO.Path.Combine(txtSourceFolder.Text, listView1.SelectedItems[0].SubItems[0].Text);
            string destFile = System.IO.Path.Combine(txtDestFolder.Text, txtNewFileName.Text);

            // Copy file to destination, overwriting same file name if it already exists.
            System.IO.File.Copy(sourceFile, destFile, true);

            if (System.IO.File.Exists(destFile))
                MessageBox.Show(txtNewFileName.Text + " copied!");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            btnCopy.Enabled = ((txtNewFileName.TextLength >= 5) && (txtNewFileName.Text.ToLower().EndsWith(".cdb")));
        }

        private void txtSourceFolder_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSourceFolder_Leave(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void txtDestFolder_Leave(object sender, EventArgs e)
        {
            // Check if the directory exists
            if (!Directory.Exists(txtDestFolder.Text))
            {
                MessageBox.Show("The specified folder does not exist.", "Folder Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDestFolder.Focus();
                return; // Exit the function if the folder doesn't exist
            }
        }
    }
}