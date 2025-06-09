using SevenZip;
using System.Net.Sockets;
using System.Net;
using System.Security.AccessControl;
using static 七日杀Mod管理器.Tool;
using System.Text;

namespace 七日杀Mod管理器
{
    public partial class Form1 : Form
    {
        //public string TmpFolderPath = AppDomain.CurrentDomain.BaseDirectory + "TmpFolder";

        public static string WinRAR_Path = $"{AppDomain.CurrentDomain.BaseDirectory}/WinRAR/WinRAR.exe";
        public DownloadWindow? DW = null;
        public ArchiveManager? AM = null;
        public static List<FileInfo> DataFileInfos = default;
        public static Form1 form1 = null;
        /// <summary>
        /// 存放缓存的文件
        /// </summary>
        public static Dictionary<FileInfo, byte[]> FileBytes = new Dictionary<FileInfo, byte[]>();
        public Form1()
        {
            InitializeComponent();
        }

        public async void Form1_Load(object sender, EventArgs e)
        {
            form1 = this;
            listView1.ColumnClick += Tool.SortListView;
            listView2.ColumnClick += Tool.SortListView;

            textBox_GamePath.Text = Settings1.Default.GameFolderPath;
            if (Directory.Exists(textBox_GamePath.Text))
            {
                //检查Mods文件夹是否存在
                if (!Directory.Exists($"{textBox_GamePath.Text}/Mods"))
                    Directory.CreateDirectory($"{textBox_GamePath.Text}/Mods");
                //刷新Mods列表
                listView1.RefreshModListView(textBox_GamePath.Text);
                //读取 7DaysToDie_Data 文件夹的所有文件
                var str1 = $"{textBox_GamePath.Text}/7DaysToDie_Data";
                var DataDirectoryInfo = new DirectoryInfo(str1);
                //加载Data文件夹中的文件
                if (DataDirectoryInfo.Exists)
                    DataFileInfos = DataDirectoryInfo.GetFiles("*", new EnumerationOptions() { RecurseSubdirectories = true }).ToList();
            }
            await Task.Delay(1);

            Settings1.Default.BackupListViewStr.ToListView(listView2);
            //启动循环
            BackupLoop();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (new DirectoryInfo(textBox_GamePath.Text).Exists)
            {
                Settings1.Default.GameFolderPath = textBox_GamePath.Text;
                Settings1.Default.Save();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var GamePath = Tool.SelectFolder(textBox_GamePath.Text);
            if (GamePath != null && Directory.Exists(GamePath))
            {
                textBox_GamePath.Text = GamePath;
                Settings1.Default.GameFolderPath = GamePath;
                Settings1.Default.Save();
                listView1.RefreshModListView(GamePath);
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!Directory.Exists(textBox_GamePath.Text))
            {
                MessageBox.Show("请先选择正确的七日杀文件夹再删除mod");
                return;
            }

            if (!Tool.WarningWindow(text: "确定要删除Mod?"))
                return;
            foreach (ListViewItem item in listView1.CheckedItems)
            {
                if (Directory.Exists($"{textBox_GamePath.Text}/Mods/{item.Text}"))
                    Directory.Delete($"{textBox_GamePath.Text}/Mods/{item.Text}", true);
            }
            //刷新
            listView1.RefreshModListView(textBox_GamePath.Text);
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(textBox_GamePath.Text))
            {
                MessageBox.Show("请先选择正确的七日杀文件夹再刷新");
                return;
            }
            //刷新
            listView1.RefreshModListView(textBox_GamePath.Text);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (DW == null || DW.IsDisposed)
                DW = new DownloadWindow(this);
            DW.Show();
        }

        private async void 压缩包ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var files = Tool.OpenFileDialog(Filter: "压缩包(*.rar;*.7z;*.zip)|*.rar;*.7z;*.zip", Multiselect: true);
            if (files == null)
                return;
            foreach (var item in files)
            {
                await item.InstallTheCompressedPackage(WinRAR_Path);
                ////以压缩文件名创建一个文件夹
                //var TmpDir = Directory.CreateDirectory(Path.GetFileNameWithoutExtension(item));
                ////解压到临时文件夹里
                //var ret = await Tool.RunExternalProgramAsync(WinRAR_Path, $"x {item} {TmpDir.FullName}");
                //if (ret.ExitCode != 0)
                //{
                //    MessageBox.Show($"解压失败: {item}");
                //    continue;
                //}
                ////处理解压好的Mod
                //await TmpDir.ModProcessing($"{textBox1.Text}/Mods");
            }
            listView1.RefreshModListView(textBox_GamePath.Text);
        }


