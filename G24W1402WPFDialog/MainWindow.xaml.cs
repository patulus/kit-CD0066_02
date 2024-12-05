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

namespace G24W1402WPFDialog
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
            GundamDlg dialog = new GundamDlg();
            if (dialog.ShowDialog() != true)
                return;

            Result.Text = $"{dialog.MSParty}의 {dialog.MSModel} {dialog.MSName}{(HasJongsung(dialog.MSName) ? "이" : "가")} 추가되었습니다.\n" + Result;
        }

        private bool HasJongsung(string str)
        {
            if (str.Length < 1)
                return true;
            char last = str[str.Length - 1];
            return (last - 44032) % 28 != 0;
        }
    }
}