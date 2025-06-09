using System.Xml.Linq;

namespace 七日杀Mod管理器
{
    public partial class ModifySetting : Form
    {
        GameSettingWindow form;
        FileInfo ServerConfig;
        ListViewItem ListViewItem;
        public ModifySetting(GameSettingWindow form1, FileInfo serverconfig, ListViewItem listviewitem)
        {
            InitializeComponent();
            this.form = form1;
            this.ServerConfig = serverconfig;
            this.ListViewItem = listviewitem;
        }

        private void ModifySetting_Load(object sender, EventArgs e)
        {
            Text = ListViewItem.Text;
            textBox1.Text = ListViewItem.SubItems[1].Text;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            var xmldoc = XDocument.Load(ServerConfig.FullName);
            var elements = form.GetAllXmlNodes(xmldoc);
            var es = elements.Find(d => d.Attributes().Any(a => a.Value == Text));
            if (es != null)
            {
                es.Attribute("value").Value = textBox1.Text;
                xmldoc.Save(ServerConfig.FullName);
                form.RefreshGameSetting();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
