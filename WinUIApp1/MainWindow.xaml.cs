using Microsoft.UI.Xaml;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUIApp1;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    public MainWindow() => InitializeComponent();

    private void MyButton_Click(object sender, RoutedEventArgs e) => myButton.Content = "Clicked";

    private void BlankPage1Button_Click(object sender, RoutedEventArgs e) => PageArea.Navigate(typeof(BlankPage1));

    private void BlankWindow1_Click(object sender, RoutedEventArgs e)
    {
        //new BlankWindow1.Show();
    }
}
