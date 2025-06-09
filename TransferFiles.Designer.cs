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
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            groupBox1 = new GroupBox();
            button1 = new Button();
            textBox5 = new TextBox();
            label3 = new Label();
            label2 = new Label();
            textBox_SP = new TextBox();
            label1 = new Label();
            textBox_SIP = new TextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            选择压缩文件ToolStripMenuItem = new ToolStripMenuItem();
            开启ToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip2 = new ContextMenuStrip(components);
            下载勾选ToolStripMenuItem = new ToolStripMenuItem();
            groupBox2 = new GroupBox();
            button2 = new Button();
            label4 = new Label();
            label5 = new Label();
            textBox_CP = new TextBox();
            label6 = new Label();
            textBox_CIP = new TextBox();
            listView2 = new ListView();
            columnHeader2 = new ColumnHeader();
            groupBox1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            contextMenuStrip2.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.CheckBoxes = true;
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            listView1.FullRowSelect = true;
            listView1.Location = new Point(6, 98);
            listView1.Name = "listView1";
            listView1.Size = new Size(794, 204);
            listView1.TabIndex = 4;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "文件路径";
            columnHeader1.Width = 700;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(textBox5);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBox_SP);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox_SIP);
            groupBox1.Controls.Add(listView1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(806, 308);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "服务端专用";
            // 
            // button1
            // 
            button1.Location = new Point(351, 35);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 11;
            button1.Text = "启动";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(451, 14);
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(349, 78);
            textBox5.TabIndex = 10;
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
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { 选择压缩文件ToolStripMenuItem, 开启ToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(181, 74);
            // 
            // 选择压缩文件ToolStripMenuItem
            // 
            选择压缩文件ToolStripMenuItem.Name = "选择压缩文件ToolStripMenuItem";
            选择压缩文件ToolStripMenuItem.Size = new Size(180, 24);
            选择压缩文件ToolStripMenuItem.Text = "选择压缩文件";
            选择压缩文件ToolStripMenuItem.Click += 选择压缩文件ToolStripMenuItem_Click;
            // 
            // 开启ToolStripMenuItem
            // 
            开启ToolStripMenuItem.Name = "开启ToolStripMenuItem";
            开启ToolStripMenuItem.Size = new Size(180, 24);
            开启ToolStripMenuItem.Text = "开启";
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Items.AddRange(new ToolStripItem[] { 下载勾选ToolStripMenuItem });
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(131, 28);
            // 
            // 下载勾选ToolStripMenuItem
            // 
            下载勾选ToolStripMenuItem.Name = "下载勾选ToolStripMenuItem";
            下载勾选ToolStripMenuItem.Size = new Size(130, 24);
            下载勾选ToolStripMenuItem.Text = "下载勾选";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(textBox_CP);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(textBox_CIP);
            groupBox2.Controls.Add(listView2);
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
            button2.Size = new Size(75, 23);
            button2.TabIndex = 12;
            button2.Text = "连接";
            button2.UseVisualStyleBackColor = true;
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
            // listView2
            // 
            listView2.CheckBoxes = true;
            listView2.Columns.AddRange(new ColumnHeader[] { columnHeader2 });
            listView2.FullRowSelect = true;
            listView2.Location = new Point(6, 98);
            listView2.Name = "listView2";
            listView2.Size = new Size(794, 204);
            listView2.TabIndex = 4;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.Details;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "文件路径";
            columnHeader2.Width = 700;
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
            contextMenuStrip1.ResumeLayout(false);
            contextMenuStrip2.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private GroupBox groupBox1;
        private Label label2;
        private TextBox textBox_SP;
        private Label label1;
        private TextBox textBox_SIP;
        private Label label3;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem 选择压缩文件ToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip2;
        private GroupBox groupBox2;
        private Label label4;
        private Label label5;
        private TextBox textBox_CP;
        private Label label6;
        private TextBox textBox_CIP;
        private ListView listView2;
        private ColumnHeader columnHeader2;
        private ToolStripMenuItem 开启ToolStripMenuItem;
        private ToolStripMenuItem 下载勾选ToolStripMenuItem;
        private TextBox textBox5;
        private Button button1;
        private Button button2;
    }
}