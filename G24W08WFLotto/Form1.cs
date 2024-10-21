namespace G24W08WFLotto
{
    public partial class Form1 : Form
    {
        private const int LottoCount = 6;

        public Form1()
        {
            InitializeComponent();
        }

        private void OnGenerate(object sender, EventArgs e)
        {
            Random r = new Random();
            int[] nums = new int[LottoCount];

            int num = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                do
                {
                    num = r.Next(1, 46);
                } while (nums.Contains(num));

                nums[i] = num;
            }

            Array.Sort(nums);

            Num1.Text = nums[0].ToString();
            Num2.Text = nums[1].ToString();
            Num3.Text = nums[2].ToString();
            Num4.Text = nums[3].ToString();
            Num5.Text = nums[4].ToString();
            Num6.Text = nums[5].ToString();
        }
    }
}
