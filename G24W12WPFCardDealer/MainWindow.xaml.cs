using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace G24W12WPFCardDealer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnDeal(object sender, RoutedEventArgs e)
        {
            string[] suits = ["spades", "diamonds", "hearts", "clubs",];
            string[] values = ["ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king",];

            Random random = new Random();
            int card = random.Next(suits.Length * values.Length);

            string suit = suits[card / values.Length];
            string value = values[card % values.Length];

            if (Array.Exists(new string[] { "jack", "queen", "king" }, x => x == value))
            {
                suit += "2";
            }

            // UriKind?
            BitmapImage image = new BitmapImage(new Uri($"Images/{value}_of_{suit}.png", UriKind.RelativeOrAbsolute));
            Card1.Source = image;
        }
    }
}