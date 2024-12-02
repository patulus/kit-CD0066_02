using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace G24W1401WPFMenu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ItemWhite.IsEnabled = false;
            ItemWhite.IsChecked = true;

            CommandBinding bind = new CommandBinding(ApplicationCommands.Open);
            bind.Executed += OpenDocument;
            CommandBindings.Add(bind);
        }

        private void OpenDocument(object sender, ExecutedRoutedEventArgs e)
        {
            // Configure open file dialog box
            var dialog = new Microsoft.Win32.OpenFileDialog();
            //dialog.FileName = "Document"; // Default file name
            dialog.DefaultExt = ".jpg"; // Default file extension
            dialog.Filter = "Images (.jpg)|*.jpg"; // Filter files by extension

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result != true) return;

            // Open document
            string filename = dialog.FileName;
            MessageBox.Show(filename);
        }

        private void SetColor(object sender, RoutedEventArgs e)
        {
            MenuItem? item = sender as MenuItem;
            if (item == null) return;

            Color color = item.Name switch
            {
                "ItemRed" => Colors.Red,
                "ItemGreen" => Colors.Green,
                "ItemBlue" => Colors.Blue,
                _ => Colors.White,
            };

            SolidColorBrush brush = new SolidColorBrush(color);
            BackPanel.Background = brush;

            ItemRed.IsEnabled = item != ItemRed;
            ItemGreen.IsEnabled = item != ItemGreen;
            ItemBlue.IsEnabled = item != ItemBlue;
            ItemWhite.IsEnabled = item != ItemWhite;

            ItemRed.IsChecked = item == ItemRed;
            ItemGreen.IsChecked = item == ItemGreen;
            ItemBlue.IsChecked = item == ItemBlue;
            ItemWhite.IsChecked = item == ItemWhite;
        }

        // object sender를 통해 누가 이 함수를 호출했는지 파악할 수 있음
        private void SetRed(object sender, RoutedEventArgs e)
        {
            //MenuItem item = (MenuItem)sender;
            //item.IsChecked = true;

            BackPanel.Background = Brushes.Red;

            ItemRed.IsEnabled = false;
            ItemRed.IsChecked = true;

            ItemGreen.IsEnabled = true;
            ItemGreen.IsChecked = false;
            ItemBlue.IsEnabled = true;
            ItemBlue.IsChecked = false;
            ItemWhite.IsEnabled = true;
            ItemWhite.IsChecked = false;
        }

        private void SetGreen(object sender, RoutedEventArgs e)
        {
            // Solid와 Stripe
            SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            BackPanel.Background = brush;

            ItemGreen.IsEnabled = false;
            ItemGreen.IsChecked = true;

            ItemRed.IsEnabled = true;
            ItemRed.IsChecked = false;
            ItemBlue.IsEnabled = true;
            ItemBlue.IsChecked = false;
            ItemWhite.IsEnabled = true;
            ItemWhite.IsChecked = false;
        }

        private void SetBlue(object sender, RoutedEventArgs e)
        {
            BackPanel.Background = Brushes.Blue;

            ItemBlue.IsEnabled = false;
            ItemBlue.IsChecked = true;

            ItemGreen.IsEnabled = true;
            ItemGreen.IsChecked = false;
            ItemRed.IsEnabled = true;
            ItemRed.IsChecked = false;
            ItemWhite.IsEnabled = true;
            ItemWhite.IsChecked = false;
        }

        private void SetWhite(object sender, RoutedEventArgs e)
        {
            BackPanel.Background = Brushes.White;

            ItemWhite.IsEnabled = false;
            ItemWhite.IsChecked = true;

            ItemGreen.IsEnabled = true;
            ItemGreen.IsChecked = false;
            ItemBlue.IsEnabled = true;
            ItemBlue.IsChecked = false;
            ItemRed.IsEnabled = true;
            ItemRed.IsChecked = false;
        }
    }
}