using System.Security.Cryptography.Pkcs;
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

namespace G24W1301WPFControls
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

        private void OnAdd(object sender, RoutedEventArgs e)
        {
            string str = $"{Singer.Text}{(HasJongsung(Singer.Text) ? "이" : "가")} 부른 "
                + $"{Genre.Text} 장르의 "
                + $"{Title.Text}{(HasJongsung(Title.Text) ? "이" : "가")} 추가됨\n";

            Result.Text = str + Result.Text;
        }

        public bool HasJongsung(string str)
        {
            if (str.Length < 1)
                return true;
            char last = str[str.Length - 1];
            return (last - 44032) % 28 != 0 ? true : false;
        }
    }
}