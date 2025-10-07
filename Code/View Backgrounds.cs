namespace Legacy_Order_Validator
{
    public partial class View_Backgrounds : Form
    {
        private List<string> Backgrounds { get; }

        public View_Backgrounds(List<string> backgrounds)
        {
            InitializeComponent();
            Backgrounds = backgrounds;
        }

        private void View_Backgrounds_Load(object sender, EventArgs e)
        {
            foreach (string background in Backgrounds)
                backgroundListBox.Items.Add(background);
        }
    }
}
