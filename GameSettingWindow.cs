using Newtonsoft.Json;
using System.Xml.Linq;

namespace 七日杀Mod管理器
{
    public partial class GameSettingWindow : Form
    {
        FileInfo GameSettingPath = new FileInfo("GameSetting.json");
        FileInfo ServerConfig = default;
        Form1 Form;
        public GameSettingWindow(Form1 form1)
        {
            Form = form1;
            InitializeComponent();
        }

        private async void GameSettingWindow_Load(object sender, EventArgs e)
        {
            ServerConfig = new FileInfo($"{Form.textBox1.Text}/serverconfig.xml");
            listView1.ColumnClick += Tool.SortListView;
            RefreshGameSetting();
        }
        public void RefreshGameSetting()
        {
            var json = GameSettingPath.OpenText().ReadToEnd();
            var settings = JsonConvert.DeserializeObject<List<Setting>>(json);
            if (!ServerConfig.Exists)
                return;
            listView1.Items.Clear();
            var XmlDoc = XDocument.Load(ServerConfig.FullName);
            var Es = GetAllXmlNodes(XmlDoc);
            foreach (var element in Es)
            {
                var item = new ListViewItem();
                var Attributes = element.Attributes().ToList();
                item.Text = Attributes[0].Value;
                item.SubItems.Add(Attributes[1].Value);
                var Synopsis = settings.Find(d => d.Name == item.Text).Synopsis;
                item.SubItems.Add(Synopsis);
                listView1.Items.Add(item);
            }
        }

        public List<XElement>? GetAllXmlNodes(XDocument xmlDoc) => xmlDoc.Descendants("property").ToList();


        public class Setting
        {
            public string Name { get; set; }
            public string Synopsis { get; set; }
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            var listView = sender as ListView;
            var item = listView.SelectedItems[0];
            var Modify = new ModifySetting(this, ServerConfig, item);
            Modify.ShowDialog();
        }

        private void 刷新列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshGameSetting();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                RefreshGameSetting();
                return;
            }
            //var ttt = listView1.Items[0];
            var tttt = listView1.Items.Cast<ListViewItem>().ToList();
            var lists = tttt.Where(d => d.SubItems[2].Text.Contains(textBox1.Text)).ToList();
            if (lists.Count != 0)
            {
                listView1.Items.Clear();
                lists.ForEach(d => listView1.Items.Add(d));
            }
        }
    }
}