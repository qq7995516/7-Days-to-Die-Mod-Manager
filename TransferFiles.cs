using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using static 七日杀Mod管理器.Tool;

namespace 七日杀Mod管理器
{
    public partial class TransferFiles : Form
    {
        /// <summary>
        /// 服务器所拥有的文件列表
        /// </summary>
        public static List<string> SeverAllFile = new();

        /// <summary>
        /// 客户端所拥有的文件列表
        /// </summary>
        public static List<string> ClientAllFile = new();

        /// <summary>
        /// 服务器端Socket对象
        /// </summary>
        public static Socket? SeverSocket = null;

        /// <summary>
        /// 客户端Socket对象
        /// </summary>
        public static Socket? ClientSocket = null;

        /// <summary>
        /// 是否已连接到服务端
        /// </summary>
        public bool IsConnectedToServer = false;

        /// <summary>
        /// 记录服务端状态,是否已启动
        /// </summary>
        public bool IsServerStartup = false;

        public TransferFiles()
        {
            InitializeComponent();
        }

        private async void TransferFiles_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 处理客户端请求
        /// </summary>
        /// <param name="clientSocket"></param>
        /// <returns></returns>
        private async Task HandleClientConnection(Socket clientSocket)
        {
            //先判断客户端发送的内容
            var receivedBytes = (await clientSocket.ReceiveAllAsync()).ToObject<CommunicationProtocol>();
            switch (receivedBytes.ProtocolType)
            {
                case CommunicationProtocol.type.GetFileList:
                    //如果是获取文件列表,则返回服务端可下载的文件列表
                    var files = listView_Sever.Items.Cast<ListViewItem>().Select(i => i.Text).ToList();
                    var response = new CommunicationProtocol(CommunicationProtocol.type.GetFileList)
                    {
                        SeverAllFiles = files
                    };

                    await clientSocket.SendAllAsync(response.ToBytes());
                    textBox_debug.Text += $"已向客户端发送可下载文件列表: {string.Join(", ", files)}\r\n";
                    break;
                case CommunicationProtocol.type.DownloadFile:
                    //筛选出需要下载的文件
                    var file = SeverAllFile.Find(sf =>
                    //服务器拥有的
                      SeverAllFile.Contains(receivedBytes.ClitenDownFile)
                      //客户端请求的文件
                      && !receivedBytes.ClientAllFiles.Contains(receivedBytes.ClitenDownFile)
                      );
                    //读取文件内容
                    var fileBytes = File.ReadAllBytes(file);
                    //发送文件内容
                    var responseDown = new CommunicationProtocol(CommunicationProtocol.type.ResponseData)
                    {
                        FileData = new KeyValuePair<string, byte[]>(file, fileBytes),
                    };
                    await clientSocket.SendAllAsync(responseDown.ToBytes());
                    textBox_debug.Text += $"已向客户端发送文件: {file}\r\n";

                    break;
                case CommunicationProtocol.type.Message:
                    //如果是消息,则直接显示在文本框中
                    textBox_debug.Text += $"客户端消息: {receivedBytes.Message}\r\n";

                    await clientSocket.SendAllAsync(Encoding.UTF8.GetBytes("无可奉告!"));
                    break;
                default:
                    textBox_debug.Text += $"未知的协议类型: {receivedBytes.ProtocolType}\r\n";
                    break;
            }
        }


        /// <summary>
        /// 启动服务端socket
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button1_Click(object sender, EventArgs e)
        {
            // 如果没启动就启动
            if (!IsServerStartup)
                ServerStartup();
            else
                await CloseServer();
        }

