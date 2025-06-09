using Microsoft.Win32;
using System.Collections;
using System.Diagnostics;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace 七日杀Mod管理器
{
    public static class Tool
    {
        /// <summary>
        /// 下载 WebView2 运行时安装程序
        /// </summary>
        /// <param name="downloadPath">下载保存路径</param>
        /// <param name="WEBVIEW2_INSTALLER_URL">WebView2 运行时在线安装程序官方下载地址</param>
        /// <returns>下载的文件路径</returns>
        public static async Task<string> DownloadInstallerAsync(string downloadPath = null, string WEBVIEW2_INSTALLER_URL = "https://go.microsoft.com/fwlink/p/?LinkId=2124703")
        {
            //MicrosoftEdgeWebview2Setup.exe
            // 如果未指定下载路径，使用临时文件
            if (string.IsNullOrEmpty(downloadPath))
                downloadPath = Path.Combine(Path.GetTempPath(), "MicrosoftEdgeWebview2Setup.exe");
            if (File.Exists(downloadPath))
                return downloadPath;
            using var httpClient = new HttpClient();
            try
            {
                // 下载文件
                byte[] fileBytes = await httpClient.GetByteArrayAsync(WEBVIEW2_INSTALLER_URL);
                // 保存文件
                await File.WriteAllBytesAsync(downloadPath, fileBytes);
                return downloadPath;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 静默安装 WebView2 运行时
        /// </summary>
        /// <param name="installerPath">安装程序路径</param>
        /// <returns>是否安装成功</returns>
        public static bool SilentInstall(string installerPath)
        {
            var installer = new FileInfo(installerPath);
            try
            {
                // 检查文件是否存在
                if (!installer.Exists)
                    return false;
                // 创建进程启动信息
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = installerPath,
                    Arguments = "/silent /install", // 静默安装参数
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    Verb = "runas" // 以管理员权限运行
                };

                // 启动进程并等待完成
                using var process = Process.Start(startInfo);
                process.WaitForExit();
                // 检查安装是否成功（进程退出码）
                return process.ExitCode == 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 一键下载并安装 WebView2 运行时
        /// </summary>
        /// <param name="IsDeleteInstallerFile">是否删除安装程序</param>
        /// <returns>是否安装成功</returns>
        public static async Task<bool> DownloadAndInstallAsync(bool IsDeleteInstallerFile = false)
        {
            // 下载安装程序
            string installerPath = await DownloadInstallerAsync();

            if (string.IsNullOrEmpty(installerPath))
                return false;
            // 执行静默安装
            bool installResult = SilentInstall(installerPath);
            // 可选：删除临时下载的安装程序
            try
            {
                if (IsDeleteInstallerFile)
                    File.Delete(installerPath);
            }
            catch
            {
                // 忽略删除失败的错误
            }
            return installResult;
        }

        private const string WEBVIEW2_CLIENT_GUID = "{F3017226-FE2A-4295-8BDF-00C3A9A7E4C5}";
        /// <summary>
        /// 检查是否已安装 WebView2 运行时
        /// </summary>
        /// <returns>是否已安装</returns>
        public static bool IsInstalled()
        {
            return TryGetInstalledVersion(out _);
        }

        /// <summary>
        /// 尝试获取 WebView2 运行时版本
        /// </summary>
        /// <param name="version">输出参数：版本号</param>
        /// <returns>是否成功获取版本</returns>
        private static bool TryGetInstalledVersion(out string version)
        {
            version = null;
            string[] registryPaths = Environment.Is64BitOperatingSystem
                ? new[]
                {
                $@"SOFTWARE\WOW6432Node\Microsoft\EdgeUpdate\Clients\{WEBVIEW2_CLIENT_GUID}",
                $@"Software\Microsoft\EdgeUpdate\Clients\{WEBVIEW2_CLIENT_GUID}"
                }
                : new[]
                {
                $@"SOFTWARE\Microsoft\EdgeUpdate\Clients\{WEBVIEW2_CLIENT_GUID}",
                $@"Software\Microsoft\EdgeUpdate\Clients\{WEBVIEW2_CLIENT_GUID}"
                };

            RegistryKey[] baseKeys = { Registry.LocalMachine, Registry.CurrentUser };

            foreach (var baseKey in baseKeys)
            {
                foreach (var path in registryPaths)
                {
                    try
                    {
                        using var key = baseKey.OpenSubKey(path);
                        if (key != null)
                        {
                            string pvValue = key.GetValue("pv") as string;

                            if (!string.IsNullOrWhiteSpace(pvValue) &&
                                Version.TryParse(pvValue, out Version runtimeVersion) &&
                                runtimeVersion > new Version(0, 0, 0, 0))
                            {
                                version = pvValue;
                                return true;
                            }
                        }
                    }
                    catch
                    {
                        // 忽略异常
                    }
                }
            }
            return false;
        }


        /// <summary>
        /// 处理解压好的mod
        /// </summary>
        /// <param name="DirInfo">把临时存放mod的文件夹路径信息传进来</param>
        /// <param name="TargetModsPath">游戏的mods文件夹</param>
        public static async Task ModProcessing(this DirectoryInfo DirInfo, string TargetModsPath)
        {
            await ProcessDirectory(DirInfo, TargetModsPath);
            /*var files = DirInfo.GetFiles();
            //是否存在modinfo,存在则是合法mod
            var LegalMod = ExistsModInfo(DirInfo, "ModInfo.xml");
            if (LegalMod)
            {
                var SingleMod = DirInfo.GetFiles().Any(d => d.Name.Equals("ModInfo.xml", StringComparison.OrdinalIgnoreCase));
                //当临时文件夹存在modinfo    说明没有用文件夹装着
                if (SingleMod)
                {
                    //从ModInfo文件里获取mod名称
                    var Modinfo = await GetModInfoAsync($"{DirInfo.Name}/ModInfo.xml");
                    //直接把临时文件夹改名为mod名称,也就是移动文件夹
                    DirInfo.MoveTo($@"{TargetModsPath}/{Modinfo.Name}");
                    //直接解压到文件夹内
                    //await $"{Form1.WinRAR_Path} e {dir.Name} {TmpFolderPath}".RunCMDAsync();
                }
                //如果没有modinfo文件
                else
                {
                    //获取文件夹
                    var dirs = DirInfo.GetDirectories().ToList();
                    dirs.ForEach(d =>
                    {
                        //判断内部是否有Modinfo
                        var t = d.GetFiles().ToList().Any(f => f.Name.Contains("ModInfo.xml"));
                        if (t)
                            //如果有则直接移动文件夹到Mods下面
                            d.MoveTo(TargetModsPath);
                        else
                            MessageBox.Show($"无法识别该Mod结构:\r\n" +
                                $"{d.Name}\r\n" +
                                $"请手动检查\r\n");
                    });
                }
            }
            else
            {

                MessageBox.Show("该mod文件结构有问题,请检查");
            }*/

        }

        /// <summary>
        /// 对文件夹递归检查是否存在指定文件
        /// </summary>
        /// <param name="DirInfo">文件夹路径</param>
        /// <param name="Name">指定文件名</param>
        /// <returns></returns>
        public static bool ExistsModInfo(this DirectoryInfo DirInfo, string Name)
        {
            // 先检查当前目录是否有ModInfo.xml
            bool currentDirHasModInfo = DirInfo.GetFiles().Any(f =>
                f.Name.Equals("ModInfo.xml", StringComparison.OrdinalIgnoreCase));

            // 检查子目录
            bool childDirHasModInfo = DirInfo.GetDirectories()
                .Any(subDir => ExistsModInfo(subDir, Name));
            return currentDirHasModInfo || childDirHasModInfo;
        }


        /// <summary>
        /// 处理文件夹内的mod
        /// </summary>
        /// <param name="DirInfo">解压后的文件夹</param>
        /// <param name="TargetModsPath">Mods文件夹的路径</param>
        /// <returns></returns>
        private static async Task ProcessDirectory(DirectoryInfo DirInfo, string TargetModsPath)
        {

            // 检查是否存在压缩文件
            var exts = new List<string>() { ".rar", ".7z" };
            var zips = exts.SelectMany(d => DirInfo.GetFiles(d, enumerationOptions: new EnumerationOptions
            {
                // 是否遍历子目录
                RecurseSubdirectories = true,
                // 匹配模式
                MatchType = MatchType.Simple,
                // 跳过无权限访问的目录
                IgnoreInaccessible = true
            })).ToList();
            foreach (var fi in zips)
            {
                //以压缩文件名创建新文件夹
                var ModDir = DirInfo.CreateSubdirectory(fi.Name);
                //解压到刚创建的文件夹
                await RunExternalProgramAsync($"WinRAR.exe", $"x {fi.FullName} {ModDir.FullName}");
                if (File.Exists($"{ModDir.FullName}/ModInfo.xml"))
                {
                    //获取mod名称
                    var modinfo = await $"{ModDir.FullName}/ModInfo.xml".GetModInfoAsync();
                    ModDir.FolderRename(modinfo.Name);
                }
            }

            // 获取ModInfo.xml
            var ModInfos = DirInfo.GetFiles("ModInfo.xml", enumerationOptions: new EnumerationOptions { RecurseSubdirectories = true, }).ToList();
            foreach (var FI in ModInfos)
            {
                var Minfo = await FI.FullName.GetModInfoAsync();
                //获取所有modinfo所在的文件夹,然后移进游戏的Mods文件夹
                var modpath = $"{TargetModsPath}/{FI.Directory.Name}";
                //MessageBox.Show($"{FI.Exists}");
                if (!Directory.Exists(modpath))
                    FI.Directory.DirectoryCopy(modpath);
                //FI.Directory.Delete(recursive: true);
            }
            //判断是否有其他文件
            var files = DirInfo.GetFiles("*", new EnumerationOptions() { RecurseSubdirectories = true }).ToList();
            //找出与Data文件夹中名称相同的文件
            var fs = files.Where(d => Form1.DataFileInfos.Any(a => a.Name == d.Name)).ToList();
            fs.ForEach(d =>
            {
                //找到文件夹名称相同的原文件
                var fi = Form1.DataFileInfos.Find(f => f.Directory.Name == d.Directory.Name);
                //获取原文件的文件夹路径
                var f1 = fi.Directory.FullName;
                //删除原文件
                fi.Delete();
                //把解压出来的文件复制过去
                d.CopyTo($"{f1}/{d.Name}");
            });
            var c = 1 + 1;
        }

        /// <summary>
        /// 移动文件夹内容,会覆盖原本存在的文件和文件夹
        /// </summary>
        /// <param name="sourceDirPath">待移动文件夹</param>
        /// <param name="destinationFolder">目标文件夹</param>
        public static void MoveContentsTo(this string sourceDirPath, string destinationFolder)
        {
            DirectoryInfo sourceDir = new DirectoryInfo(sourceDirPath);
            // 检查目标文件夹是否存在
            if (!Directory.Exists(destinationFolder))
            {
                Directory.CreateDirectory(destinationFolder);
            }

            // 移动文件
            foreach (FileInfo file in sourceDir.GetFiles())
            {
                if (File.Exists(Path.Combine(destinationFolder, file.Name)))
                {
                    File.Delete(Path.Combine(destinationFolder, file.Name));
                }
                file.MoveTo(Path.Combine(destinationFolder, file.Name));
            }

            // 移动子文件夹
            foreach (DirectoryInfo dir in sourceDir.GetDirectories())
            {
                if (Directory.Exists(Path.Combine(destinationFolder, dir.Name)))
                {
                    Directory.Delete(Path.Combine(destinationFolder, dir.Name));
                }
                dir.MoveTo(Path.Combine(destinationFolder, dir.Name));
            }
        }

        /// <summary>
        /// mod信息
        /// </summary>
        public class ModInfo
        {
            /// <summary>
            /// 名称
            /// </summary>
            public string Name;
            /// <summary>
            /// 简介
            /// </summary>
            public string Description;
            /// <summary>
            /// 版本
            /// </summary>
            public string Version;
            /// <summary>
            /// 作者
            /// </summary>
            public string Author;
        }

        /// <summary>
        /// 通过ModInfo.xml文件获取mod信息
        /// </summary>
        /// <param name="ModInfoPath">ModInfo.xml的完整路径</param>
        /// <returns></returns>
        public static async Task<ModInfo?> GetModInfoAsync(this string ModInfoPath)
        {
            return await Task.Run(() =>
             {
                 if (File.Exists(ModInfoPath))
                 {

                     var doc = XDocument.Load($"{ModInfoPath}");
                     //mod名称
                     var ModName = doc.Descendants("Name").First().Attribute("value")?.Value;
                     //简介
                     var ModDescription = doc.Descendants("Description").First().Attribute("value")?.Value;
                     //版本
                     var ModVersion = doc.Descendants("Version").First().Attribute("value")?.Value;
                     //作者
                     var ModAuthor = doc.Descendants("Author").First().Attribute("value")?.Value;

                     return new ModInfo() { Name = ModName, Description = ModDescription, Version = ModVersion, Author = ModAuthor };
                 }
                 else
                 {
                     return null;
                 }
             });
        }

        public class PlaysInfo
        {
            /// <summary>
            /// 玩家信息
            /// </summary>
            public Dictionary<string, string> info = new Dictionary<string, string>();
        }



        /// <summary>
        /// 让文件夹重命名
        /// </summary>
        /// <param name="directoryInfo">文件夹</param>
        /// <param name="NewName">新名称</param>
        /// <returns>返回改名后的文件夹</returns>
        /// <exception cref="Exception"></exception>
        public static DirectoryInfo FolderRename(this DirectoryInfo directoryInfo, string NewName)
        {
            var path = $"{directoryInfo.Parent.FullName}/{NewName}";
            if (!Directory.Exists(path))
            {
                directoryInfo.MoveTo(path);
                return new DirectoryInfo(path);
            }
            else
            {
                throw new Exception($"{path}\r\n\r\n目标文件夹已存在,请检查!");
            }
        }

        /// <summary>
        /// 递归复制目录
        /// </summary>
        /// <param name="sourceDirName">原文件夹</param>
        /// <param name="destDirName">新路径</param>
        /// <param name="copySubDirs">是否递归复制</param>
        /// <exception cref="DirectoryNotFoundException"></exception>
        private static void DirectoryCopy(this DirectoryInfo sourceDirName, string destDirName, bool copySubDirs = true)
        {
            // 如果目标目录不存在，则创建它
            //DirectoryInfo sourceDirName1 = new DirectoryInfo(sourceDirName);
            if (!sourceDirName.Exists)
            {
                throw new DirectoryNotFoundException($"Source directory does not exist or could not be found: {sourceDirName.Name}");
            }

            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // 复制文件
            FileInfo[] files = sourceDirName.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // 如果需要复制子目录，则递归处理子目录
            if (copySubDirs)
            {
                DirectoryInfo[] subdirs = sourceDirName.GetDirectories();
                foreach (DirectoryInfo subdir in subdirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir, temppath, copySubDirs);
                }
            }
        }

        /// <summary>
        /// 实现按列对项目进行手动排序。
        /// </summary>
        class ListViewItemComparer : IComparer
        {
            private int col;
            public ListViewItemComparer()
            {
                col = 0;
            }
            public ListViewItemComparer(int column)
            {
                col = column;
            }
            public int Compare(object x, object y)
            {
                return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
            }
        }
        /// <summary>
        /// 对ListView排序
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="e"></param>
        /// <param name="sortAscending"></param>
        public static void SortListView(this object listView, ColumnClickEventArgs e) => (listView as ListView).ListViewItemSorter = new ListViewItemComparer(e.Column);


        /// <summary>
        /// 刷新mod列表
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="GamePath">mod文件夹路径</param>
        public static async void RefreshModListView(this ListView listView, string GamePath)
        {
            var ModsPath = $"{GamePath}/Mods";
            //不存在就创建
            if (Directory.Exists(ModsPath) == false)
                Directory.CreateDirectory(ModsPath);
            listView.Items.Clear();
            var mods = Directory.GetDirectories(ModsPath).ToList();
            foreach (var item in mods)
            {
                var ModFolderName = Path.GetFileName(item);
                var it = new ListViewItem();
                it.Text = ModFolderName;
                var Modinfo = await GetModInfoAsync($"{item}/ModInfo.xml");
                if (Modinfo != null)
                {
                    //mod名称
                    it.SubItems.Add(Modinfo.Name);
                    //简介
                    it.SubItems.Add(Modinfo.Description);
                    //版本
                    it.SubItems.Add(Modinfo.Version);
                    //作者
                    it.SubItems.Add(Modinfo.Author);
                    //安装情况
                    it.SubItems.Add("正确");
                }
                else
                {
                    //mod名称
                    it.SubItems.Add("");
                    //简介
                    it.SubItems.Add("");
                    //版本
                    it.SubItems.Add("");
                    //作者
                    it.SubItems.Add("");
                    //安装情况
                    it.SubItems.Add("错误");
                }
                listView.Items.Add(it);
            }
        }

        /// <summary>
        /// 选择文件对话框,自带检查路径是否正常/*  */
        /// </summary>
        /// <param name="Title">对话框标题</param>
        /// <param name="Multiselect">是否允许多选</param>
        /// <param name="InitialDirectory">初始目录</param>
        /// <param name="Filter">文本文件(*.txt)|*.txt|图像文件(*.jpg;*.png)|*.jpg;*.png</param>
        /// <param name="ValidateNames">只允许win32文件名</param>
        /// <returns>返回list<string></returns>
        public static List<string> OpenFileDialog(
            string Title = "请选择文件",
            bool Multiselect = false,
            string InitialDirectory = "./",
            string Filter = "文本文件(*.txt)|*.txt|图像文件(*.jpg;*.png)|*.jpg;*.png",
            bool ValidateNames = true
        ) //文件对话框,参数
        {
            //创建对话框对象
            OpenFileDialog ofd = new OpenFileDialog(); //文件对话框对象
            ofd.Title = Title; //设置窗口标题
            ofd.Multiselect = Multiselect; //设置允许多选文件.
            ofd.InitialDirectory = InitialDirectory; //设置对话框的初始目录
            ofd.Filter = Filter; //设置允许显示的后缀名.
            ofd.AutoUpgradeEnabled = true; //UI自适应
            ofd.ValidateNames = ValidateNames; //只允许win32文件名
            var dialogResult = ofd.ShowDialog(); //绘制对话框
            if (dialogResult == DialogResult.OK)
            {
                List<string> list = new List<string>();
                if (ofd.Multiselect)
                {
                    foreach (var item in ofd.FileNames)
                    {
                        if (File.Exists(item)) //判断文件是否存在                        
                            list.Add(ofd.FileName);
                    }
                    return list;
                }
                else
                    if (File.Exists(ofd.FileName))                  //获取单个文件的绝对路径
                {
                    list.Add(ofd.FileName);
                    return list;
                }
            }
            return null;
        }

        public static bool WarningWindow(string text = "确定吗?", string caption = "警告!") =>
             MessageBox.Show(text: text, caption: caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;



        /// <summary>
        /// 选择一个文件夹路径
        /// </summary>
        /// <param name="show_new_folder_button">是否显示新建文件夹按钮</param>
        /// <param name="default_path">默认打开路径</param>
        /// <returns>返回选择的路径,如果选择了不存在的路径则返回null</returns>
        public static string? SelectFolder(string default_path, bool show_new_folder_button = true)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "选择文件夹"; //提示的文字
            folder.ShowNewFolderButton = show_new_folder_button;
            folder.SelectedPath = default_path;
            if (folder.ShowDialog() == DialogResult.OK)
                return Directory.Exists(folder.SelectedPath) ? folder.SelectedPath : null;
            else
                return null;
        }

        /// <summary>
        /// 删除勾选项
        /// </summary>
        /// <param name="listView"></param>
        public static void DeleteTickItems(this System.Windows.Forms.ListView listView)
        {
            int i = 0;
            while (listView.CheckedItems.Count != 0)
            {
                if (listView.Items[i].Checked)
                    listView.Items.Remove(listView.Items[i]);
                i++;
                if (i >= listView.Items.Count)
                    i = 0;
            }
        }

        /// <summary>
        /// 删除选中项
        /// </summary>
        /// <param name="listView"></param>
        public static void DeleteSelectItems(this ListView listView)
        {
            int i = 0;
            while (listView.SelectedItems.Count != 0)
            {
                if (listView.Items[i].Selected)
                {
                    listView.Items.Remove(listView.Items[i]);
                    i++;
                    if (i == listView.Items.Count)
                        i = 0;
                }
            }
        }

        /// <summary>
        /// 解析字符串并加入listview
        /// </summary>
        /// <param name="listview">被添加的listview控件</param>
        /// <param name="str">要被加进去的字符串</param>
        /// <param name="Linec">行切割符</param>
        /// <param name="c">行内切割符</param>
        /// <returns>添加成功则返回true,失败返回false</returns>
        public static bool ToListView(
            this string str,
            ListView listview,
            char Linec = ';',
            char c = '|'
        )
        {
            if (str != "")
            {
                var arry = str.Split(Linec); //0-str-str-str-str //字符串的格式
                if (arry.Length > 0)
                {
                    var list = arry.ToList().Distinct().ToList(); //去重
                    list.RemoveAll((d) => d == ""); //去除空元素
                    for (int i = 0; i < list.Count; i++)
                    {
                        var listcount = list[i].Split(c).ToList(); //数组的格式{"1","str","str","str",...}
                        listcount.RemoveAll((d) => d == "");
                        if (listcount.Count > 1)
                        {
                            ListViewItem item = new ListViewItem();
                            item.Checked = listcount[0] == "1" ? true : false;
                            item.Text = listcount[1]; //必须在循环外加第一个
                            for (int o = 0; o < listcount.Count; o++) //必须从第二个开始
                            {
                                if (o > 1)
                                    item.SubItems.Add(listcount[o]); //后续慢慢加                                
                            }
                            listview.Items.Add(item);
                        }
                        else
                            continue;
                    }
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        /// <summary>
        /// 把listview控件中的内容解析为字符串,这个字符串可以直接再解析回listview
        /// </summary>
        /// <param name="listview"></param>
        /// <param name="linec"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string ToStr(this ListView listview, char linec = ';', char c = '|')
        {
            var str = "";
            if (listview.Items.Count > 0)
            {
                for (int i = 0; i < listview.Items.Count; i++)
                {
                    str += $"{(listview.Items[i].Checked == true ? "1" : "0")}{c}";
                    for (int o = 0; o < listview.Items[i].SubItems.Count; o++)
                    {
                        var new_c = o == (listview.Items[i].SubItems.Count - 1) ? "" : c + "";
                        str += $@"{listview.Items[i].SubItems[o].Text}{new_c}";
                    }
                    str += $"{linec}";
                }
            }
            return str;
        }


        /// <summary>
        /// 执行CMD指令
        /// </summary>
        /// <param name="str">具体CMD指令</param>
        /// <param name="CreateNoWindow">是否无窗口执行</param>
        /// <param name="UseShellExecute">是否使用Shell启动进程</param>
        /// <param name="Wait">是否等待执行结果</param>
        /// <returns>如果等待结果,则返回执行结果,不等待则返回null</returns>
        public static async Task<string> RunCMDAsync(
            this string str,
            bool CreateNoWindow = true,
            bool UseShellExecute = false,
            bool Wait = false
        )
        {
            var Path = @"CMD.exe";
            using var cmd = new Process();
            cmd.StartInfo.CreateNoWindow = CreateNoWindow; // 不创建新窗口
            cmd.StartInfo.UseShellExecute = UseShellExecute;//是否shell启动进程
            cmd.StartInfo.RedirectStandardInput = true;// 让执行的程序从流中读取内容
            cmd.StartInfo.RedirectStandardOutput = true;// 让执行的程序向流中输出内容
            cmd.StartInfo.RedirectStandardError = true;// 让执行的程序向流中输出错误异常
            cmd.StartInfo.FileName = Path;
            cmd.StartInfo.Arguments = $"/c {str}";
            cmd.Start();
            var result = await cmd.StandardOutput.ReadToEndAsync();
            await cmd.WaitForExitAsync();
            return result;
        }


        public static async Task<string> RunCMDAsync1(
            this string str,
            bool CreateNoWindow = true,
            bool UseShellExecute = false,
            bool Wait = false
        )
        {
            using var cmd = new Process();
            cmd.StartInfo.CreateNoWindow = CreateNoWindow;
            cmd.StartInfo.UseShellExecute = UseShellExecute;
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.RedirectStandardError = true;
            cmd.StartInfo.FileName = "CMD.exe";
            cmd.StartInfo.Arguments = $"/c {str}";

            cmd.Start();

            // 读取输出和错误流
            string output = await cmd.StandardOutput.ReadToEndAsync();
            string error = await cmd.StandardError.ReadToEndAsync();

            // 确保进程完全结束
            await cmd.WaitForExitAsync();

            // 检查是否有错误
            if (!string.IsNullOrEmpty(error))
            {
                throw new Exception($"Command execution error: {error}");
            }
            return output;
        }

        public enum WindowsBuiltInProgram
        {
            /// <summary>记事本</summary>
            notepad,

            /// <summary>画图</summary>
            mspaint,

            /// <summary>画图3D</summary>
            PaintApp,

            /// <summary>屏幕截图工具</summary>
            ScreenSketch,

            /// <summary>计算器</summary>
            calc,

            /// <summary>命令提示符</summary>
            cmd,

            /// <summary>PowerShell</summary>
            powershell,

            /// <summary>任务管理器</summary>
            Taskmgr,

            /// <summary>注册表编辑器</summary>
            regedit,

            /// <summary>系统配置实用工具</summary>
            msconfig,

            /// <summary>资源监视器</summary>
            resmon,

            /// <summary>磁盘清理</summary>
            cleanmgr,

            /// <summary>系统信息</summary>
            msinfo32,

            /// <summary>性能监视器</summary>
            perfmon,

            /// <summary>远程桌面连接</summary>
            mstsc,

            /// <summary>文件资源管理器</summary>
            explorer
        }

        /// <summary>
        /// 执行外部程序并返回执行结果
        /// </summary>
        /// <param name="fileName">程序完整路径</param>
        /// <param name="arguments">程序启动参数</param>
        /// <param name="workingDirectory">工作目录</param>
        /// <param name="timeoutMilliseconds">超时时间(毫秒)</param>
        /// <returns>执行结果</returns>
        public static async Task<ProcessResult> RunExternalProgramAsync(
            string fileName,
            string arguments = "",
            string workingDirectory = null,
            int timeoutMilliseconds = 10 * 60 * 1000)
        {
            var result = new ProcessResult();

            using (var process = new Process())
            {
                process.StartInfo.FileName = fileName;
                process.StartInfo.Arguments = arguments;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;

                // 设置工作目录
                if (!string.IsNullOrEmpty(workingDirectory))
                {
                    process.StartInfo.WorkingDirectory = workingDirectory;
                }

                var outputBuilder = new StringBuilder();
                var errorBuilder = new StringBuilder();

                process.OutputDataReceived += (sender, e) =>
                {
                    if (e.Data != null)
                    {
                        outputBuilder.AppendLine(e.Data);
                    }
                };

                process.ErrorDataReceived += (sender, e) =>
                {
                    if (e.Data != null)
                    {
                        errorBuilder.AppendLine(e.Data);
                    }
                };

                try
                {
                    process.Start();
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();

                    // 使用Task.WhenAny实现超时   等待指定进程运行结束
                    var processTask = process.WaitForExitAsync();
                    var timeoutTask = Task.Delay(timeoutMilliseconds);
                    var completedTask = await Task.WhenAny(processTask, timeoutTask);
                    //超时就强制关闭
                    if (completedTask == timeoutTask)
                    {
                        process.Kill();
                        result.IsTimeout = true;
                        result.ExitCode = -1;
                        return result;
                    }

                    result.ExitCode = process.ExitCode;
                    result.Output = outputBuilder.ToString().Trim();
                    result.Error = errorBuilder.ToString().Trim();
                    result.IsSuccess = process.ExitCode == 0;
                }
                catch (Exception ex)
                {
                    result.IsSuccess = false;
                    result.Error = ex.Message;
                }
                return result;
            }
        }

        /// <summary>
        /// 进程执行结果
        /// </summary>
        public class ProcessResult
        {
            /// <summary>
            /// 是否执行成功
            /// </summary>
            public bool IsSuccess { get; set; }

            /// <summary>
            /// 是否超时
            /// </summary>
            public bool IsTimeout { get; set; }

            /// <summary>
            /// 退出代码
            /// </summary>
            public int ExitCode { get; set; }

            /// <summary>
            /// 输出内容
            /// </summary>
            public string Output { get; set; }

            /// <summary>
            /// 错误信息
            /// </summary>
            public string Error { get; set; }
        }

        // 使用示例
        public static async Task TestRunProgram()
        {
            // 直接运行程序
            var result1 = await RunExternalProgramAsync("notepad.exe");

            // 运行程序并传入参数
            var result2 = await RunExternalProgramAsync(
                "ping.exe",
                "www.baidu.com",
                timeoutMilliseconds: 5000
            );

            // 检查执行结果
            if (result2.IsSuccess)
            {
                Console.WriteLine(result2.Output);
            }
            else
            {
                Console.WriteLine($"Error: {result2.Error}");
            }
        }
        /// <summary>
        /// 获取或创建文件夹
        /// </summary>
        /// <param name="directoryInfo"></param>
        /// <returns></returns>
        public static DirectoryInfo GetOrCreateDirectory(this DirectoryInfo directoryInfo)
        {
            if (!directoryInfo.Exists)
                directoryInfo.Create();
            return directoryInfo;
        }

        #region Socket

        /// <summary>
        /// 创建1个Tcp socket
        /// </summary>
        /// <param name="ip">要绑定的Ip,传空字符串则使用默认ip</param>
        /// <param name="port">要绑定的端口</param>
        /// <param name="listen">监听队列长度，表示等待连接的最大数量</param>
        /// <returns>返回配置好的Socket对象</returns>
        public static Socket CreateSocketTCP(string ip, int port, int listen = 30)
        {
            //创建一个socket对象,用于监听
            var socket = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp
            );

            IPAddress ipAddress;
            if (ip == string.Empty || ip == null)
            {
                ipAddress = IPAddress.Any;
            }
            else
            {
                if (!IPAddress.TryParse(ip, out ipAddress))
                {
                    throw new ArgumentException("提供的IP地址格式无效", nameof(ip));
                }
            }
            var endPoint = new IPEndPoint(ipAddress, port);
            try
            {
                //绑定网络信息
                socket.Bind(endPoint);
                //设置监听队列长度
                socket.Listen(listen);
                return socket;
            }
            catch (SocketException ex)
            {
                throw new InvalidOperationException($"创建TCP Socket失败: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// 监听连接函数，并用Task处理新连接
        /// </summary>
        /// <param name="socket">用于监听连接的socket</param>
        /// <param name="action">如何处理新连接</param>
        public static async Task MonitorAsync(
            this Socket socket,
           Func<Socket, Task> action
        )
        {
            await Task.Run(async () =>
             {
                 while (true)
                 {
                     try
                     {
                         //开始监听,有连接则创建socket去处理,如果没有则会一直阻塞.
                         var ReciveSocket = await socket.AcceptAsync();
                         //处理连接
                         await action(ReciveSocket);
                     }
                     catch (Exception e)
                     {
                         MessageBox.Show(e.Message);
                         throw;
                     }
                 }
             });
        }

        #endregion


    }
}