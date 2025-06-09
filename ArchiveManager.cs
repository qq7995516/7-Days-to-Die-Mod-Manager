using System.Text;
using static 七日杀Mod管理器.Tool;
using System.Xml.Linq;

namespace 七日杀Mod管理器
{
    public partial class ArchiveManager : Form
    {        // 获取 Roaming AppData 文件夹路径
        DirectoryInfo SavesDirectoryPath = new DirectoryInfo(@$"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\7DaysToDie\Saves");
        public ArchiveManager()
        {
            InitializeComponent();
        }

        private async void ArchiveManager_Load(object sender, EventArgs e)
        {
            if (SavesDirectoryPath.Exists)
            {
                await RefreshPlayerListView();
            }
            listView1.ColumnClick += Tool.SortListView;
        }

        public async Task RefreshPlayerListView()
        {
            listView1.Items.Clear();
            //先获取所有存档的玩家数据
            var PlayerInfoPath = SavesDirectoryPath.GetFiles("players.xml", enumerationOptions: new EnumerationOptions { RecurseSubdirectories = true, }).ToList();
            //遍历
            foreach (var item in PlayerInfoPath)
            {
                //存档文件夹
                var SaveName = item.Directory;
                //地图文件夹
                var MapName = SaveName.Parent;
                //获取玩家数据
                var pleyers = await GePalyerInfoAsync(item.FullName);
                foreach (var item1 in pleyers)
                {
                    //创建单行
                    var listViewItem = new ListViewItem();
                    //地图
                    listViewItem.Text = MapName.Name;
                    //存档
                    listViewItem.SubItems.Add(SaveName.Name);
                    //玩家名
                    listViewItem.SubItems.Add(item1.info["playername"].ToString());
                    //UserID
                    listViewItem.SubItems.Add(item1.info["userid"].ToString());
                    //最后登录
                    listViewItem.SubItems.Add(item1.info["lastlogin"].ToString());
                    //完整数据
                    var kvs = new StringBuilder();
                    item1.info.ToList().ForEach(d =>
                    {
                        kvs.Append($@"{d.Key}={d.Value};");
                    });
                    listViewItem.SubItems.Add(kvs.ToString());
                    listView1.Items.Add(listViewItem);
                }
            }
        }

        private async void 删除勾选存档ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!WarningWindow(text:"确定要删除玩家存档吗?"))
                return;

            foreach (ListViewItem item in listView1.CheckedItems)
            {
                var MapName = item.SubItems[0].Text;
                var SaveName = item.SubItems[1].Text;
                var UserId = item.SubItems[3].Text;
                var PlayerDirectorySavePath = $"{SavesDirectoryPath}/{MapName}/{SaveName}/Player";
                var PlayerDir = new DirectoryInfo(PlayerDirectorySavePath);
                if (PlayerDir.Exists)
                {
                    //获取文件
                    var savefiles = PlayerDir.GetFiles($"*{UserId}.*").ToList();
                    foreach (var file in savefiles)
                    {
                        try
                        {
                            file.Delete();
                        }
                        catch (Exception)
                        {
                        }
                    }
                    //获取文件夹
                    var savedir = PlayerDir.GetDirectories($"*{UserId}").ToList();
                    foreach (var dir in savedir)
                    {
                        try
                        {
                            dir.Delete(true);
                        }
                        catch (Exception)
                        {
                        }
                    }
                    var tmpPath = $"{SavesDirectoryPath}/{MapName}/{SaveName}/players.xml";
                    //删除节点
                    XDocument? doc = XDocument.Load(tmpPath);
                    var players = doc.Descendants("player").ToList().Find(d => d.Attribute("userid").Value == UserId);
                    players.Remove();
                    doc.Save(tmpPath);
                }
            }
            //刷新
            await RefreshPlayerListView();
        }

        /// <summary>
        /// 通过ModInfo.xml文件获取mod信息
        /// </summary>
        /// <param name="PalyerInfoPath">ModInfo.xml的完整路径</param>
        /// <returns></returns>
        public async Task<List<PlaysInfo>?> GePalyerInfoAsync(string PalyerInfoPath)
        {
            return await Task.Run(() =>
            {
                if (File.Exists(PalyerInfoPath))
                {
                    var Players = new List<PlaysInfo>();

                    var doc = XDocument.Load($"{PalyerInfoPath}");
                    var players = doc.Descendants("player").ToList();
                    foreach (var item in players)
                    {
                        var p = new PlaysInfo();
                        //获取所有属性
                        var Attributes = item.Attributes().ToList();
                        //遍历全部属性
                        foreach (var item1 in Attributes)
                        {
                            var v = item1.Value;
                            p.info.Add(item1.Name.ToString(), item1.Value);
                        }
                        Players.Add(p);
                    }
                    return Players;
                }
                else
                {
                    return null;
                }
            });
        }
    }
}