        public async Task ServerStartup()
        {
            //如果服务端已启动,则不再重复启动
            if (IsServerStartup)
            {
                textBox_debug.Text += "服务端已启动,无需重复启动";
                return;
            }
            IsServerStartup = true;
            //把按钮文本改为"关闭"
            button_ServerStartup.Text = "关闭服务端";
            contextMenuStrip_Sever.Items[1].Text = "关闭服务端";
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
                    HandleClientConnection(clientSocket);
                }
                catch (Exception ex)
                {
                    textBox_debug.Text += $"处理客户端连接时发生错误: {ex.Message}\r\n";
                }
                finally
                {
                    //关闭客户端连接
                    clientSocket.Close();
                }
            });
        }

        public async Task CloseServer()
        {
            if (SeverSocket != null)
            {
                //断开所有连接
                textBox_debug.Text += "正在关闭服务端...\r\n";
                SeverSocket.Close();
                SeverSocket = null;
                IsServerStartup = false;
                //把按钮文本改为"开启"
                button_ServerStartup.Text = "开启服务端";
                contextMenuStrip_Sever.Items[1].Text = "开启服务端";
                textBox_debug.Text += "服务端已关闭\r\n";
            }
            else
            {
                textBox_debug.Text += "服务端未启动\r\n";
            }
        }
        private async void 开启ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 如果没启动就启动
            if (!IsServerStartup)
                ServerStartup();
            else
                await CloseServer();
        }

        private void 选择压缩文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var zips = Tool.OpenFileDialog("请选择要传输的文件", Filter: "压缩包(*.rar;*.7z;*.zip)|*.rar;*.7z;*.zip");
            zips.ForEach(f =>
            {
                if (f != null)
                {
                    listView_Sever.Items.Add(new ListViewItem() { Text = f });
                }
            });
            SeverAllFile = zips;
        }

        /// <summary>
        /// 按钮,连接服务端
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button2_Click(object sender, EventArgs e)
        {
            if (IsConnectedToServer)
                ConnenctServer();
            else
                await DisconnectServer();

        }
        /// <summary>
        /// 菜单,连接服务端
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void 连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsConnectedToServer)
                ConnenctServer();
            else
                await DisconnectServer();
        }

        /// <summary>
        /// 连接服务器
        /// </summary>
        /// <returns></returns>
        public async Task ConnenctServer()
        {
            //如果已连接到服务端,则不再重复连接
            if (IsConnectedToServer)
            {
                textBox_debug.Text += "已连接到服务端,无需重复连接\r\n";
                return;
            }
            IsConnectedToServer = true;
            //获取IP和端口
            var ip = textBox_CIP.Text == "" ? $"{Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(i => i.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).First()}" : textBox_CIP.Text;
            var port = int.TryParse(textBox_CP.Text, out int i) ? i : 8080;
            //创建一个Socket对象
            ClientSocket = Tool.CreateSocketTCP(ip, port);
            //连接到服务端
            await ClientSocket.ConnectAsync(ip, port);
            //连接成功后,将按钮文本改为"断开连接"
            button2.Text = "断开连接";
            //获取可下载文件列表
            var files = await GetDownloadFiles();
            //清空ListView
            listView_Client.Items.Clear();
            //把文件列表添加到ListView中
            files?.ForEach(file =>
                listView_Client.Items.Add(new ListViewItem() { Text = file })
            );
        }

        //断开对服务器的连接
        public async Task DisconnectServer()
        {
            if (ClientSocket != null)
            {
                //断开连接
                textBox_debug.Text += "正在断开连接...\r\n";
                ClientSocket.Close();
                ClientSocket = null;
                IsConnectedToServer = false;
                //把按钮文本改为"连接"
                button2.Text = "连接服务端";
                contextMenuStrip_Cliten.Items[1].Text = "连接服务端";
                textBox_debug.Text += "已断开连接\r\n";
            }
            else
            {
                textBox_debug.Text += "未连接到服务端\r\n";
            }
        }


        //获取可下载文件
        public async Task<List<string>?> GetDownloadFiles()
        {
            //如果未连接到服务端,则提示用户
            if (!IsConnectedToServer)
            {
                textBox_debug.Text += "请先连接到服务端\r\n";
                return null;
            }

            try
            {
                //发送获取服务端可下载文件列表
                await ClientSocket.SendAllAsync(new CommunicationProtocol(CommunicationProtocol.type.GetFileList).ToBytes());

                //接收服务端返回的文件列表
                var responseBytes = await ClientSocket.ReceiveAllAsync();

                //反序列化响应数据
                var response = responseBytes.ToObject<CommunicationProtocol>();

                textBox_debug.Text += $"获取到 {response.SeverAllFiles.Count} 个可下载文件\r\n";
                return response.SeverAllFiles;
            }
            catch (Exception ex)
            {
                textBox_debug.Text += $"获取文件列表失败: {ex.Message}\r\n";
                return null;
            }
        }

        private async void 下载勾选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //是否已连接
            if (!IsConnectedToServer)
            {
                textBox_debug.Text += "请先连接到服务端\r\n";
                return;
            }

            //获取勾中的文件
            var selectedFiles = listView_Sever.SelectedItems.Cast<ListViewItem>().Select(i => i.Text).ToList();
            foreach (var item in selectedFiles)
            {
                var df = new CommunicationProtocol(CommunicationProtocol.type.DownloadFile)
                {
                    ClitenDownFile = item
                };
                await ClientSocket.SendAllAsync(df.ToBytes());
                textBox_debug.Text += $"已向服务端发送下载请求,请求下载文件: {string.Join(", ", selectedFiles)}\r\n";
                // 接收下载的文件
                await ReceiveDownloadFiles();
                //安装下载的文件
                await item.InstallTheCompressedPackage(Form1.WinRAR_Path);
                textBox_debug.Text += $"已安装文件: {item}\r\n";
            }
        }

        /// <summary>
        /// 接收下载的文件
        /// </summary>
        /// <returns></returns>
        public async Task ReceiveDownloadFiles()
        {
            if (ClientSocket == null)
            {
                textBox_debug.Text += "未连接到服务端,无法接收文件\r\n";
                return;
            }
            try
            {
                //接收服务端返回的文件数据
                var responseBytes = await ClientSocket.ReceiveAllAsync();
                var response = responseBytes.ToObject<CommunicationProtocol>();
                //保存文件到本地
                await response.FileData.Value.Key.SaveToFile(response.FileData.Value.Value);

                textBox_debug.Text += $"已下载文件: {response.FileData.Value.Key}\r\n";
            }
            catch (Exception ex)
            {
                textBox_debug.Text += $"接收文件失败: {ex.Message}\r\n";
            }
        }

    }
}