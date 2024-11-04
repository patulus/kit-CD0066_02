namespace G24W10WFCardDealer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OnDeal(object sender, EventArgs e)
        {
            string[] suits = ["spades", "diamonds", "hearts", "clubs"];
            string[] values = ["ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king"];

            Random random = new Random();
            int card = random.Next(suits.Length * values.Length);

            string suit = suits[card / values.Length];
            string value = values[card % values.Length];

            //Bitmap bmp = Properties.Resources._10_of_clubs; // ���ڷδ� ���� ���� �� �� ���� �� ����?
            //Bitmap? bmp = Properties.Resources
            //    .ResourceManager.GetObject("100_of_clubs") // GetObject�� nullable return�̹Ƿ� ���� ?�� �ٿ���
            //                                               // 100_of_clubs��� ���� ������ ǥ�õ��� �ʴ´�
            //    as Bitmap;                                 // Image? img = ~ as Image�ε� ����
            //Card1.Image = bmp as Image; // (Image)bmp ��� bmp as Image�� ���� ���� �� ���� ��?

            Card1.Image = Properties.Resources.ResourceManager.GetObject($"{value}_of_{suit}") as Image;
        }
    }
}
