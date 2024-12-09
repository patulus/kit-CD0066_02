using System.Windows;

namespace G24W1501WPFDataGrid;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>

public partial class MainWindow : Window
{
    protected List<GundamModel> GundamList = new List<GundamModel>();

    public MainWindow()
    {
        InitializeComponent();

        GundamGrid.ItemsSource = GundamList;

        GundamList.Add(new GundamModel("건담", "RX-78-2", "연방군"));
        GundamList.Add(new GundamModel("자쿠II", "MS-06", "지온군"));
    }

    private void OnAdd(object sender, RoutedEventArgs e)
    {
        GundamList.Add(new GundamModel("건담", "RX-78-2", "연방군"));
        GundamList.Add(new GundamModel("자쿠II", "MS-06", "지온군"));
        GundamGrid.Items.Refresh();
    }
}