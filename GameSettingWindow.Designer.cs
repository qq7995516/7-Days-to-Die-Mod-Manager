namespace 七日杀Mod管理器
{
    partial class GameSettingWindow
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
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            contextMenuStrip1 = new ContextMenuStrip(components);
            刷新列表ToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            textBox1 = new TextBox();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            listView1.ContextMenuStrip = contextMenuStrip1;
            listView1.FullRowSelect = true;
            listView1.LabelWrap = false;
            listView1.Location = new Point(12, 59);
            listView1.MultiSelect = false;
            listView1.Name = "listView1";
            listView1.Size = new Size(1309, 1089);
            listView1.TabIndex = 19;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.ItemActivate += listView1_ItemActivate;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "变量名";
            columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "值";
            columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "简介";
            columnHeader3.Width = 1000;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { 刷新列表ToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(131, 28);
            // 
            // 刷新列表ToolStripMenuItem
            // 
            刷新列表ToolStripMenuItem.Name = "刷新列表ToolStripMenuItem";
            刷新列表ToolStripMenuItem.Size = new Size(130, 24);
            刷新列表ToolStripMenuItem.Text = "刷新列表";
            刷新列表ToolStripMenuItem.Click += 刷新列表ToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 23);
            label1.Name = "label1";
            label1.Size = new Size(35, 19);
            label1.TabIndex = 20;
            label1.Text = "搜索";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(53, 23);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(996, 24);
            textBox1.TabIndex = 21;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // GameSettingWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1333, 1160);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(listView1);
            Name = "GameSettingWindow";
            Text = "游戏设置";
            Load += GameSettingWindow_Load;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem 刷新列表ToolStripMenuItem;
        private Label label1;
        private TextBox textBox1;
    }
}