        private async void 文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dirs = Tool.SelectFolder(AppDomain.CurrentDomain.BaseDirectory);
            await dirs?.InstallFolderModAsync($"{textBox_GamePath.Text}/Mods");
            //if (dirs != null)
            //    await new DirectoryInfo(dirs).ModProcessing($"{textBox1.Text}/Mods");

            listView1.RefreshModListView(textBox_GamePath.Text);
        }



        private void button4_Click(object sender, EventArgs e)
        {
            if (AM == null || AM.IsDisposed)
                AM = new ArchiveManager();
            AM.Show();
        }

        /// <summary>
        /// 备份循环
        /// </summary>
        /// <param name="BackupIntervalTime">备份间隔时间</param>
        public async void BackupLoop()
        {
            await Task.Run(async () =>
             {
                 while (true)
                 {
                     await Task.Delay(1000 * 60 * 60);
                     //遍历所有备份行
                     foreach (ListViewItem item in listView2.Items)
                     {
                         //备份路径
                         var ArchivePath = item.SubItems[0].Text;
                         //存放路径
                         var BackupPath = item.SubItems[1].Text;
                         //最大备份数
                         var MaxBackup = int.Parse(item.SubItems[2].Text);
                         //备份间隔
                         var BackupInterval = int.Parse(item.SubItems[3].Text);
                         //计算倒计时-1
                         item.SubItems[4].Text = (int.Parse(item.SubItems[4].Text) - 1).ToString();
                         //获取倒计时
                         var Countdown = int.Parse(item.SubItems[4].Text);
                         //MessageBox.Show($"{item.SubItems[0].Text}\r\n" +
                         //    $"{item.SubItems[1].Text}\r\n" +
                         //    $"{item.SubItems[2].Text}\r\n" +
                         //    $"{item.SubItems[3].Text}\r\n" +
                         //    $"{item.SubItems[4].Text}\r\n");
                         //如果倒计时结束
                         if (Countdown <= 0)
                         {
                             //且被勾选
                             if (item.Checked)
                             {
                                 await BackupAsync(ArchivePath, BackupPath, MaxBackup);
                             }
                             //重置倒计时
                             item.SubItems[4].Text = BackupInterval.ToString();
                         }
                     }
                 }
             });
        }

        /// <summary>
        /// 备份
        /// </summary>
        /// <param name="TargetArchivePath">存档所在文件夹</param>
        /// <param name="BackupPath">备份存放文件夹路径</param>
        /// <param name="MaxBackup">最大备份数</param>
        /// <returns></returns>
        public async ValueTask BackupAsync(string TargetArchivePath, string BackupPath, int MaxBackup = 60)
        {
            //路径正常则执行备份
            if (Directory.Exists(TargetArchivePath) && Directory.Exists(BackupPath))
            {
                //备份
                var fs = Directory.GetFiles(BackupPath).ToList().Select(d => new FileInfo(d)).OrderBy(d => d.CreationTime).ToList();
                //删除最早的文件
                if (fs.Count >= MaxBackup)
                {
                    File.Delete(fs[0].FullName);
                }
                //WinRAR.exe a -r -ep1 -y -ibck "压缩包存放路径" "要被压缩的文件或者文件夹"
                //MessageBox.Show($"压缩包存放路径{BackupPath}/{Path.GetFileName(BackupPath)}_{DateTime.Now.ToString("MM-dd-HH-mm-ss")}.zip\r\n\r\n" +
                //    $"被备份文件夹路径:{TargetArchivePath}");
                await Tool.RunExternalProgramAsync(Form1.WinRAR_Path, $"a -r -ep1 -y -ibck \"{BackupPath}/{Path.GetFileName(BackupPath)}_{DateTime.Now.ToString("MM-dd-HH-mm-ss")}.zip\" \"{TargetArchivePath}\"");
                //await $"{ZipPath} a -r -ep1 -y -ibck \"{BackupPath}/{Path.GetFileName(BackupPath)}_{DateTime.Now.ToString("MM-dd-HH-mm-ss")}.zip\" \"{TargetArchivePath}\"".RunCMDAsync();
            }
        }

        /*
         SevenZipCompressor compressor = new SevenZipCompressor
        {
            ArchiveFormat = OutArchiveFormat.SevenZip, // 7z格式
            CompressionLevel = CompressionLevel.Ultra, // 最高压缩
            CompressionMethod = CompressionMethod.Lzma2 // 压缩算法
        };

         */

        /// <summary>
        /// 使用WinRAR压缩文件或文件夹,静默执行压缩
        /// </summary>
        /// <param name="WinRARFileInfo">WinRAR.exe的路径</param>
        /// <param name="targetPath">压缩好的文件存放路径</param>
        /// <param name="strings">被压缩的文件/夹路径集合</param>
        /// <returns></returns>
        public async ValueTask WinRARCompress(FileInfo WinRARFileInfo, string targetPath, List<string> strings)
        {
            SevenZipCompressor compressor = new SevenZipCompressor
            {
                ArchiveFormat = OutArchiveFormat.SevenZip, // 7z格式
                CompressionLevel = CompressionLevel.Ultra, // 最高压缩
                CompressionMethod = CompressionMethod.Lzma2 // 压缩算法
            };

            var str = "";
            strings.ForEach(d => str += $" \"{d}\"");
            var all = $"a -r -ep1 -y -ibck \"{targetPath}\"{str}";
            await Tool.RunExternalProgramAsync(WinRARFileInfo.FullName, all);
        }


        private void 添加ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var add = new BackupWindow(this);
            add.Show();
        }

        private void 删除选中ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Tool.WarningWindow(text: "确定要删除备份计划吗?"))
                return;
            listView2.DeleteSelectItems();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings1.Default.BackupListViewStr = listView2.ToStr();
            Settings1.Default.Save();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var RB = new ReferenceBook();
            RB.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var GS = new GameSettingWindow(this);
            GS.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var tip = $@"1.许多列表的功能都在右键菜单中.
