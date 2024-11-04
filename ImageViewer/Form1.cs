namespace ImageViewer
{
    public partial class ImageViewer : Form
    {
        public ImageViewer()
        {
            InitializeComponent();
        }

        private void OnShowImage(object sender, EventArgs e)
        {
            PbImage.Image = Properties.Resources.ÀÚÄí;
        }
    }
}
