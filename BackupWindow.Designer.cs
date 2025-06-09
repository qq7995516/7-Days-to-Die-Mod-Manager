namespace 七日杀Mod管理器
{
    partial class BackupWindow
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
            button2 = new Button();
            label2 = new Label();
            textBox_BackupPath = new TextBox();
            label3 = new Label();
            textBox_ArchivePath = new TextBox();
            button4 = new Button();
            label1 = new Label();
            textBox_MaxBackup = new TextBox();
            label4 = new Label();
            textBox2_BackupInterval = new TextBox();
            button3 = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Location = new Point(618, 40);
            button2.Name = "button2";
            button2.Size = new Size(96, 23);
            button2.TabIndex = 16;
            button2.Text = "选择文件夹";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 45);
            label2.Name = "label2";
            label2.Size = new Size(87, 19);
            label2.TabIndex = 17;
            label2.Text = "存放备份路径";
            // 
            // textBox_BackupPath
            // 
            textBox_BackupPath.Location = new Point(133, 42);
            textBox_BackupPath.Name = "textBox_BackupPath";
            textBox_BackupPath.Size = new Size(479, 24);
            textBox_BackupPath.TabIndex = 18;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 15);
            label3.Name = "label3";
            label3.Size = new Size(87, 19);
            label3.TabIndex = 21;
            label3.Text = "游戏存档路径";
            // 
            // textBox_ArchivePath
            // 
            textBox_ArchivePath.Location = new Point(133, 12);
            textBox_ArchivePath.Name = "textBox_ArchivePath";
            textBox_ArchivePath.Size = new Size(479, 24);
            textBox_ArchivePath.TabIndex = 22;
            // 
            // button4
            // 
            button4.Location = new Point(618, 11);
            button4.Name = "button4";
            button4.Size = new Size(96, 23);
            button4.TabIndex = 23;
            button4.Text = "选择文件夹";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 75);
            label1.Name = "label1";
            label1.Size = new Size(74, 19);
            label1.TabIndex = 24;
            label1.Text = "最大备份数";
            // 
            // textBox_MaxBackup
            // 
            textBox_MaxBackup.Location = new Point(133, 72);
            textBox_MaxBackup.Name = "textBox_MaxBackup";
            textBox_MaxBackup.Size = new Size(99, 24);
            textBox_MaxBackup.TabIndex = 25;
            textBox_MaxBackup.TextChanged += textBox_MaxBackup_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 107);
            label4.Name = "label4";
            label4.Size = new Size(82, 19);
            label4.TabIndex = 26;
            label4.Text = "备份间隔(时)";
            // 
            // textBox2_BackupInterval
            // 
            textBox2_BackupInterval.Location = new Point(133, 102);
            textBox2_BackupInterval.Name = "textBox2_BackupInterval";
            textBox2_BackupInterval.Size = new Size(99, 24);
            textBox2_BackupInterval.TabIndex = 27;
            textBox2_BackupInterval.TextChanged += textBox2_BackupInterval_TextChanged;
            // 
            // button3
            // 
            button3.Location = new Point(246, 143);
            button3.Name = "button3";
            button3.Size = new Size(96, 24);
            button3.TabIndex = 20;
            button3.Text = "添加";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button1
            // 
            button1.Location = new Point(372, 143);
            button1.Name = "button1";
            button1.Size = new Size(96, 24);
            button1.TabIndex = 28;
            button1.Text = "关闭";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // BackupWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(746, 190);
            Controls.Add(button1);
            Controls.Add(textBox2_BackupInterval);
            Controls.Add(label4);
            Controls.Add(textBox_MaxBackup);
            Controls.Add(label1);
            Controls.Add(button4);
            Controls.Add(textBox_ArchivePath);
            Controls.Add(label3);
            Controls.Add(button3);
            Controls.Add(textBox_BackupPath);
            Controls.Add(label2);
            Controls.Add(button2);
            Name = "BackupWindow";
            Text = "添加备份计划";
            Load += BackupWindow_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private Label label2;
        private TextBox textBox_BackupPath;
        private Label label3;
        private TextBox textBox_ArchivePath;
        private Button button4;
        private Label label1;
        private TextBox textBox_MaxBackup;
        private Label label4;
        private TextBox textBox2_BackupInterval;
        private Button button3;
        private Button button1;
    }
}