2.游戏设置功能:双击你要修改的设置即可.
3.下载窗口:按住Alt+←或者→可以让页面前进或后退.
4.备份列表中打上勾的选项才会执行备份,否则不会执行备份
5.许多功能都在右键菜单中";
            var tips = new Tips(tip);
            tips.Show();
        }

        private async void 打包勾选ModToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Todie = new DirectoryInfo($"{textBox_GamePath.Text}/Mods");
            if (Todie.Exists)
            {
                var listViewItems = listView1.CheckedItems.Cast<ListViewItem>().ToList();
                //获取到勾选项对应的文件夹
                var directoryInfos = listViewItems.Select(d => GetDirectoryInfo(d, Todie)).ToList();
                var TMPModPath = $"{textBox_GamePath.Text}/Mods/Mods_{DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")}.rar";
                var mod = "";
                directoryInfos.ForEach(d => mod += $" \"{d}\"");

                var all = $"a -r -ep1 -y -ibck \"{TMPModPath}\"{mod}";
                await WinRARCompress(new FileInfo(WinRAR_Path), TMPModPath, directoryInfos.Select(d => d.FullName).ToList());
                //await Tool.RunExternalProgramAsync(WinRAR_Path, all);
                await Tool.RunExternalProgramAsync(WindowsBuiltInProgram.explorer.ToString(), new FileInfo(TMPModPath).Directory.FullName);
                var a = 1 + 2;
            }
        }

        public DirectoryInfo? GetDirectoryInfo(ListViewItem item, DirectoryInfo ToDie7_ModsPath)
            => ToDie7_ModsPath.GetDirectories($"{item.SubItems[0].Text}", new EnumerationOptions() { RecurseSubdirectories = true }).FirstOrDefault();

        private async void button7_Click(object sender, EventArgs e)
        {

        }
    }
}