namespace G24W09WFImage
{
    public partial class Form1 : Form
    {
        private int ImageIndex;
        private Image[] Images;

        public Form1()
        {
            InitializeComponent();

            this.ImageIndex = 0;
            this.Images = new Image[]{ Properties.Resources._1, Properties.Resources._2, Properties.Resources._3 };
        }

        private void OnChange(object sender, EventArgs e)
        {
            this.ImageIndex = (this.ImageIndex + 1) % Images.Length;
            pictureBox1.Image = Images[this.ImageIndex];
        }
    }
}
