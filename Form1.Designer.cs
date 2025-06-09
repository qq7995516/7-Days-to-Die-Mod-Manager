namespace 七日杀Mod管理器
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            contextMenuStrip1 = new ContextMenuStrip(components);
            添加ToolStripMenuItem = new ToolStripMenuItem();
            压缩包ToolStripMenuItem = new ToolStripMenuItem();
            文件夹ToolStripMenuItem = new ToolStripMenuItem();
            删除ToolStripMenuItem = new ToolStripMenuItem();
            刷新ToolStripMenuItem = new ToolStripMenuItem();
            打包勾选ModToolStripMenuItem = new ToolStripMenuItem();
            label2 = new Label();
            label3 = new Label();
            button2 = new Button();
            label4 = new Label();
            button4 = new Button();
            listView2 = new ListView();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            columnHeader11 = new ColumnHeader();
            contextMenuStrip2 = new ContextMenuStrip(components);
            添加ToolStripMenuItem1 = new ToolStripMenuItem();
            删除选中ToolStripMenuItem = new ToolStripMenuItem();
            label9 = new Label();
            button3 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            contextMenuStrip1.SuspendLayout();
            contextMenuStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 28);
            label1.Name = "label1";
            label1.Size = new Size(87, 19);
            label1.TabIndex = 0;
            label1.Text = "七日杀文件夹";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(105, 25);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(441, 24);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(552, 26);
            button1.Name = "button1";
            button1.Size = new Size(91, 30);
            button1.TabIndex = 2;
            button1.Text = "选择文件夹";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listView1
            // 
            listView1.CheckBoxes = true;
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6 });
            listView1.ContextMenuStrip = contextMenuStrip1;
            listView1.FullRowSelect = true;
            listView1.Location = new Point(12, 97);
            listView1.Name = "listView1";
            listView1.Size = new Size(1119, 598);
            listView1.TabIndex = 3;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "文件名称";
            columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Mod名称";
            columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "简介";
            columnHeader3.Width = 350;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "版本";
            columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "作者";
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Mod安装情况";
            columnHeader6.Width = 100;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { 添加ToolStripMenuItem, 删除ToolStripMenuItem, 刷新ToolStripMenuItem, 打包勾选ModToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(160, 100);
            // 
            // 添加ToolStripMenuItem
            // 
            添加ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 压缩包ToolStripMenuItem, 文件夹ToolStripMenuItem });
            添加ToolStripMenuItem.Name = "添加ToolStripMenuItem";
            添加ToolStripMenuItem.Size = new Size(159, 24);
            添加ToolStripMenuItem.Text = "安装Mod";
            // 
            // 压缩包ToolStripMenuItem
            // 
            压缩包ToolStripMenuItem.Name = "压缩包ToolStripMenuItem";
            压缩包ToolStripMenuItem.Size = new Size(117, 24);
            压缩包ToolStripMenuItem.Text = "压缩包";
            压缩包ToolStripMenuItem.Click += 压缩包ToolStripMenuItem_Click;
            // 
            // 文件夹ToolStripMenuItem
            // 
            文件夹ToolStripMenuItem.Name = "文件夹ToolStripMenuItem";
            文件夹ToolStripMenuItem.Size = new Size(117, 24);
            文件夹ToolStripMenuItem.Text = "文件夹";
            文件夹ToolStripMenuItem.Click += 文件夹ToolStripMenuItem_Click;
            // 
            // 删除ToolStripMenuItem
            // 
            删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            删除ToolStripMenuItem.Size = new Size(159, 24);
            删除ToolStripMenuItem.Text = "删除勾选Mod";
            删除ToolStripMenuItem.Click += 删除ToolStripMenuItem_Click;
            // 
            // 刷新ToolStripMenuItem
            // 
            刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            刷新ToolStripMenuItem.Size = new Size(159, 24);
            刷新ToolStripMenuItem.Text = "刷新列表";
            刷新ToolStripMenuItem.Click += 刷新ToolStripMenuItem_Click;
            // 
            // 打包勾选ModToolStripMenuItem
            // 
            打包勾选ModToolStripMenuItem.Name = "打包勾选ModToolStripMenuItem";
            打包勾选ModToolStripMenuItem.Size = new Size(159, 24);
            打包勾选ModToolStripMenuItem.Text = "打包勾选Mod";
            打包勾选ModToolStripMenuItem.Click += 打包勾选ModToolStripMenuItem_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 75);
            label2.Name = "label2";
            label2.Size = new Size(67, 19);
            label2.TabIndex = 4;
            label2.Text = "Mod列表:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1053, 59);
            label3.Name = "label3";
            label3.Size = new Size(64, 19);
            label3.TabIndex = 5;
            label3.Text = "作者:羽高";
            // 
            // button2
            // 
            button2.Location = new Point(649, 28);
            button2.Name = "button2";
            button2.Size = new Size(75, 27);
            button2.TabIndex = 6;
            button2.Text = "Mod下载";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 1027);
            label4.Name = "label4";
            label4.Size = new Size(197, 19);
            label4.TabIndex = 8;
            label4.Text = "bug反馈及建议:Q群870076476";
            // 
            // button4
            // 
            button4.Location = new Point(730, 29);
            button4.Name = "button4";
            button4.Size = new Size(75, 27);
            button4.TabIndex = 9;
            button4.Text = "存档管理";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // listView2
            // 
            listView2.CheckBoxes = true;
            listView2.Columns.AddRange(new ColumnHeader[] { columnHeader7, columnHeader8, columnHeader9, columnHeader10, columnHeader11 });
            listView2.ContextMenuStrip = contextMenuStrip2;
            listView2.FullRowSelect = true;
            listView2.Location = new Point(12, 735);
            listView2.Name = "listView2";
            listView2.Size = new Size(1119, 275);
            listView2.TabIndex = 40;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.Details;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "被备份文件夹";
            columnHeader7.Width = 300;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "存放备份路径";
            columnHeader8.Width = 300;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "最大备份数";
            columnHeader9.Width = 80;
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "间隔(时)";
            columnHeader10.Width = 100;
            // 
            // columnHeader11
            // 
            columnHeader11.Text = "倒计时(时)";
            columnHeader11.Width = 80;
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Items.AddRange(new ToolStripItem[] { 添加ToolStripMenuItem1, 删除选中ToolStripMenuItem });
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(131, 52);
            // 
            // 添加ToolStripMenuItem1
            // 
            添加ToolStripMenuItem1.Name = "添加ToolStripMenuItem1";
            添加ToolStripMenuItem1.Size = new Size(130, 24);
            添加ToolStripMenuItem1.Text = "添加";
            添加ToolStripMenuItem1.Click += 添加ToolStripMenuItem1_Click;
            // 
            // 删除选中ToolStripMenuItem
            // 
            删除选中ToolStripMenuItem.Name = "删除选中ToolStripMenuItem";
            删除选中ToolStripMenuItem.Size = new Size(130, 24);
            删除选中ToolStripMenuItem.Text = "删除选中";
            删除选中ToolStripMenuItem.Click += 删除选中ToolStripMenuItem_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 713);
            label9.Name = "label9";
            label9.Size = new Size(64, 19);
            label9.TabIndex = 41;
            label9.Text = "备份列表:";
            // 
            // button3
            // 
            button3.Location = new Point(811, 29);
            button3.Name = "button3";
            button3.Size = new Size(98, 27);
            button3.TabIndex = 42;
            button3.Text = "白嫖攻略";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click_1;
            // 
            // button5
            // 
            button5.Location = new Point(915, 29);
            button5.Name = "button5";
            button5.Size = new Size(98, 27);
            button5.TabIndex = 43;
            button5.Text = "游戏设置";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(1019, 29);
            button6.Name = "button6";
            button6.Size = new Size(98, 27);
            button6.TabIndex = 44;
            button6.Text = "如何使用";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(105, 55);
            button7.Name = "button7";
            button7.Size = new Size(98, 27);
            button7.TabIndex = 45;
            button7.Text = "同步Mod";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1152, 1055);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button3);
            Controls.Add(label9);
            Controls.Add(listView2);
            Controls.Add(button4);
            Controls.Add(label4);
            Controls.Add(button2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(listView1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "七日杀Mod管理器1.3.4";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            contextMenuStrip1.ResumeLayout(false);
            contextMenuStrip2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        public TextBox textBox1;
        private Button button1;
        private ListView listView1;
        private Label label2;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem 添加ToolStripMenuItem;
        private ToolStripMenuItem 删除ToolStripMenuItem;
        private ToolStripMenuItem 刷新ToolStripMenuItem;
        private Label label3;
        private Button button2;
        private ToolStripMenuItem 压缩包ToolStripMenuItem;
        private ToolStripMenuItem 文件夹ToolStripMenuItem;
        private Label label4;
        private Button button4;
        public ListView listView2;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private Label label9;
        private ColumnHeader columnHeader11;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem 添加ToolStripMenuItem1;
        private ToolStripMenuItem 删除选中ToolStripMenuItem;
        private Button button3;
        private Button button5;
        private Button button6;
        private ToolStripMenuItem 打包勾选ModToolStripMenuItem;
        private Button button7;
    }
}
