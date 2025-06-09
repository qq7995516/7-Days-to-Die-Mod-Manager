namespace 七日杀Mod管理器
{
    public partial class BackupWindow : Form
    {
        public Form1 form;
        public BackupWindow(Form1 form1)
        {
            form = form1;
            InitializeComponent();
        }

        private void BackupWindow_Load(object sender, EventArgs e)
        {
            //载入配置
            textBox_ArchivePath.Text = Settings1.Default.ArchivePath;
            textBox_BackupPath.Text = Settings1.Default.BackupPath;
            textBox_MaxBackup.Text = Settings1.Default.MaxBackup.ToString();
            textBox2_BackupInterval.Text = Settings1.Default.BackupInterval.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var listitem = new ListViewItem();
            listitem.Text = textBox_ArchivePath.Text;
            listitem.SubItems.Add(textBox_BackupPath.Text);
            listitem.SubItems.Add(textBox_MaxBackup.Text);
            listitem.SubItems.Add(textBox2_BackupInterval.Text);
            listitem.SubItems.Add(textBox2_BackupInterval.Text);
            form.listView2.Items.Add(listitem);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var archivePath = Tool.SelectFolder(textBox_ArchivePath.Text);
            if (Directory.Exists(archivePath))
            {
                Settings1.Default.ArchivePath = archivePath;
                textBox_ArchivePath.Text = archivePath;
                Settings1.Default.Save();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var backupPath = Tool.SelectFolder(textBox_BackupPath.Text);
            if (Directory.Exists(backupPath))
            {
                Settings1.Default.BackupPath = backupPath;
                textBox_BackupPath.Text = backupPath;
                Settings1.Default.Save();
            }
        }

        private void textBox_MaxBackup_TextChanged(object sender, EventArgs e)
        {
            Settings1.Default.MaxBackup = int.TryParse(textBox_MaxBackup.Text, out int mb) ? mb : Settings1.Default.MaxBackup;
            Settings1.Default.Save();
        }

        private void textBox2_BackupInterval_TextChanged(object sender, EventArgs e)
        {
            Settings1.Default.BackupInterval = int.TryParse(textBox2_BackupInterval.Text, out int bi) ? bi : Settings1.Default.BackupInterval;
            Settings1.Default.Save();
        }
    }
}
