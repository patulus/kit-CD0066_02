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

// namespace G24W11WPFCounter; 로 대체해 인덴트를 줄일 수 있음
namespace G24W11WPFCounter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CounterViewModel vm = new CounterViewModel();

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = vm;
        }

        private void OnAdd(object sender, RoutedEventArgs e)
        {
            //TxtCount.Text = $"{++Count}";

            vm.Value += 1;
        }

        private void OnSub(object sender, RoutedEventArgs e)
        {
            //if (Count > 0)
            //    TxtCount.Text = $"{--Count}";

            vm.Value -= 1;
        }
    }
}