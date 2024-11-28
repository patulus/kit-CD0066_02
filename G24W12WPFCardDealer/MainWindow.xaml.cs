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
        private CardModel cardModel = new CardModel();
        private CardViewModel cardViewModel;

        public MainWindow()
        {
            InitializeComponent();

            cardViewModel = new CardViewModel(cardModel);
            DataContext = cardViewModel;
        }

        private void OnDeal(object sender, RoutedEventArgs e)
        {
            cardViewModel.DealCards();
        }
    }
}