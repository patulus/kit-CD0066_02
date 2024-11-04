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

            //Bitmap bmp = Properties.Resources._10_of_clubs; // 숫자로는 변수 시작 안 됨 뭐가 더 있지?
            //Bitmap? bmp = Properties.Resources
            //    .ResourceManager.GetObject("100_of_clubs") // GetObject는 nullable return이므로 형에 ?를 붙여줌
            //                                               // 100_of_clubs라면 없기 때문에 표시되지 않는다
            //    as Bitmap;                                 // Image? img = ~ as Image로도 가능
            //Card1.Image = bmp as Image; // (Image)bmp 대신 bmp as Image를 쓰는 것이 더 안전 왜?

            Card1.Image = Properties.Resources.ResourceManager.GetObject($"{value}_of_{suit}") as Image;
        }
    }
}
