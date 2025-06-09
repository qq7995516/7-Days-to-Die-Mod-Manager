namespace 七日杀Mod管理器
{
    public partial class Tips : Form
    {
        //public TextBox textBox2;
        public string tip;
        public Tips(string tips)
        {
            this.tip = tips;
            InitializeComponent();
        }

        private void Tips_Load(object sender, EventArgs e)
        {
            textBox1.Text = tip;
        }
    }
}
