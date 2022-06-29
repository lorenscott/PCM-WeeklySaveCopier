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

        private void Form1_Load(object sender, EventArgs e)
        {

            DateTime dDateTime;
            long lLen;

            ListViewItem lvi;
            listView1.Items.Clear();
            DirectoryInfo dinfo = new DirectoryInfo(textBox1.Text);
            FileInfo[] smFiles = dinfo.GetFiles("*.cdb");
            foreach (FileInfo fi in smFiles)
            {
                dDateTime = fi.CreationTime;
                lLen = fi.Length;

                lvi = new ListViewItem(new string[] { fi.Name, dDateTime.ToString("s"), lLen.ToString() });
                listView1.Items.Add(lvi);
            }

            // Set the column number that is to be sorted; default to ascending.
            lvwColumnSorter.SortColumn = 1;
            lvwColumnSorter.Order = SortOrder.Descending;
            listView1.Sort();
 
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

            textBox3.Text = this.listView1.SelectedItems[0].SubItems[0].Text;
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
            // Use Path class to manipulate file and directory paths.
            string sourceFile = System.IO.Path.Combine(textBox1.Text, listView1.SelectedItems[0].SubItems[0].Text);
            string destFile = System.IO.Path.Combine(textBox2.Text, textBox3.Text);

            // To copy a file to another location and
            // overwrite the destination file if it already exists.
            System.IO.File.Copy(sourceFile, destFile, true);

            if (System.IO.File.Exists(destFile))
                MessageBox.Show(textBox3.Text + " copied!");
        }
    }
}