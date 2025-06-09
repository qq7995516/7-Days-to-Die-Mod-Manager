using Microsoft.Web.WebView2.Core;

namespace 七日杀Mod管理器
{
    public partial class DownloadWindow : Form
    {
        FileInfo DownLoadFilePath = default;
        DirectoryInfo TmpDir = new DirectoryInfo($"{AppDomain.CurrentDomain.BaseDirectory}TmpDir");

        public string? WebView2RunTimePath = @$"{Application.StartupPath}Microsoft.WebView2.FixedVersionRuntime.131.0.2903.99.x86";
        Form1 form1;
        public DownloadWindow(Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();
        }

        private async void DownloadWindow_Load(object sender, EventArgs e)
        {
            //安装程序
            //https://go.microsoft.com/fwlink/p/?LinkId=2124703
            //判断是否需要安装运行时
            if (!Tool.IsInstalled())
                await Tool.DownloadAndInstallAsync();

            await webView2.EnsureCoreWebView2Async();//初始化核心
            webView2.CoreWebView2.Navigate("https://www.7risha.com/");
            //注册下载开始事件
            webView2.CoreWebView2.DownloadStarting += (s, e) =>
            {
                //取消下载
                //e.Cancel = true;
                //获取下载文件完整路径    包括原始文件名
                DownLoadFilePath = new FileInfo(e.ResultFilePath);

                //设置到指定文件保存路径
                //e.ResultFilePath = "";

                //下载链接
                //var Fileurl = e.DownloadOperation.Uri;

                //注册下载状态变化事件
                e.DownloadOperation.StateChanged += async (o, ea) =>
                {
                    var download = (CoreWebView2DownloadOperation)o;
                    //如果下载完成
                    if (download.State == CoreWebView2DownloadState.Completed)
                    {
                        //MessageBox.Show($"下载完成:{e.ResultFilePath}\r\n" +
                        //    $"{e.DownloadOperation.ResultFilePath}");
                        //临时文件夹存放mod
                        //var TmpFolderPath = TmpDir.GetOrCreateDirectory();
                        ////解压到指定路径
                        //await Tool.RunExternalProgramAsync(Form1.WinRAR_Path, $"X {DownLoadFilePath} {TmpFolderPath}");
                        ////await $"{Form1.WinRAR_Path} e {DownLoadFilePath} {TmpFolderPath}".RunCMDAsync();
                        //var modInfo = await $"{TmpFolderPath}/ModInfo.xml".GetModInfoAsync();
                        //TmpFolderPath.FolderRename(modInfo.Name);

                        //以压缩文件名创建一个文件夹
                        var TmpDir = Directory.CreateDirectory(Path.GetFileNameWithoutExtension(DownLoadFilePath.Name));
                        //解压到临时文件夹里
                        var ret = await Tool.RunExternalProgramAsync(Form1.WinRAR_Path, $"x {DownLoadFilePath.FullName} {TmpDir.FullName}");
                        await TmpDir.ModProcessing($"{form1.textBox1.Text}/Mods");

                    }
                };
            };

            //注册新窗口打开事件
            webView2.CoreWebView2.NewWindowRequested += (s, e) =>
                {
                    // 阻止默认的新窗口打开行为，并在当前窗口导航到新链接
                    e.Handled = true;
                    webView2.CoreWebView2.Navigate(e.Uri);
                };
        }
    }
}
