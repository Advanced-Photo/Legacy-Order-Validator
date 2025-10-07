namespace Legacy_Order_Validator
{
    public partial class View_Units : Form
    {
        private List<string> Units { get; }

        public View_Units(List<string> units)
        {
            InitializeComponent();
            Units = units;
        }

        private void View_Units_Load(object sender, EventArgs e)
        {
            foreach (string unit in Units)
                unitListBox.Items.Add(unit);
        }
    }
}
