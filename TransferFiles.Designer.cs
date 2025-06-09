namespace 七日杀Mod管理器
{
    partial class TransferFiles
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            listView_Sever = new ListView();
            columnHeader1 = new ColumnHeader();
            groupBox1 = new GroupBox();
            button_ServerStartup = new Button();
            textBox_debug = new TextBox();
            label3 = new Label();
            label2 = new Label();
            textBox_SP = new TextBox();
            label1 = new Label();
            textBox_SIP = new TextBox();
            contextMenuStrip_Sever = new ContextMenuStrip(components);
            选择压缩文件ToolStripMenuItem = new ToolStripMenuItem();
            开启ToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip_Cliten = new ContextMenuStrip(components);
            下载勾选ToolStripMenuItem = new ToolStripMenuItem();
            连接ToolStripMenuItem = new ToolStripMenuItem();
            groupBox2 = new GroupBox();
            button2 = new Button();
            label4 = new Label();
            label5 = new Label();
            textBox_CP = new TextBox();
            label6 = new Label();
            textBox_CIP = new TextBox();
            listView_Client = new ListView();
            columnHeader2 = new ColumnHeader();
            刷新ToolStripMenuItem = new ToolStripMenuItem();
            刷新ToolStripMenuItem1 = new ToolStripMenuItem();
            groupBox1.SuspendLayout();
            contextMenuStrip_Sever.SuspendLayout();
            contextMenuStrip_Cliten.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // listView_Sever
            // 
            listView_Sever.CheckBoxes = true;
            listView_Sever.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            listView_Sever.FullRowSelect = true;
            listView_Sever.Location = new Point(6, 98);
            listView_Sever.Name = "listView_Sever";
            listView_Sever.Size = new Size(794, 204);
            listView_Sever.TabIndex = 4;
            listView_Sever.UseCompatibleStateImageBehavior = false;
            listView_Sever.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "文件路径";
            columnHeader1.Width = 700;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button_ServerStartup);
            groupBox1.Controls.Add(textBox_debug);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBox_SP);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox_SIP);
            groupBox1.Controls.Add(listView_Sever);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(806, 308);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "服务端专用";
            // 
            // button_ServerStartup
            // 
            button_ServerStartup.Location = new Point(351, 35);
            button_ServerStartup.Name = "button_ServerStartup";
            button_ServerStartup.Size = new Size(122, 25);
            button_ServerStartup.TabIndex = 11;
            button_ServerStartup.Text = "开启服务端";
            button_ServerStartup.UseVisualStyleBackColor = true;
            button_ServerStartup.Click += button1_Click;
            // 
            // textBox_debug
            // 
            textBox_debug.Location = new Point(479, 14);
            textBox_debug.Multiline = true;
            textBox_debug.Name = "textBox_debug";
            textBox_debug.Size = new Size(321, 78);
            textBox_debug.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 76);
            label3.Name = "label3";
            label3.Size = new Size(90, 19);
            label3.TabIndex = 9;
            label3.Text = "Mod供应列表";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(206, 40);
            label2.Name = "label2";
            label2.Size = new Size(35, 19);
            label2.TabIndex = 8;
            label2.Text = "端口";
            // 
            // textBox_SP
            // 
            textBox_SP.Location = new Point(247, 35);
            textBox_SP.Name = "textBox_SP";
            textBox_SP.Size = new Size(98, 24);
            textBox_SP.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 37);
            label1.Name = "label1";
            label1.Size = new Size(21, 19);
            label1.TabIndex = 6;
            label1.Text = "IP";
            // 
            // textBox_SIP
            // 
            textBox_SIP.Location = new Point(33, 37);
            textBox_SIP.Name = "textBox_SIP";
            textBox_SIP.Size = new Size(167, 24);
            textBox_SIP.TabIndex = 5;
            // 
            // contextMenuStrip_Sever
            // 
            contextMenuStrip_Sever.Items.AddRange(new ToolStripItem[] { 选择压缩文件ToolStripMenuItem, 开启ToolStripMenuItem, 刷新ToolStripMenuItem1 });
            contextMenuStrip_Sever.Name = "contextMenuStrip1";
            contextMenuStrip_Sever.Size = new Size(157, 76);
            // 
            // 选择压缩文件ToolStripMenuItem
            // 
            选择压缩文件ToolStripMenuItem.Name = "选择压缩文件ToolStripMenuItem";
            选择压缩文件ToolStripMenuItem.Size = new Size(156, 24);
            选择压缩文件ToolStripMenuItem.Text = "选择压缩文件";
            选择压缩文件ToolStripMenuItem.Click += 选择压缩文件ToolStripMenuItem_Click;
            // 
            // 开启ToolStripMenuItem
            // 
            开启ToolStripMenuItem.Name = "开启ToolStripMenuItem";
            开启ToolStripMenuItem.Size = new Size(156, 24);
            开启ToolStripMenuItem.Text = "开启服务端";
            开启ToolStripMenuItem.Click += 开启ToolStripMenuItem_Click;
            // 
            // contextMenuStrip_Cliten
            // 
            contextMenuStrip_Cliten.Items.AddRange(new ToolStripItem[] { 下载勾选ToolStripMenuItem, 连接ToolStripMenuItem, 刷新ToolStripMenuItem });
            contextMenuStrip_Cliten.Name = "contextMenuStrip2";
            contextMenuStrip_Cliten.Size = new Size(181, 98);
            // 
            // 下载勾选ToolStripMenuItem
            // 
            下载勾选ToolStripMenuItem.Name = "下载勾选ToolStripMenuItem";
            下载勾选ToolStripMenuItem.Size = new Size(180, 24);
            下载勾选ToolStripMenuItem.Text = "下载勾选";
            下载勾选ToolStripMenuItem.Click += 下载勾选ToolStripMenuItem_Click;
            // 
            // 连接ToolStripMenuItem
            // 
            连接ToolStripMenuItem.Name = "连接ToolStripMenuItem";
            连接ToolStripMenuItem.Size = new Size(180, 24);
            连接ToolStripMenuItem.Text = "连接服务端";
            连接ToolStripMenuItem.Click += 连接ToolStripMenuItem_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(textBox_CP);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(textBox_CIP);
            groupBox2.Controls.Add(listView_Client);
            groupBox2.Location = new Point(12, 335);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(806, 308);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "客户端专用";
            // 
            // button2
            // 
            button2.Location = new Point(351, 36);
            button2.Name = "button2";
            button2.Size = new Size(122, 25);
            button2.TabIndex = 12;
            button2.Text = "连接服务端";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 76);
            label4.Name = "label4";
            label4.Size = new Size(103, 19);
            label4.TabIndex = 9;
            label4.Text = "Mod待下载列表";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(206, 40);
            label5.Name = "label5";
            label5.Size = new Size(35, 19);
            label5.TabIndex = 8;
            label5.Text = "端口";
            // 
            // textBox_CP
            // 
            textBox_CP.Location = new Point(247, 35);
            textBox_CP.Name = "textBox_CP";
            textBox_CP.Size = new Size(98, 24);
            textBox_CP.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 37);
            label6.Name = "label6";
            label6.Size = new Size(21, 19);
            label6.TabIndex = 6;
            label6.Text = "IP";
            // 
            // textBox_CIP
            // 
            textBox_CIP.Location = new Point(33, 37);
            textBox_CIP.Name = "textBox_CIP";
            textBox_CIP.Size = new Size(167, 24);
            textBox_CIP.TabIndex = 5;
            // 
            // listView_Client
            // 
            listView_Client.CheckBoxes = true;
            listView_Client.Columns.AddRange(new ColumnHeader[] { columnHeader2 });
            listView_Client.FullRowSelect = true;
            listView_Client.Location = new Point(6, 98);
            listView_Client.Name = "listView_Client";
            listView_Client.Size = new Size(794, 204);
            listView_Client.TabIndex = 4;
            listView_Client.UseCompatibleStateImageBehavior = false;
            listView_Client.View = View.Details;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "文件路径";
            columnHeader2.Width = 700;
            // 
            // 刷新ToolStripMenuItem
            // 
            刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            刷新ToolStripMenuItem.Size = new Size(180, 24);
            刷新ToolStripMenuItem.Text = "刷新";
            // 
            // 刷新ToolStripMenuItem1
            // 
            刷新ToolStripMenuItem1.Name = "刷新ToolStripMenuItem1";
            刷新ToolStripMenuItem1.Size = new Size(156, 24);
            刷新ToolStripMenuItem1.Text = "刷新";
            // 
            // TransferFiles
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(836, 653);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "TransferFiles";
            Text = "传输文件";
            Load += TransferFiles_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            contextMenuStrip_Sever.ResumeLayout(false);
            contextMenuStrip_Cliten.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ListView listView_Sever;
        private ColumnHeader columnHeader1;
        private GroupBox groupBox1;
        private Label label2;
        private TextBox textBox_SP;
        private Label label1;
        private TextBox textBox_SIP;
        private Label label3;
        private ContextMenuStrip contextMenuStrip_Sever;
        private ToolStripMenuItem 选择压缩文件ToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip_Cliten;
        private GroupBox groupBox2;
        private Label label4;
        private Label label5;
        private TextBox textBox_CP;
        private Label label6;
        private TextBox textBox_CIP;
        private ListView listView_Client;
        private ColumnHeader columnHeader2;
        private ToolStripMenuItem 开启ToolStripMenuItem;
        private ToolStripMenuItem 下载勾选ToolStripMenuItem;
        private TextBox textBox_debug;
        private Button button_ServerStartup;
        private Button button2;
        private ToolStripMenuItem 连接ToolStripMenuItem;
        private ToolStripMenuItem 刷新ToolStripMenuItem1;
        private ToolStripMenuItem 刷新ToolStripMenuItem;
    }
}