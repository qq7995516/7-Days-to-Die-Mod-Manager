
using Newtonsoft.Json;

namespace 七日杀Mod管理器
{
    public partial class ReferenceBook : Form
    {
        public string JsonPath = AppDomain.CurrentDomain.BaseDirectory + "tmp.json";
        public List<List<object>>? lists = default;
        public bool sortAscending = true;
        public ReferenceBook()
        {
            InitializeComponent();
        }

        private void ReferenceBook_Load(object sender, EventArgs e)
        {

            var jsonStr = File.ReadAllText(JsonPath);
            lists = JsonConvert.DeserializeObject<List<List<object>>>(jsonStr);
            Thread.Sleep(1);
            listView1.ColumnClick += Tool.SortListView;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var filter = lists.Where(i => i.Any(d => d.ToString().ToLower().Trim().Contains(textBox1.Text)) || i.Any(d => d.ToString().ToUpper().Trim().Contains(textBox1.Text))).ToList();
            if (filter.Count > 0)
            {
                listView1.Items.Clear();
            }
            if (filter.Count == 0)
                return;

            filter.RemoveAt(0);
            filter.RemoveAll(d => d[7].ToString() == "");

            filter.ForEach(d =>
            {
                var item = new ListViewItem();
                item.Text = d[0].ToString();
                for (int i = 1; i < d.Count; i++)
                {
                    item.SubItems.Add(d[i].ToString());
                }
                listView1.Items.Add(item);
            });
        }
    }
}
