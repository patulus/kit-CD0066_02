namespace G24W07WFCounter
{
    public partial class Form1 : Form
    {
        private int Count;

        public Form1()
        {
            Count = 0;
            InitializeComponent();
        }

        private void OnAdd(object sender, EventArgs e)
        {
            //labelCount.Text = (++Count).ToString();
            labelCount.Text = $"{++Count}";
        }

        private void OnSub(object sender, EventArgs e)
        {
            if (Count > 0)
            {
                labelCount.Text = $"{--Count}";
            }
        }

        private void OnReset(object sender, EventArgs e)
        {
            labelCount.Text = $"{Count = 0}";
        }
    }
}
