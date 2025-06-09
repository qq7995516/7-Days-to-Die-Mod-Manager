using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace 七日杀Mod管理器
{
    public partial class TransferFiles : Form
    {
        public static Socket? SeverSocket = null;
        public TransferFiles()
        {
            InitializeComponent();
        }

        private async void TransferFiles_Load(object sender, EventArgs e)
        {

        }

        private async Task HandleClientConnection(Socket clientSocket)
        {

        }

        /// <summary>
        /// 启动服务端socket
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button1_Click(object sender, EventArgs e)
        {
            //尝试获取端口,如果失败,则随机生成一个端口号
            var p = int.TryParse(textBox_SP.Text, out int i) ? i : new Random().Next(10000, 40000);
            textBox_SIP.Text = textBox_SIP.Text == "" ? $"{Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(i => i.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).First()}" : textBox_SIP.Text;
            //将端口号显示在文本框中
            textBox_SP.Text = p.ToString();
            //创建一个Socket对象
            SeverSocket = Tool.CreateSocketTCP(textBox_SIP.Text, i);
            //开始监听
            //如果接收到连接时的处理方法.
            await SeverSocket.MonitorAsync(async clientSocket =>
            {
                try
                {
                    await HandleClientConnection(clientSocket);
                }
                catch (Exception ex) { }
            });
        }

        private void 选择压缩文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var zips = Tool.OpenFileDialog("请选择要传输的文件", Filter: "压缩包(*.rar;*.7z;*.zip)|*.rar;*.7z;*.zip");
            zips.ForEach(f =>
            {
                if (f != null)
                {
                    listView1.Items.Add(new ListViewItem() { Text = f });
                }
            });
        }
    }
}
